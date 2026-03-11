namespace paint_cg
{
    public partial class MainForm : Form
    {
        bool isDrawing = false;
        bool freeDrawMode = false;
        bool firstClick = true;
        Point lastPoint, p1, p2;
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
                if (canvas == null)
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
            if (freeDrawMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDrawing = true;
                    lastPoint = e.Location;
                }
            } else
            {
                if (firstClick)
                {
                    p1 = e.Location;
                    firstClick = false;
                } else
                {
                    p2 = e.Location;
                    firstClick = true;

                    DrawPrimitive();
                }
            }
        }

        private void DrawPrimitive()
        {
            if (radioButtonEqReta.Checked)
            {
                Primitives.LineEquation(canvas, p1, p2);
            }

            panelDraw.Invalidate();
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

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selected = sender as RadioButton;
            if (selected.Checked)
            {
                foreach (Control c in panelSettings.Controls)
                {
                    if (c is GroupBox group)
                    {
                        foreach (Control r in group.Controls)
                        {
                            if (r is RadioButton rb && rb != selected)
                                rb.Checked = false;
                        }
                    }
                }
            }
        }

        private void checkBoxFreeDraw_CheckedChanged(object sender, EventArgs e)
        {
            freeDrawMode = checkBoxFreeDraw.Checked;
        }
    }
}
