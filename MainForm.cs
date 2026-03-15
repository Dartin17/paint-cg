namespace paint_cg
{
    public partial class MainForm : Form
    {
        Bitmap previewCanvas;
        bool isDrawing = false;
        bool freeDrawMode = false;
        bool isPreviewingPrimitive = false;

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
            if (e.Button == MouseButtons.Left)
            {
                if (freeDrawMode)
                {
                    isDrawing = true;
                    lastPoint = e.Location;
                }
                else
                {
                    p1 = e.Location;
                    p2 = e.Location;
                    isPreviewingPrimitive = true;
                }
            }
        }

        private void DrawPrimitive(Bitmap target, Color color)
        {
            if (radioButtonEqReta.Checked)
            {
                Primitives.LineEquation(target, p1, p2, color);
            }
            else if (radioButtonDDA.Checked)
            {
                Primitives.LineDDA(target, p1, p2, color);
            }
            else if (radioButtonPontoMedioReta.Checked)
            {
                Primitives.LineMidpoint(target, p1, p2, color);
            }
            else if (radioButtonEqCircunferencia.Checked)
            {
                Primitives.CircleEquation(target, p1, p2, color);
            }
            else if (radioButtonTrigonometria.Checked)
            {
                Primitives.CircleTrigonometric(target, p1, p2, color);
            }
            else if (radioButtonPontoMedioCircunferencia.Checked)
            {
                Primitives.CircleMidpoint(target, p1, p2, color);
            }
            else if (radioButtonPontoMedioElipse.Checked)
            {
                Primitives.EllipseMidpoint(target, p1, p2, color);
            }
        }


        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (freeDrawMode)
            {
                if (isDrawing)
                {
                    g.DrawLine(pen, lastPoint, e.Location);
                    lastPoint = e.Location;
                    panelDraw.Invalidate();
                }
            }
            else
            {
                if (isPreviewingPrimitive)
                {
                    p2 = e.Location;
                    panelDraw.Invalidate();
                }
            }
        }


        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (freeDrawMode)
                {
                    isDrawing = false;
                }
                else
                {
                    if (isPreviewingPrimitive)
                    {
                        p2 = e.Location;
                        isPreviewingPrimitive = false;

                        DrawPrimitive(canvas, Color.Black);

                        if (previewCanvas != null)
                        {
                            previewCanvas.Dispose();
                            previewCanvas = null;
                        }

                        panelDraw.Invalidate();
                    }
                }
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

        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            if (!freeDrawMode && isPreviewingPrimitive)
            {
                if (previewCanvas != null)
                {
                    previewCanvas.Dispose();
                    previewCanvas = null;
                }

                previewCanvas = (Bitmap)canvas.Clone();
                DrawPrimitive(previewCanvas, Color.Gray);
                e.Graphics.DrawImageUnscaled(previewCanvas, 0, 0);
            }
        }
    }
}
