namespace paint_cg
{
    public partial class MainForm : Form
    {
        bool isDrawing = false;
        Point lastPoint;
        Bitmap canvas;
        Graphics g;

        Pen pen = new Pen(Color.Black, 2);


        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(panelDraw.Width, panelDraw.Height);
            panelDraw.BackgroundImage = canvas;
            g = Graphics.FromImage(canvas);
        }

        private void panelDraw_Resize(object sender, EventArgs e)
        {
            if (panelDraw.Width > 0 && panelDraw.Height > 0)
            {
                if(canvas == null)
                {
                    canvas = new Bitmap(panelDraw.Width, panelDraw.Height);
                    g = Graphics.FromImage(canvas);
                    panelDraw.BackgroundImage = canvas;
                }
                else
                {
                    Bitmap novoCanvas = new Bitmap(panelDraw.Width, panelDraw.Height);
                    using (Graphics gNovo = Graphics.FromImage(novoCanvas))
                    {
                        gNovo.DrawImageUnscaled(canvas, 0, 0);
                    }

                    // libera recursos antigos
                    g?.Dispose();
                    canvas.Dispose();

                    canvas = novoCanvas;
                    g = Graphics.FromImage(canvas);
                    panelDraw.BackgroundImage = canvas;
                    panelDraw.Invalidate();
                }


            }
        }


        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
            }
        }


        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                g.DrawLine(pen, lastPoint, e.Location);
                lastPoint = e.Location;
                panelDraw.Invalidate();
            }
        }


        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }
    }
}
