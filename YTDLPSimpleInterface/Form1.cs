using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Python.Runtime;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YTDLPSimpleInterface
{
    public partial class Form1 : Form
    {
        public string AudioFormat = "";
        public string RemuxOption = "";
        public string SubtitlesOption = "--no-write-subs";
        public string QualityOption = "-f bestvideo";

        private Process currentProcess = null;
        private CancellationTokenSource cts = null;
        private string currentTempDir = null;
        // download flag
        private bool downloadInProgress = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void OutputDirectoryTextBox_TextChanged(object sender, EventArgs e) { }

        private async void DownloadBtn_Click(object sender, EventArgs e)
        {
            string URL = UrlTxtBox.Text;
            bool audio = AudioOnlyBtn.Checked;
            bool video = VideoBtn.Checked;
            string PlaylistOption = "--no-playlist";
            if (PlaylistBtn.Checked)
            {
                PlaylistOption = "";
            }
            else
            {
                PlaylistOption = "--no-playlist";
            }

            if (string.IsNullOrEmpty(URL))
            {
                MessageBox.Show("TYPE IN URL", "NO URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // creating temp file
            currentTempDir = Path.Combine(Path.GetTempPath(), "YTDLP_" + Guid.NewGuid().ToString("N"));
            try { Directory.CreateDirectory(currentTempDir); } catch { currentTempDir = null; }

            string tempDir = currentTempDir ?? Path.GetTempPath(); 
            string outputTemplate = Path.Combine(tempDir, "%(title)s.%(ext)s");

            // command for ytdlp, if audio, else video
            string arguments = audio
                ? $"{PlaylistOption} --ignore-errors {AudioFormat} --extract-audio {SubtitlesOption} -o \"{outputTemplate}\" \"{URL}\"" 
                : $"{PlaylistOption} --ignore-errors {RemuxOption} {SubtitlesOption} -o \"{outputTemplate}\" \"{URL}\"";

            var psi = new ProcessStartInfo
            {
                FileName = "yt-dlp.exe",
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            StringBuilder logBuilder = new StringBuilder();

            var progressRegex = new Regex(@"(?<pct>\d{1,3}(?:\.\d+)?)\s*%", RegexOptions.Compiled);

            // starting ui
            try
            {
               
                downloadProgressBar.Style = ProgressBarStyle.Continuous;
                downloadProgressBar.Value = 0;
                progressLabel.Text = "Starting...";
                CancelBtn.Enabled = true; 
                downloadInProgress = true;

                cts = new CancellationTokenSource();

                using (var proc = new Process { StartInfo = psi, EnableRaisingEvents = true })
                {
                    currentProcess = proc;

                    proc.OutputDataReceived += (s, ea) =>
                    {
                        if (ea.Data == null) return;
                        logBuilder.AppendLine(ea.Data);

                        var m = progressRegex.Match(ea.Data);
                        if (m.Success && double.TryParse(m.Groups["pct"].Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double pct))
                        {
                            int intPct = Math.Max(0, Math.Min(100, (int)Math.Round(pct)));
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                downloadProgressBar.Style = ProgressBarStyle.Continuous;
                                downloadProgressBar.Value = intPct;
                                progressLabel.Text = $"{intPct}% — {ea.Data}";
                            });
                        }
                        else
                        {
                            if (ea.Data.IndexOf("Merging formats", StringComparison.OrdinalIgnoreCase) >= 0
                                || ea.Data.IndexOf("merging", StringComparison.OrdinalIgnoreCase) >= 0
                                || ea.Data.IndexOf("ffmpeg", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    downloadProgressBar.Style = ProgressBarStyle.Marquee;
                                    progressLabel.Text = ea.Data;
                                });
                            }
                        }
                    };

                    proc.ErrorDataReceived += (s, ea) =>
                    {
                        if (ea.Data == null) return;
                        logBuilder.AppendLine(ea.Data);

                        var m = progressRegex.Match(ea.Data);
                        if (m.Success && double.TryParse(m.Groups["pct"].Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double pct))
                        {
                            int intPct = Math.Max(0, Math.Min(100, (int)Math.Round(pct)));
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                downloadProgressBar.Style = ProgressBarStyle.Continuous;
                                downloadProgressBar.Value = intPct;
                                progressLabel.Text = $"{intPct}% — {ea.Data}";
                            });
                        }
                        else
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                if (downloadProgressBar.Style != ProgressBarStyle.Continuous)
                                    downloadProgressBar.Style = ProgressBarStyle.Marquee;
                                progressLabel.Text = ea.Data;
                            });
                        }
                    };

                    proc.Start();
                    proc.BeginOutputReadLine();
                    proc.BeginErrorReadLine();

                    await Task.Run(() =>
                    {
                        while (!proc.WaitForExit(200))
                        {
                            if (cts.IsCancellationRequested)
                            {
                                try
                                {
                                    if (!proc.HasExited)
                                        proc.Kill();
                                }
                                catch { }
                                break;
                            }
                        }

                        if (!proc.HasExited)
                            proc.WaitForExit();
                    });

                }

                var tempExts = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".part", ".parttmp", ".crdownload", ".tmp", ".partial", ".module"
                };

                var allFiles = Directory.GetFiles(tempDir);

                var resultFiles = allFiles
                    .Where(f =>
                    {
                        string name = Path.GetFileName(f);
                        string ext = Path.GetExtension(f) ?? "";
                        if (name.IndexOf(".part", StringComparison.OrdinalIgnoreCase) >= 0) return false;
                        if (tempExts.Contains(ext)) return false;
                        return true;
                    })
                    .ToList();

                if (resultFiles.Count == 0 && allFiles.Length > 0)
                {
                    // choose biggest file to be downoladed( getting rid of .temp files)
                    resultFiles = new List<string> { allFiles.OrderByDescending(f => new FileInfo(f).Length).First() };
                }

                if (resultFiles.Count == 0)
                {
                    MessageBox.Show("No output file found (maybe ffmpeg is missing or URL error).\n\n" +
                                    (logBuilder.Length > 0 ? logBuilder.ToString() : ""),
                                    "Download error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (resultFiles.Count == 1)
                {
                    string downloaded = resultFiles[0];
                    using (var saveDialog = new SaveFileDialog())
                    {
                        saveDialog.FileName = Path.GetFileName(downloaded);

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(downloaded, saveDialog.FileName, true);
                            MessageBox.Show($"Saved in: {saveDialog.FileName}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    using (var folderDialog = new FolderBrowserDialog())
                    {
                        folderDialog.Description = "Multiple files have been downloaded. Select a destination folder to save them all.";
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            string destDir = folderDialog.SelectedPath;
                            foreach (var src in resultFiles)
                            {
                                string destPath = Path.Combine(destDir, Path.GetFileName(src));
                                File.Copy(src, destPath, true);
                            }
                            MessageBox.Show($"Copied {resultFiles.Count} files to: {destDir}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\nLog:\n{logBuilder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // reset UI
                this.BeginInvoke((MethodInvoker)delegate
                {
                    downloadProgressBar.Style = ProgressBarStyle.Continuous;
                    downloadProgressBar.Value = 0;
                    progressLabel.Text = "";
                    CancelBtn.Enabled = false;
                });


                try
                {
                    if (!string.IsNullOrEmpty(currentTempDir) && Directory.Exists(currentTempDir))
                    {
                        Directory.Delete(currentTempDir, true);
                    }
                }
                catch
                {
                }
                finally
                {
                    currentTempDir = null;
                }

                currentProcess = null;
                if (cts != null) { cts.Dispose(); cts = null; }
                downloadInProgress = false;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (downloadInProgress)
            {
                var res = MessageBox.Show("Downloadi is in progress. If you close the app, you will lose your progress. Are you sure you want to continue?", "Close app", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    try
                    {
                        cts?.Cancel();
                        if (currentProcess != null && !currentProcess.HasExited)
                        {
                            try { currentProcess.Kill(); } catch { }
                        }
                    }
                    catch { }

                    // cleaning temp
                    try
                    {
                        if (!string.IsNullOrEmpty(currentTempDir) && Directory.Exists(currentTempDir))
                        {
                            Directory.Delete(currentTempDir, true);
                        }
                    }
                    catch { }
                    currentTempDir = null;
                }
            }

            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                cts?.Cancel();
                if (currentProcess != null && !currentProcess.HasExited)
                    currentProcess.Kill();
            }
            catch { }

            try
            {
                PythonEngine.Shutdown();
            }
            catch { }

            base.OnFormClosed(e);
        }

        private void UrlTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // cleaning temp on start
            Task.Run(() =>
            {
                try
                {
                    string systemTemp = Path.GetTempPath();
                    var dirs = Directory.GetDirectories(systemTemp, "YTDLP_*");
                    foreach (var d in dirs)
                    {
                        try
                        {
                            Directory.Delete(d, true);
                        }
                        catch
                        {
                        }
                    }
                }
                catch { }
            });
        }

        private void FullHDBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (VideoBtn.Checked)
            {
                groupBox5.Enabled = false;
                groupBox3.Enabled = true;
                OriginalAudioBtn.Checked = true;
            }
            else
            {
                groupBox5.Enabled = true;
                groupBox3.Enabled = false;
                OriginalVideoBtn.Checked = true;
            }
        }

        private void m4aBtn_CheckedChanged(object sender, EventArgs e)
        {
            AudioFormat = "--audio-format m4a";
        }
        private void AudioOnlyBtn_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void aviBtn_CheckedChanged(object sender, EventArgs e)
        {
            RemuxOption = "--remux-video avi";
        }
        private void flvBtn_CheckedChanged(object sender, EventArgs e)
        {
            RemuxOption = "--remux-video flv";
        }
        private void mkvBtn_CheckedChanged(object sender, EventArgs e)
        {
            RemuxOption = "--remux-video mkv";
        }
        private void mp4Btn_CheckedChanged(object sender, EventArgs e)
        {
            RemuxOption = "--remux-video mp4";
        }
        private void webmBtn_CheckedChanged(object sender, EventArgs e)
        {
            RemuxOption = "--remux-video webm";

        }
        private void wavBtn_CheckedChanged(object sender, EventArgs e)
        {
            AudioFormat = "--audio-format wav";
        }
        private void mp3Btn_CheckedChanged(object sender, EventArgs e)
        {
            AudioFormat = "--audio-format mp3";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void OriginalVideoBtn_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void OriginalAudioBtn_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void downloadProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelBtn.Enabled = false;
            try
            {
                cts?.Cancel();
                if (currentProcess != null && !currentProcess.HasExited)
                {
                    try { currentProcess.Kill(); } catch { }
                }
            }
            catch { }
        }

        private void PlaylistBtn_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void flacBtn_CheckedChanged(object sender, EventArgs e)
        {
            AudioFormat = "--audio-format flac";
        }

        private void SubtitlesBtn_CheckedChanged(object sender, EventArgs e)
        {
            //if(SubtitlesBtn.Checked)
            //{
            //     SubtitlesOption = "--write-subs";
            //}
            //else
            //{
            //    SubtitlesOption = "--no-write-subs";
            //}
        }
    }
}
