using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVWin_707
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            using (Mat src = new Mat("starwars2019.webp", ImreadModes.ReducedGrayscale2))
            using (Mat dst = src.Canny(50, 200))
            {
                this.picSrc.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
                this.picDst.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);
            }

            this.picSrc.BackgroundImageLayout = this.picDst.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
