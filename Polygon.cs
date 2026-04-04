using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace paint_cg
{
    internal class Polygon
    {
        public string Name { get; set; } = "";
        public BindingList<PointData> Points { get; set; } = new BindingList<PointData>();
        public Color? FillColor { get; set; } = null;

        public override string ToString()
        {
            return Name;
        }
    }
}
