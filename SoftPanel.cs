using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint_cg
{
    public class SoftPanel : Panel
    {
        public SoftPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            this.UpdateStyles();
        }
    }
}
