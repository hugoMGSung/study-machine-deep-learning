using AxWMPLib;

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
            PlayerMain = new AxWindowsMediaPlayer();
            btnPlay = new Button();
            btnPause = new Button();
            btnStop = new Button();
            ((System.ComponentModel.ISupportInitialize)PlayerMain).BeginInit();
            SuspendLayout();
            // 
            // PlayerMain
            // 
            PlayerMain.Dock = DockStyle.Fill;
            PlayerMain.Enabled = true;
            PlayerMain.Location = new Point(0, 0);
            PlayerMain.Name = "PlayerMain";
            PlayerMain.OcxState = (AxHost.State)resources.GetObject("PlayerMain.OcxState");
            PlayerMain.Size = new Size(1280, 720);
            PlayerMain.TabIndex = 0;
            PlayerMain.DoubleClickEvent += axWindowsMediaPlayer1_DoubleClickEvent;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(0, 0);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 0;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(0, 0);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 23);
            btnPause.TabIndex = 0;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(0, 0);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 0;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 719);
            Controls.Add(PlayerMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmMain";
            Text = "MediaPlayer";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)PlayerMain).EndInit();
            ResumeLayout(false);
        }



        #endregion

        private AxWMPLib.AxWindowsMediaPlayer PlayerMain;
        private Button btnPlay;
        private Button btnPause;
        private Button btnStop;
    }
}
