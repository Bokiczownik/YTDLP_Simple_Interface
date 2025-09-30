namespace YTDLPSimpleInterface
{
    partial class Form1
    {

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            groupBox2 = new GroupBox();
            VideoBtn = new RadioButton();
            AudioOnlyBtn = new RadioButton();
            UrlTxtBox = new TextBox();
            label2 = new Label();
            DownloadBtn = new Button();
            groupBox3 = new GroupBox();
            OriginalVideoBtn = new RadioButton();
            webmBtn = new RadioButton();
            mp4Btn = new RadioButton();
            mkvBtn = new RadioButton();
            flvBtn = new RadioButton();
            aviBtn = new RadioButton();
            groupBox5 = new GroupBox();
            flacBtn = new RadioButton();
            OriginalAudioBtn = new RadioButton();
            wavBtn = new RadioButton();
            m4aBtn = new RadioButton();
            mp3Btn = new RadioButton();
            downloadProgressBar = new ProgressBar();
            progressLabel = new Label();
            CancelBtn = new Button();
            PlaylistBtn = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Location = new Point(5, 145);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(165, 50);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Quality";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(13, 22);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(104, 19);
            radioButton2.TabIndex = 3;
            radioButton2.TabStop = true;
            radioButton2.Text = "Best available";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(VideoBtn);
            groupBox2.Controls.Add(AudioOnlyBtn);
            groupBox2.Location = new Point(5, 60);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(165, 79);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "File Type";
            // 
            // VideoBtn
            // 
            VideoBtn.AutoSize = true;
            VideoBtn.Checked = true;
            VideoBtn.Location = new Point(6, 22);
            VideoBtn.Name = "VideoBtn";
            VideoBtn.Size = new Size(57, 19);
            VideoBtn.TabIndex = 1;
            VideoBtn.TabStop = true;
            VideoBtn.Text = "Video";
            VideoBtn.UseVisualStyleBackColor = true;
            VideoBtn.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // AudioOnlyBtn
            // 
            AudioOnlyBtn.AutoSize = true;
            AudioOnlyBtn.Location = new Point(6, 47);
            AudioOnlyBtn.Name = "AudioOnlyBtn";
            AudioOnlyBtn.Size = new Size(85, 19);
            AudioOnlyBtn.TabIndex = 0;
            AudioOnlyBtn.TabStop = true;
            AudioOnlyBtn.Text = "Audio Only";
            AudioOnlyBtn.UseVisualStyleBackColor = true;
            AudioOnlyBtn.CheckedChanged += AudioOnlyBtn_CheckedChanged;
            // 
            // UrlTxtBox
            // 
            UrlTxtBox.Location = new Point(5, 22);
            UrlTxtBox.Name = "UrlTxtBox";
            UrlTxtBox.Size = new Size(411, 21);
            UrlTxtBox.TabIndex = 5;
            UrlTxtBox.TextChanged += UrlTxtBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 6);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 7;
            label2.Text = "Video URL";
            label2.Click += label2_Click;
            // 
            // DownloadBtn
            // 
            DownloadBtn.Location = new Point(285, 283);
            DownloadBtn.Name = "DownloadBtn";
            DownloadBtn.Size = new Size(131, 31);
            DownloadBtn.TabIndex = 9;
            DownloadBtn.Text = "Download";
            DownloadBtn.UseVisualStyleBackColor = true;
            DownloadBtn.Click += DownloadBtn_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(OriginalVideoBtn);
            groupBox3.Controls.Add(webmBtn);
            groupBox3.Controls.Add(mp4Btn);
            groupBox3.Controls.Add(mkvBtn);
            groupBox3.Controls.Add(flvBtn);
            groupBox3.Controls.Add(aviBtn);
            groupBox3.Location = new Point(170, 60);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(125, 164);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Remux";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // OriginalVideoBtn
            // 
            OriginalVideoBtn.AutoSize = true;
            OriginalVideoBtn.Checked = true;
            OriginalVideoBtn.Location = new Point(6, 22);
            OriginalVideoBtn.Name = "OriginalVideoBtn";
            OriginalVideoBtn.Size = new Size(110, 19);
            OriginalVideoBtn.TabIndex = 5;
            OriginalVideoBtn.TabStop = true;
            OriginalVideoBtn.Text = "Original format";
            OriginalVideoBtn.UseVisualStyleBackColor = true;
            OriginalVideoBtn.CheckedChanged += OriginalVideoBtn_CheckedChanged;
            // 
            // webmBtn
            // 
            webmBtn.AutoSize = true;
            webmBtn.Location = new Point(6, 141);
            webmBtn.Name = "webmBtn";
            webmBtn.Size = new Size(60, 19);
            webmBtn.TabIndex = 4;
            webmBtn.Text = "webm";
            webmBtn.UseVisualStyleBackColor = true;
            webmBtn.CheckedChanged += webmBtn_CheckedChanged;
            // 
            // mp4Btn
            // 
            mp4Btn.AutoSize = true;
            mp4Btn.Location = new Point(6, 116);
            mp4Btn.Name = "mp4Btn";
            mp4Btn.Size = new Size(50, 19);
            mp4Btn.TabIndex = 3;
            mp4Btn.Text = "mp4";
            mp4Btn.UseVisualStyleBackColor = true;
            mp4Btn.CheckedChanged += mp4Btn_CheckedChanged;
            // 
            // mkvBtn
            // 
            mkvBtn.AutoSize = true;
            mkvBtn.Location = new Point(6, 91);
            mkvBtn.Name = "mkvBtn";
            mkvBtn.Size = new Size(49, 19);
            mkvBtn.TabIndex = 2;
            mkvBtn.Text = "mkv";
            mkvBtn.UseVisualStyleBackColor = true;
            mkvBtn.CheckedChanged += mkvBtn_CheckedChanged;
            // 
            // flvBtn
            // 
            flvBtn.AutoSize = true;
            flvBtn.Location = new Point(6, 69);
            flvBtn.Name = "flvBtn";
            flvBtn.Size = new Size(38, 19);
            flvBtn.TabIndex = 1;
            flvBtn.Text = "flv";
            flvBtn.UseVisualStyleBackColor = true;
            flvBtn.CheckedChanged += flvBtn_CheckedChanged;
            // 
            // aviBtn
            // 
            aviBtn.AutoSize = true;
            aviBtn.Location = new Point(6, 47);
            aviBtn.Name = "aviBtn";
            aviBtn.Size = new Size(41, 19);
            aviBtn.TabIndex = 0;
            aviBtn.Text = "avi";
            aviBtn.UseVisualStyleBackColor = true;
            aviBtn.CheckedChanged += aviBtn_CheckedChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(flacBtn);
            groupBox5.Controls.Add(OriginalAudioBtn);
            groupBox5.Controls.Add(wavBtn);
            groupBox5.Controls.Add(m4aBtn);
            groupBox5.Controls.Add(mp3Btn);
            groupBox5.Enabled = false;
            groupBox5.Location = new Point(292, 60);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(124, 164);
            groupBox5.TabIndex = 10;
            groupBox5.TabStop = false;
            groupBox5.Text = "Audio format";
            groupBox5.Enter += groupBox5_Enter;
            // 
            // flacBtn
            // 
            flacBtn.AutoSize = true;
            flacBtn.Location = new Point(6, 116);
            flacBtn.Name = "flacBtn";
            flacBtn.Size = new Size(46, 19);
            flacBtn.TabIndex = 7;
            flacBtn.TabStop = true;
            flacBtn.Text = "flac";
            flacBtn.UseVisualStyleBackColor = true;
            flacBtn.CheckedChanged += flacBtn_CheckedChanged;
            // 
            // OriginalAudioBtn
            // 
            OriginalAudioBtn.AutoSize = true;
            OriginalAudioBtn.Checked = true;
            OriginalAudioBtn.Location = new Point(6, 22);
            OriginalAudioBtn.Name = "OriginalAudioBtn";
            OriginalAudioBtn.Size = new Size(110, 19);
            OriginalAudioBtn.TabIndex = 4;
            OriginalAudioBtn.TabStop = true;
            OriginalAudioBtn.Text = "Original format";
            OriginalAudioBtn.UseVisualStyleBackColor = true;
            OriginalAudioBtn.CheckedChanged += OriginalAudioBtn_CheckedChanged;
            // 
            // wavBtn
            // 
            wavBtn.AutoSize = true;
            wavBtn.Location = new Point(6, 69);
            wavBtn.Name = "wavBtn";
            wavBtn.Size = new Size(48, 19);
            wavBtn.TabIndex = 3;
            wavBtn.TabStop = true;
            wavBtn.Text = "wav";
            wavBtn.UseVisualStyleBackColor = true;
            wavBtn.CheckedChanged += wavBtn_CheckedChanged;
            // 
            // m4aBtn
            // 
            m4aBtn.AutoSize = true;
            m4aBtn.Location = new Point(6, 47);
            m4aBtn.Name = "m4aBtn";
            m4aBtn.Size = new Size(50, 19);
            m4aBtn.TabIndex = 1;
            m4aBtn.TabStop = true;
            m4aBtn.Text = "m4a";
            m4aBtn.UseVisualStyleBackColor = true;
            m4aBtn.CheckedChanged += m4aBtn_CheckedChanged;
            // 
            // mp3Btn
            // 
            mp3Btn.AutoSize = true;
            mp3Btn.Location = new Point(6, 91);
            mp3Btn.Name = "mp3Btn";
            mp3Btn.Size = new Size(50, 19);
            mp3Btn.TabIndex = 0;
            mp3Btn.TabStop = true;
            mp3Btn.Text = "mp3";
            mp3Btn.UseVisualStyleBackColor = true;
            mp3Btn.CheckedChanged += mp3Btn_CheckedChanged;
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Location = new Point(2, 255);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(414, 22);
            downloadProgressBar.TabIndex = 11;
            downloadProgressBar.Click += downloadProgressBar_Click;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            progressLabel.Location = new Point(10, 235);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new Size(0, 15);
            progressLabel.TabIndex = 12;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(2, 284);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(104, 31);
            CancelBtn.TabIndex = 13;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // PlaylistBtn
            // 
            PlaylistBtn.AutoSize = true;
            PlaylistBtn.Location = new Point(18, 205);
            PlaylistBtn.Name = "PlaylistBtn";
            PlaylistBtn.Size = new Size(125, 19);
            PlaylistBtn.TabIndex = 14;
            PlaylistBtn.Text = "Download playlist";
            PlaylistBtn.UseVisualStyleBackColor = true;
            PlaylistBtn.CheckedChanged += PlaylistBtn_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(421, 326);
            Controls.Add(PlaylistBtn);
            Controls.Add(CancelBtn);
            Controls.Add(groupBox1);
            Controls.Add(progressLabel);
            Controls.Add(downloadProgressBar);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(DownloadBtn);
            Controls.Add(label2);
            Controls.Add(UrlTxtBox);
            Controls.Add(groupBox2);
            Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton VideoBtn;
        private RadioButton AudioOnlyBtn;
        private TextBox UrlTxtBox;
        private Label label2;
        private Button DownloadBtn;
        private RadioButton radioButton2;
        private GroupBox groupBox3;
        private RadioButton webmBtn;
        private RadioButton mp4Btn;
        private RadioButton mkvBtn;
        private RadioButton flvBtn;
        private RadioButton aviBtn;
        private GroupBox groupBox5;
        private RadioButton wavBtn;
        private RadioButton m4aBtn;
        private RadioButton mp3Btn;
        private RadioButton OriginalVideoBtn;
        private RadioButton OriginalAudioBtn;
        private ProgressBar downloadProgressBar;
        private Label progressLabel;
        private Button CancelBtn;
        private CheckBox PlaylistBtn;
        private RadioButton flacBtn;
    }
}
