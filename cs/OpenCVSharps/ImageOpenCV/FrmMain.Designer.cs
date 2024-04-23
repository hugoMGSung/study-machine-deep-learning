namespace ImageOpenCV
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
            BtnOpen = new Button();
            PicResult = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PicResult).BeginInit();
            SuspendLayout();
            // 
            // BtnOpen
            // 
            BtnOpen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnOpen.Location = new Point(734, 438);
            BtnOpen.Name = "BtnOpen";
            BtnOpen.Size = new Size(97, 41);
            BtnOpen.TabIndex = 0;
            BtnOpen.Text = "OPEN";
            BtnOpen.UseVisualStyleBackColor = true;
            BtnOpen.Click += BtnOpen_Click;
            // 
            // PicResult
            // 
            PicResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PicResult.BackColor = SystemColors.ActiveBorder;
            PicResult.Location = new Point(12, 12);
            PicResult.Name = "PicResult";
            PicResult.Size = new Size(819, 420);
            PicResult.TabIndex = 1;
            PicResult.TabStop = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 491);
            Controls.Add(PicResult);
            Controls.Add(BtnOpen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image OpenCV";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)PicResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnOpen;
        private PictureBox PicResult;
    }
}
