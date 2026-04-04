using System.Drawing.Imaging;

namespace paint_cg
{
    public static class Primitives
    {
        public static unsafe void WritePixel(Bitmap bitmap, int x, int y, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                byte* scan0 = (byte*)data.Scan0;
                int stride = data.Stride;

                SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x, y, color);
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        // ========== Equações para retas ==========
        public static unsafe void LineEquation(Bitmap bitmap, Point p1, Point p2, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                byte* scan0 = (byte*)data.Scan0;
                int stride = data.Stride;

                int x1 = p1.X;
                int y1 = p1.Y;
                int x2 = p2.X;
                int y2 = p2.Y;

                int dx = x2 - x1;
                int dy = y2 - y1;

                if (dx == 0 && dy == 0)
                {
                    SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x1, y1, color);
                    return;
                }

                if (Math.Abs(dx) >= Math.Abs(dy))
                {
                    if (x1 > x2)
                    {
                        (x1, x2) = (x2, x1);
                        (y1, y2) = (y2, y1);
                    }

                    if (x2 == x1)
                    {
                        SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x1, y1, color);
                        return;
                    }

                    double m = (double)(y2 - y1) / (x2 - x1);
                    double y = y1;

                    for (int x = x1; x <= x2; x++)
                    {
                        SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x, (int)Math.Round(y), color);
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

                    if (y2 == y1)
                    {
                        SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x1, y1, color);
                        return;
                    }

                    double m = (double)(x2 - x1) / (y2 - y1);
                    double x = x1;

                    for (int y = y1; y <= y2; y++)
                    {
                        SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, (int)Math.Round(x), y, color);
                        x += m;
                    }
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        public static unsafe void LineDDA(Bitmap bitmap, Point p1, Point p2, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                byte* scan0 = (byte*)data.Scan0;
                int stride = data.Stride;

                int x1 = p1.X;
                int y1 = p1.Y;
                int x2 = p2.X;
                int y2 = p2.Y;

                int dx = x2 - x1;
                int dy = y2 - y1;

                int passos = Math.Max(Math.Abs(dx), Math.Abs(dy));

                if (passos == 0)
                {
                    SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x1, y1, color);
                    return;
                }

                float incrementoX = dx / (float)passos;
                float incrementoY = dy / (float)passos;

                float x = x1;
                float y = y1;

                for (int i = 0; i <= passos; i++)
                {
                    SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height,
                        (int)Math.Round(x), (int)Math.Round(y), color);

                    x += incrementoX;
                    y += incrementoY;
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        public static unsafe void LineMidpoint(Bitmap bitmap, Point p1, Point p2, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                byte* scan0 = (byte*)data.Scan0;
                int stride = data.Stride;

                int x1 = p1.X;
                int y1 = p1.Y;
                int x2 = p2.X;
                int y2 = p2.Y;

                int dx = x2 - x1;
                int dy = y2 - y1;

                int passoX = 1;
                int passoY = 1;

                if (dx < 0)
                {
                    passoX = -1;
                    dx = -dx;
                }

                if (dy < 0)
                {
                    passoY = -1;
                    dy = -dy;
                }

                int x = x1;
                int y = y1;

                if (dx >= dy)
                {
                    int d = 2 * dy - dx;
                    int incE = 2 * dy;
                    int incNE = 2 * (dy - dx);

                    for (int i = 0; i <= dx; i++)
                    {
                        SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x, y, color);

                        if (d < 0)
                        {
                            d += incE;
                        }
                        else
                        {
                            d += incNE;
                            y += passoY;
                        }

                        x += passoX;
                    }
                }
                else
                {
                    int d = 2 * dx - dy;
                    int incE = 2 * dx;
                    int incNE = 2 * (dx - dy);

                    for (int i = 0; i <= dy; i++)
                    {
                        SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x, y, color);

                        if (d < 0)
                        {
                            d += incE;
                        }
                        else
                        {
                            d += incNE;
                            x += passoX;
                        }

                        y += passoY;
                    }
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        // ========== Equações da circunferência ==========
        public static unsafe void CircleEquation(Bitmap bitmap, Point centro, Point pf, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                byte* scan0 = (byte*)data.Scan0;
                int stride = data.Stride;

                int xc = centro.X;
                int yc = centro.Y;

                int dx = pf.X - xc;
                int dy = pf.Y - yc;

                int raio = (int)Math.Sqrt(dx * dx + dy * dy);
                double limite = raio / Math.Sqrt(2.0);

                for (int x = 0; x <= (int)limite; x++)
                {
                    double valor = raio * raio - x * x;
                    int y = (int)Math.Round(Math.Sqrt(valor));

                    PlotCirclePoints(scan0, stride, bitmap.Width, bitmap.Height, xc, yc, x, y, color);
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        public static unsafe void CircleTrigonometric(Bitmap bitmap, Point centro, Point pf, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                byte* scan0 = (byte*)data.Scan0;
                int stride = data.Stride;

                int xc = centro.X;
                int yc = centro.Y;

                int dx = pf.X - xc;
                int dy = pf.Y - yc;

                int raio = (int)Math.Sqrt(dx * dx + dy * dy);

                if (raio > 0)
                {
                    double passoAngulo = 1.0 / raio;

                    for (double angulo = 0; angulo <= 2 * Math.PI; angulo += passoAngulo)
                    {
                        int x = xc + (int)Math.Round(raio * Math.Cos(angulo));
                        int y = yc + (int)Math.Round(raio * Math.Sin(angulo));

                        SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, x, y, color);
                    }
                }
                else
                {
                    SetPixelSafe(scan0, stride, bitmap.Width, bitmap.Height, xc, yc, color);
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        public static unsafe void CircleMidpoint(Bitmap bitmap, Point centro, Point pf, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                byte* scan0 = (byte*)data.Scan0;
                int stride = data.Stride;

                int xc = centro.X;
                int yc = centro.Y;

                int deltaX = pf.X - xc;
                int deltaY = pf.Y - yc;

                int raio = (int)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

                int x = 0;
                int y = raio;
                int decisao = 1 - raio;

                PlotCirclePoints(scan0, stride, bitmap.Width, bitmap.Height, xc, yc, x, y, color);

                while (x < y)
                {
                    x++;

                    if (decisao < 0)
                    {
                        decisao += (2 * x) + 1;
                    }
                    else
                    {
                        y--;
                        decisao += (2 * x) - (2 * y) + 1;
                    }

                    PlotCirclePoints(scan0, stride, bitmap.Width, bitmap.Height, xc, yc, x, y, color);
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        // ========== Equações da elipse ==========
        public static unsafe void EllipseMidpoint(Bitmap bitmap, Point centro, Point pf, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                byte* scan0 = (byte*)data.Scan0;
                int stride = data.Stride;

                long xc = centro.X;
                long yc = centro.Y;

                long a = Math.Abs(pf.X - xc);
                long b = Math.Abs(pf.Y - yc);

                long a2 = a * a;
                long b2 = b * b;

                long x = 0;
                long y = b;

                double d1 = b2 - (a2 * b) + (a2 / 4.0);
                double dx = 2 * b2 * x;
                double dy = 2 * a2 * y;

                PlotEllipsePoints(scan0, stride, bitmap.Width, bitmap.Height, xc, yc, x, y, color);

                while (dx < dy)
                {
                    x++;
                    dx += 2 * b2;

                    if (d1 < 0)
                    {
                        d1 += dx + b2;
                    }
                    else
                    {
                        y--;
                        dy -= 2 * a2;
                        d1 += dx - dy + b2;
                    }

                    PlotEllipsePoints(scan0, stride, bitmap.Width, bitmap.Height, xc, yc, x, y, color);
                }

                double d2 = (b2 * Math.Pow(x + 0.5, 2)) +
                            (a2 * Math.Pow(y - 1, 2)) -
                            (a2 * b2);

                while (y >= 0)
                {
                    y--;
                    dy -= 2 * a2;

                    if (d2 > 0)
                    {
                        d2 += a2 - dy;
                    }
                    else
                    {
                        x++;
                        dx += 2 * b2;
                        d2 += dx - dy + a2;
                    }

                    PlotEllipsePoints(scan0, stride, bitmap.Width, bitmap.Height, xc, yc, x, y, color);
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
        }

        // ========== Funções auxiliares ==========
        private static unsafe void SetPixelSafe(byte* scan0, int stride, int width, int height, int x, int y, Color color)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
                return;

            byte* pixel = scan0 + (y * stride) + (x * 3);

            pixel[0] = color.B;
            pixel[1] = color.G;
            pixel[2] = color.R;
        }

        private static unsafe void PlotCirclePoints(byte* scan0, int stride, int width, int height,
            int xc, int yc, int x, int y, Color color)
        {
            SetPixelSafe(scan0, stride, width, height, xc + x, yc + y, color);
            SetPixelSafe(scan0, stride, width, height, xc + y, yc + x, color);
            SetPixelSafe(scan0, stride, width, height, xc + y, yc - x, color);
            SetPixelSafe(scan0, stride, width, height, xc + x, yc - y, color);
            SetPixelSafe(scan0, stride, width, height, xc - x, yc - y, color);
            SetPixelSafe(scan0, stride, width, height, xc - y, yc - x, color);
            SetPixelSafe(scan0, stride, width, height, xc - y, yc + x, color);
            SetPixelSafe(scan0, stride, width, height, xc - x, yc + y, color);
        }

        private static unsafe void PlotEllipsePoints(byte* scan0, int stride, int width, int height,
            long xc, long yc, long x, long y, Color color)
        {
            SetPixelSafe(scan0, stride, width, height, (int)(xc + x), (int)(yc + y), color);
            SetPixelSafe(scan0, stride, width, height, (int)(xc - x), (int)(yc + y), color);
            SetPixelSafe(scan0, stride, width, height, (int)(xc + x), (int)(yc - y), color);
            SetPixelSafe(scan0, stride, width, height, (int)(xc - x), (int)(yc - y), color);
        }
    }
}