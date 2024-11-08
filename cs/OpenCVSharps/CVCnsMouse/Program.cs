using System;
using OpenCvSharp;

namespace CVCnsMouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OpenCV MouseCallback");

            //Mat src = new Mat(new Size(500, 500), MatType.CV_8UC3, new Scalar(255, 255, 255));

            //Cv2.ImShow("draw", src);
            //MouseCallback MouseCallback = new MouseCallback(Event);
            //Cv2.SetMouseCallback("draw", MouseCallback, src.CvPtr);
            //Cv2.WaitKey(0);
            //Cv2.DestroyAllWindows();

            Cv2.NamedWindow("Palette");
            Cv2.CreateTrackbar("Color", "Palette", 255);

            while (true)
            {
                int pixel = Cv2.GetTrackbarPos("Color", "Palette");
                Mat src = new Mat(new Size(500, 500), MatType.CV_8UC3, new Scalar(pixel, pixel, pixel));

                Cv2.ImShow("Palette", src);
                if (Cv2.WaitKey(33) == 'q')
                    break;
            }

            Cv2.DestroyAllWindows();
        }

        //static void Event(MouseEventTypes @event, int x, int y, MouseEventFlags flags, IntPtr userdata)
        //{
        //    Mat data = new Mat(userdata);

        //    if (flags == MouseEventFlags.LButton)
        //    {
        //        Cv2.Circle(data, new Point(x, y), 10, new Scalar(0, 0, 255), -1);
        //        Cv2.ImShow("draw", data);
        //    }
        //}
    }
}
