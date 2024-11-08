namespace MPWin_709
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            btnOpen = new Button();
            btnPlay = new Button();
            btnPause = new Button();
            btnStop = new Button();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(12, 12);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(1256, 696);
            axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(12, 719);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(94, 29);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(112, 719);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 29);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "PIay";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(212, 719);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(94, 29);
            btnPause.TabIndex = 2;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += this.btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(312, 719);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += this.btnStop_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 760);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            Controls.Add(btnPlay);
            Controls.Add(btnOpen);
            Controls.Add(axWindowsMediaPlayer1);
            Name = "FrmMain";
            Text = "MediaPlayer";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button btnOpen;
        private Button btnPlay;
        private Button btnPause;
        private Button btnStop;
    }
}
