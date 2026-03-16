namespace paint_cg
{
    internal class PointData
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointData() { }

        public PointData(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }
    }
}