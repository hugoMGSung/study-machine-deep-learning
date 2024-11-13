using OpenCvSharp;

namespace CVWin_0701
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Mat src = Cv2.ImRead("../../../../../../images/leaves.jpg", ImreadModes.Grayscale);
            Mat dst = new Mat();

            //Cv2.Sobel(src, dst, MatType.CV_8UC1, 1, 0, 3, 1, 0, BorderTypes.Reflect101);
            Cv2.Canny(src, dst, 100, 200, apertureSize:3, L2gradient:true);

            this.PicResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);
        }
    }
}
