using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_cg
{
    public static class Primitives
    {
        public static void WritePixel(Bitmap bitmap, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < bitmap.Width && y < bitmap.Height)
            {
                bitmap.SetPixel(x, y, Color.Black);
            }
        }

        public static void LineEquation(Bitmap bitmap, Point p1, Point p2)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            int dx = x2 - x1;
            int dy = y2 - y1;

            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                if (x1 > x2)
                {
                    (x1, x2) = (x2, x1);
                    (y1, y2) = (y2, y1);
                }

                double m = (double)(y2 - y1) / (x2 - x1);

                double y = y1;

                for (int x = x1; x <= x2; x++)
                {
                    WritePixel(bitmap, x, (int)Math.Round(y));
                    y += m;
                }
            }
            else
            {
                if (y1 > y2)
                {
                    (x1, x2) = (x2, x1);
                    (y1, y2) = (y2, y1);
                }

                double m = (double)(x2 - x1) / (y2 - y1);

                double x = x1;

                for (int y = y1; y <= y2; y++)
                {
                    WritePixel(bitmap, (int)Math.Round(x), y);
                    x += m;
                }
            }
        }

    }
}
