using System;
using System.Collections.Generic;
using Emgu.Util;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace Test_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            String win1 = "Test Window (Press any key to close)"; //The name of the window
            CvInvoke.NamedWindow(win1); //Create the window using the specific name
            Mat frame = new Mat();
            VideoCapture capture = new VideoCapture();
            while ((CvInvoke.WaitKey(1) == -1))
            {
                capture.Read(frame);
                CvInvoke.CvtColor(frame, frame, ColorConversion.Bgr2Gray);
                Console.WriteLine(Average(frame));
                CvInvoke.Imshow(win1, frame);
            }

            Console.WriteLine(frame.ToString());
        }

        static int Average(Mat frame)
        {
            byte[,] array;
            array = (byte[,])frame.GetData();
            int sum = 0;
            foreach (byte num in array)
            {
                sum += num;
            }
            return sum / array.Length;
        }
    }
}

