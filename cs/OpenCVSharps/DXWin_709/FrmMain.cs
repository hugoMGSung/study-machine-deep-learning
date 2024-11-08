using DirectShowLib;
using System.Runtime.InteropServices;

namespace DXWin_709
{
    public partial class FrmMain : Form
    {
        IGraphBuilder pGraphBuilder;
        IMediaControl pMediaControl;
        IVideoWindow pVideoWindow;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            pGraphBuilder = new FilterGraph() as IGraphBuilder;
            pMediaControl = pGraphBuilder as IMediaControl;

            pVideoWindow = pGraphBuilder as IVideoWindow;

            string filePath = "../../../../../../images/deathstar2.mp4";
            pGraphBuilder.RenderFile(filePath, null);

            pVideoWindow.put_Owner(this.Handle);
            pVideoWindow.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipSiblings);
            pVideoWindow.SetWindowPosition(0, 0, this.Width, this.Height);
            pVideoWindow.put_MessageDrain(this.Handle);
            pVideoWindow.put_Visible(OABool.True);

            if (pMediaControl == null)
            {
                return;
            }

            pMediaControl.Run();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (pGraphBuilder != null)
            {
                Marshal.ReleaseComObject(pGraphBuilder);
            }

            if (pMediaControl != null)
            {
                Marshal.ReleaseComObject(pMediaControl);
            }

            base.OnClosed(e);
        }

    }
}
