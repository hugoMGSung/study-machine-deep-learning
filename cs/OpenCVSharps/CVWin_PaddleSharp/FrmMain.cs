using OpenCvSharp;
using OpenCvSharp.Text;
using Sdcb.PaddleInference;
using Sdcb.PaddleOCR.Models.Online;
using Sdcb.PaddleOCR.Models;
using Sdcb.PaddleOCR;
using System.Security.Cryptography;

namespace CVWin_PaddleSharp
{
    public partial class FrmMain : Form
    {
        private string strResult = string.Empty;
        public FrmMain()
        {
            InitializeComponent();
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            FullOcrModel model = await OnlineFullModels.EnglishV3.DownloadAsync();

            byte[] sampleImageData;
            string sampleImageUrl = @"http://sanhaesam2020.mysam98.gethompy.com/files/attach/images/157/247/a4c5e6faf95ac81ee52c0c53644f6fe5.jpg";
            using (HttpClient http = new HttpClient())
            {
                Console.WriteLine("Download sample image from: " + sampleImageUrl);
                sampleImageData = await http.GetByteArrayAsync(sampleImageUrl);
            }

            using (PaddleOcrAll all = new PaddleOcrAll(model, PaddleDevice.Mkldnn())
            {
                AllowRotateDetection = true, /* 기울어진 텍스트 인식 가능 */
                Enable180Classification = false, /* 0도 이상의 회전 각도로 텍스트를 인식 */
            })
            {
                // Load local file by following code:
                // using (Mat src2 = Cv2.ImRead(@"C:\test.jpg"))
                using (Mat src = Cv2.ImDecode(sampleImageData, ImreadModes.Color))
                {
                    // 마지막에 윈도우 화면에 뿌리기!!
                    this.PicResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);


                    PaddleOcrResult result = all.Run(src);
                    Console.WriteLine("Detected all texts: \n" + result.Text);
                    foreach (PaddleOcrResultRegion region in result.Regions)
                    {
                        strResult = $"Text: {region.Text}, Score: {region.Score}, RectCenter: {region.Rect.Center}, RectSize:    {region.Rect.Size}, Angle: {region.Rect.Angle}";

                        ProcResultMessage(strResult);
                    }
                }
            }
        }

        private void ProcResultMessage(string strResult)
        {
            MessageBox.Show(strResult);
        }
    }
}
