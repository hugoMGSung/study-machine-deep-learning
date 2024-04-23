using OpenCvSharp;
using System.Diagnostics;

namespace BasicOpenCV
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"OpenCV {Cv2.GetVersionString()}");
            TxtResult.AppendText($"OpenCV {Cv2.GetVersionString()}" + Environment.NewLine);
        }
    }
}
