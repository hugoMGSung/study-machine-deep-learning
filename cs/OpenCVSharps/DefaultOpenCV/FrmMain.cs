using OpenCvSharp;

namespace DefaultOpenCV
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Mat src = Cv2.ImRead("jsm01.png", ImreadModes.Unchanged);

            Cv2.NamedWindow("Á¤¼Ò¹Î", WindowFlags.AutoSize);
            Cv2.SetWindowProperty("Á¤¼Ò¹Î", WindowPropertyFlags.Fullscreen, 0);
            Cv2.ImShow("Á¤¼Ò¹Î", src);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
