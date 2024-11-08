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
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                openFile = ofd.FileName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (openFile == "")
            {
                MessageBox.Show("Please Open Video!", "Error");
            }
            else
            {
                axWindowsMediaPlayer1.URL = openFile;
                axWindowsMediaPlayer1.Ctlcontrols.play();

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }
}
