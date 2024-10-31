using OpenCvSharp;
using System.Windows.Forms;
using System;


namespace ImageOpenCV
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "이미지 선택";
            ofd.Filter = "Image file(*.bmp;*.jpg;*.png;*.jpeg)|*.bmp;*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK )
            {
                ProcessImageWithCV(ofd.FileName);
                //PicResult.Image = Bitmap.FromFile(ofd.FileName);
            }
        }

        private void ProcessImageWithCV(string fileName)
        {
            Mat mat = Cv2.ImRead(fileName);
            Mat gray = new Mat();
            Mat hist = new Mat();
            Mat result = Mat.Ones(new OpenCvSharp.Size(256, mat.Height), MatType.CV_8UC1);
            Mat dst = new Mat();

            Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY); // 회색 변경
            Cv2.CalcHist(new Mat[] { gray }, new int[] { 0, }, null, hist, 1, new int[] { 256 }, new Rangef[] { new Rangef(0, 256) });
            Cv2.Normalize(hist, hist, 0, 255, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                Cv2.Line(result, new OpenCvSharp.Point(i, mat.Height), new OpenCvSharp.Point(i, mat.Height - hist.Get<float>(i)), Scalar.White);
            }

            Cv2.HConcat(new Mat[] { gray, result }, dst);
            Cv2.ImShow("dst", dst);

            MemoryStream memoryStream = new MemoryStream(mat.ToBytes());
            PicResult.Image = new Bitmap(memoryStream);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
