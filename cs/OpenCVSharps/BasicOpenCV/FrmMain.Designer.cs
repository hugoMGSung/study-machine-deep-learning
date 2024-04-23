namespace BasicOpenCV
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
            TxtResult = new TextBox();
            BtnCheck = new Button();
            SuspendLayout();
            // 
            // TxtResult
            // 
            TxtResult.Location = new Point(12, 12);
            TxtResult.Multiline = true;
            TxtResult.Name = "TxtResult";
            TxtResult.Size = new Size(290, 111);
            TxtResult.TabIndex = 0;
            // 
            // BtnCheck
            // 
            BtnCheck.Location = new Point(202, 129);
            BtnCheck.Name = "BtnCheck";
            BtnCheck.Size = new Size(100, 40);
            BtnCheck.TabIndex = 1;
            BtnCheck.Text = "CHECK";
            BtnCheck.UseVisualStyleBackColor = true;
            BtnCheck.Click += BtnCheck_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 181);
            Controls.Add(BtnCheck);
            Controls.Add(TxtResult);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            Text = "OpenCV Check";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtResult;
        private Button BtnCheck;
    }
}
