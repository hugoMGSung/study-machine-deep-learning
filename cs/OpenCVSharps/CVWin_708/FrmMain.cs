using OpenCvSharp.Extensions;
using OpenCvSharp;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace CVWin_708
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            while (true)
            {
                if (_q.TryTake(out Bitmap item) == true)
                {
                    g.DrawImage(item, new PointF(0, 0));
                    item.Dispose();
                }
                else
                {
                    break;
                }
            }
            // 계속 깜빡임!!!
            // OpenCvSharp.Window를 이용했던 예제와 비교해 성능이 심각하게 하락
        }

        BlockingCollection<Bitmap> _q = new BlockingCollection<Bitmap>();

        private Thread camera;

        private void CaptureCameraCallback()
        {
            VideoCapture capture = new VideoCapture("../../../../../../images/deathstar2.mp4");

            if (capture.IsOpened() == false)
            {
                return;
            }

            int fps = (int)capture.Fps;

            int expectedProcessTimePerFrame = 1000 / fps;
            Stopwatch st = new Stopwatch();
            st.Start();

            using (Mat image = new Mat())
            {
                while (true)
                {
                    long started = st.ElapsedMilliseconds;
                    capture.Read(image);

                    if (image.Empty() == true)
                    {
                        break;
                    }

                    _q.Add(BitmapConverter.ToBitmap(image));
                    this.Invoke((Action)(() => this.Invalidate()));

                    int elapsed = (int)(st.ElapsedMilliseconds - started);
                    int delay = expectedProcessTimePerFrame - elapsed;

                    if (delay > 0)
                    {
                        Thread.Sleep(delay);
                    }
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            camera = new Thread(CaptureCameraCallback);
            camera.IsBackground = true;
            camera.Start();
        }
    }
}
