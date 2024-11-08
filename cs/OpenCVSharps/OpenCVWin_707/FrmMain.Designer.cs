namespace OpenCVWin_707
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picSrc = new PictureBox();
            picDst = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picSrc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDst).BeginInit();
            SuspendLayout();
            // 
            // picSrc
            // 
            picSrc.BackgroundImageLayout = ImageLayout.Stretch;
            picSrc.Location = new Point(12, 12);
            picSrc.Name = "picSrc";
            picSrc.Size = new Size(453, 727);
            picSrc.TabIndex = 0;
            picSrc.TabStop = false;
            // 
            // picDst
            // 
            picDst.BackgroundImageLayout = ImageLayout.Stretch;
            picDst.Location = new Point(471, 12);
            picDst.Name = "picDst";
            picDst.Size = new Size(453, 727);
            picDst.TabIndex = 1;
            picDst.TabStop = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 751);
            Controls.Add(picDst);
            Controls.Add(picSrc);
            Name = "FrmMain";
            Text = "FrmMain";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)picSrc).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDst).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picSrc;
        private PictureBox picDst;
    }
}