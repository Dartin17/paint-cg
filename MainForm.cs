using System.ComponentModel;

namespace paint_cg
{
    public partial class MainForm : Form
    {
        Bitmap previewCanvas;
        bool isDrawing = false;
        bool freeDrawMode = false;
        bool isPreviewingPrimitive = false;

        private bool EstaNoModoPrimitivas => modoAplicativo == ModoAplicativo.Primitivas;
        private bool EstaNoModoPoligonos => modoAplicativo == ModoAplicativo.Poligonos;

        Point lastPoint, p1, p2;
        Point mousePositionPolygon;

        Bitmap canvas;
        Graphics g;

        Pen pen = new Pen(Color.Black, 2);

        enum ModoAplicativo
        {
            Primitivas,
            Poligonos
        }

        private BindingList<Polygon> polygonList = new BindingList<Polygon>();
        private BindingList<PointData> pointList = new BindingList<PointData>();

        private Polygon? currentPolygon = null;
        private Polygon? selectedPolygon = null;

        private bool isDrawingPolygon = false;
        private int polygonCounter = 1;

        ModoAplicativo modoAplicativo = ModoAplicativo.Primitivas;

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            ConfigureBindings();
        }

        private void ConfigureBindings()
        {
            dataGridViewPoints.AutoGenerateColumns = true;
            dataGridViewPoints.DataSource = pointList;
            dataGridViewPoints.ReadOnly = true;

            listBoxPolygons.DataSource = polygonList;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(panelDraw.Width, panelDraw.Height);
            panelDraw.BackgroundImage = canvas;
            g = Graphics.FromImage(canvas);
            g.Clear(Color.White);

            modoAplicativo = ModoAplicativo.Primitivas;

            radioButtonPrimitives.Checked = true;
            radioButtonPolygon.Checked = false;

            ReagirMudancaModoAplicativo();
        }

        private void radioButtonModoAplicativo_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                if (rb == radioButtonPrimitives)
                    modoAplicativo = ModoAplicativo.Primitivas;
                else if (rb == radioButtonPolygon)
                    modoAplicativo = ModoAplicativo.Poligonos;

                ReagirMudancaModoAplicativo();
            }
        }

        private void ReagirMudancaModoAplicativo()
        {
            switch (modoAplicativo)
            {
                case ModoAplicativo.Primitivas:
                    flowLayoutPanelPrimitives.Visible = true;
                    flowLayoutPanelPolygon.Visible = false;

                    isDrawingPolygon = false;
                    currentPolygon = null;
                    break;

                case ModoAplicativo.Poligonos:
                    flowLayoutPanelPrimitives.Visible = false;
                    flowLayoutPanelPolygon.Visible = true;

                    isDrawing = false;
                    isPreviewingPrimitive = false;
                    break;
            }

            panelDraw.Invalidate();
        }

        private void panelDraw_Resize(object sender, EventArgs e)
        {
            if (panelDraw.Width > 0 && panelDraw.Height > 0)
            {
                if (canvas == null)
                {
                    canvas = new Bitmap(panelDraw.Width, panelDraw.Height);
                    g = Graphics.FromImage(canvas);
                    g.Clear(Color.White);
                    panelDraw.BackgroundImage = canvas;
                }
                else
                {
                    Bitmap novoCanvas = new Bitmap(panelDraw.Width, panelDraw.Height);

                    using (Graphics gNovo = Graphics.FromImage(novoCanvas))
                    {
                        gNovo.Clear(Color.White);
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
            if (e.Button != MouseButtons.Left)
                return;

            if (EstaNoModoPrimitivas)
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
            else if (EstaNoModoPoligonos)
            {
                if (isDrawingPolygon && currentPolygon != null)
                {
                    currentPolygon.Points.Add(new PointData(e.Location));

                    pointList = currentPolygon.Points;
                    dataGridViewPoints.DataSource = null;
                    dataGridViewPoints.DataSource = pointList;

                    panelDraw.Invalidate();
                }
            }
        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (EstaNoModoPrimitivas)
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
            else if (EstaNoModoPoligonos)
            {
                mousePositionPolygon = e.Location;
                panelDraw.Invalidate();
            }
        }

        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (EstaNoModoPrimitivas)
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

        private void DrawPrimitive(Bitmap target, Color color)
        {
            if (!EstaNoModoPrimitivas)
                return;

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


        private void DrawPolygonPreview(Graphics g, Polygon polygon)
        {
            if (polygon.Points.Count == 0)
                return;

            using Bitmap temp = (Bitmap)canvas.Clone();

            for (int i = 0; i < polygon.Points.Count - 1; i++)
            {
                Point a = polygon.Points[i].ToPoint();
                Point b = polygon.Points[i + 1].ToPoint();
                Primitives.LineMidpoint(temp, a, b, Color.Black);
            }

            Point last = polygon.Points[polygon.Points.Count - 1].ToPoint();
            Primitives.LineMidpoint(temp, last, mousePositionPolygon, Color.Gray);

            foreach (var point in polygon.Points)
            {
                Point p = point.ToPoint();
                using Graphics gt = Graphics.FromImage(temp);
                gt.FillEllipse(Brushes.Black, p.X - 3, p.Y - 3, 6, 6);
            }

            g.DrawImageUnscaled(temp, 0, 0);
        }

        private void RedrawCanvas()
        {
            g.Clear(Color.White);

            foreach (var polygon in polygonList)
            {
                Color color = polygon == selectedPolygon ? Color.Blue : Color.Black;

                if (polygon.Points.Count == 1)
                {
                    Point p = polygon.Points[0].ToPoint();
                    g.FillEllipse(color == Color.Blue ? Brushes.Blue : Brushes.Black, p.X - 3, p.Y - 3, 6, 6);
                }
                else
                {
                    for (int i = 0; i < polygon.Points.Count - 1; i++)
                    {
                        Point a = polygon.Points[i].ToPoint();
                        Point b = polygon.Points[i + 1].ToPoint();
                        Primitives.LineMidpoint(canvas, a, b, color);
                    }

                    if (polygon.Points.Count >= 3)
                    {
                        Point first = polygon.Points[0].ToPoint();
                        Point last = polygon.Points[polygon.Points.Count - 1].ToPoint();
                        Primitives.LineMidpoint(canvas, last, first, color);
                    }
                }
            }
        }

        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            if (EstaNoModoPrimitivas)
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
            else if (EstaNoModoPoligonos)
            {
                if (isDrawingPolygon && currentPolygon != null)
                {
                    DrawPolygonPreview(e.Graphics, currentPolygon);
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selected = sender as RadioButton;
            if (selected == null || !selected.Checked)
                return;

            foreach (Control c in flowLayoutPanelPrimitives.Controls)
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

        private void checkBoxFreeDraw_CheckedChanged(object sender, EventArgs e)
        {
            freeDrawMode = checkBoxFreeDraw.Checked;
        }

        private void buttonAddPolygon_Click(object sender, EventArgs e)
        {
            if (!EstaNoModoPoligonos)
                return;

            currentPolygon = new Polygon
            {
                Name = $"Polígono {polygonCounter++}"
            };

            isDrawingPolygon = true;
            selectedPolygon = null;

            pointList = currentPolygon.Points;
            dataGridViewPoints.DataSource = null;
            dataGridViewPoints.DataSource = pointList;

            panelDraw.Invalidate();
        }

        private void buttonClosePolygon_Click(object sender, EventArgs e)
        {
            if (!EstaNoModoPoligonos || !isDrawingPolygon || currentPolygon == null)
                return;

            if (currentPolygon.Points.Count < 3)
            {
                MessageBox.Show("Um polígono precisa ter pelo menos 3 pontos.");
                return;
            }

            polygonList.Add(currentPolygon);
            selectedPolygon = currentPolygon;
            listBoxPolygons.SelectedItem = currentPolygon;

            isDrawingPolygon = false;
            currentPolygon = null;

            RedrawCanvas();
            panelDraw.Invalidate();
        }

        private void buttonDeletePolygon_Click(object sender, EventArgs e)
        {
            if (!EstaNoModoPoligonos)
                return;

            if (listBoxPolygons.SelectedItem is Polygon polygon)
            {
                polygonList.Remove(polygon);
                selectedPolygon = null;

                pointList = new BindingList<PointData>();
                dataGridViewPoints.DataSource = null;
                dataGridViewPoints.DataSource = pointList;

                RedrawCanvas();
                panelDraw.Invalidate();
            }
        }

        private void listBoxPolygons_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (listBoxPolygons.SelectedItem is Polygon polygon)
            {
                selectedPolygon = polygon;
                pointList = polygon.Points;

                dataGridViewPoints.DataSource = null;
                dataGridViewPoints.DataSource = pointList;

                RedrawCanvas();
                panelDraw.Invalidate();
            }
        }

        private void buttonClearWindow_Click(object sender, EventArgs e)
        {
            isDrawing = false;
            isPreviewingPrimitive = false;

            polygonList.Clear();
            currentPolygon = null;
            selectedPolygon = null;
            isDrawingPolygon = false;

            pointList = new BindingList<PointData>();
            dataGridViewPoints.DataSource = null;
            dataGridViewPoints.DataSource = pointList;

            g.Clear(Color.White);
            panelDraw.Invalidate();
        }
    }
}