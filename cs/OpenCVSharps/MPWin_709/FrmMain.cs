using AxWMPLib;

namespace MPWin_709
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        string openFile;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            PlayerMain.uiMode = "mini"; // invisible, none, mini, full, custom
        }

        private void axWindowsMediaPlayer1_DoubleClickEvent(object sender, _WMPOCXEvents_DoubleClickEvent e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                openFile = ofd.FileName;
            }

            PlayerMain.URL = openFile;
            PlayerMain.Ctlcontrols.play();
        }
    }
}
