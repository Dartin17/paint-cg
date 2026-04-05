using System.ComponentModel;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace paint_cg
{
    public partial class MainForm : Form
    {
        //onde o desenho definitivo é armazenado
        Bitmap canvas;
        //usado para pré visualização
        Bitmap previewCanvas;

        // Controle do modo atual
        ModoAplicativo modoAtual = ModoAplicativo.Primitivas;

        // Estados de desenho de primitivas
        bool freeDrawMode = false;
        bool isDrawingFree = false;
        bool isPreviewingPrimitive = false;
        // Estados de desenho de polígonos
        bool isDrawingPolygon = false;

        // Pontos auxiliares
        private Point startPoint;
        private Point endPoint;
        private Point lastFreeDrawPoint;
        private Point mousePositionPolygon;

        // Estruturas de polígonos
        BindingList<Polygon> polygonList = new BindingList<Polygon>();
        BindingList<PointData> pointList = new BindingList<PointData>();

        private Polygon? currentPolygon = null;
        private Polygon? selectedPolygon = null;

        private int polygonCounter = 0;

        private enum ModoAplicativo
        {
            Primitivas,
            Poligonos
        }

        private bool EstaNoModoPrimitivas => modoAtual == ModoAplicativo.Primitivas;
        private bool EstaNoModoPoligonos => modoAtual == ModoAplicativo.Poligonos;

        private class ReferencePointItem
        {
            public string Text { get; set; }
            public Point Point { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            ConfigureBindings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeCanvas();
            SetModoAplicativo(ModoAplicativo.Primitivas);

            radioButtonPrimitives.Checked = true;
            radioButtonPolygon.Checked = false;
        }

        private void ConfigureBindings()
        {
            dataGridViewPoints.AutoGenerateColumns = true;
            dataGridViewPoints.ReadOnly = true;
            dataGridViewPoints.RowHeadersVisible = false;
            dataGridViewPoints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewPoints.DataSource = pointList;

            listBoxPolygons.DataSource = polygonList;
        }

        private void InitializeCanvas()
        {
            if (panelDraw.Width > 0 && panelDraw.Height > 0)
            {
                canvas?.Dispose();
                canvas = new Bitmap(panelDraw.Width, panelDraw.Height, PixelFormat.Format24bppRgb);

                ClearBitmap(canvas, Color.White);
                panelDraw.Invalidate();
            }
        }

        private void SetModoAplicativo(ModoAplicativo novoModo)
        {
            modoAtual = novoModo;

            if (modoAtual == ModoAplicativo.Primitivas)
            {
                flowLayoutPanelPrimitives.Visible = true;
                flowLayoutPanelPolygon.Visible = false;

                isDrawingPolygon = false;
                currentPolygon = null;
            }
            else
            {
                flowLayoutPanelPrimitives.Visible = false;
                flowLayoutPanelPolygon.Visible = true;

                isDrawingFree = false;
                isPreviewingPrimitive = false;
            }

            ClearPreviewCanvas();
            panelDraw.Invalidate();
        }

        private void UpdatePointsGrid(Polygon polygon)
        {
            if (polygon != null)
            {
                //atualiza os nomes
                for (int i = 0; i < polygon.Points.Count; i++)
                    polygon.Points[i].Nome = $"{GetPolygonLabelFromName(polygon.Name)}{i + 1}";
                
                //atualiza pontos
                pointList = polygon.Points;
                dataGridViewPoints.DataSource = null;
                dataGridViewPoints.DataSource = pointList;
            }
        }

        private void ClearPreviewCanvas()
        {
            if (previewCanvas != null)
            {
                previewCanvas.Dispose();
                previewCanvas = null;
            }
        }

        //===================== Troca de modo ===========================
        private void radioButtonModoAplicativo_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                if (rb == radioButtonPrimitives)
                    SetModoAplicativo(ModoAplicativo.Primitivas);
                else if (rb == radioButtonPolygon)
                    SetModoAplicativo(ModoAplicativo.Poligonos);
            }
        }

        private void checkBoxFreeDraw_CheckedChanged(object sender, EventArgs e)
        {
            freeDrawMode = checkBoxFreeDraw.Checked;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selected = sender as RadioButton;
            if (selected == null || !selected.Checked)
                return;

            foreach (Control control in flowLayoutPanelPrimitives.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    foreach (Control item in groupBox.Controls)
                    {
                        if (item is RadioButton rb && rb != selected)
                            rb.Checked = false;
                    }
                }
            }
        }

        // ============= funções auxiliares =================
        private void PutPixel(Bitmap target, int x, int y, Color color)
        {
            if (x < 0 || x >= target.Width || y < 0 || y >= target.Height)
                return;

            target.SetPixel(x, y, color);
        }

        private void ClearBitmap(Bitmap target, Color color)
        {
            Rectangle rect = new Rectangle(0, 0, target.Width, target.Height);
            BitmapData data = target.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            try
            {
                int stride = data.Stride;
                int bytes = Math.Abs(stride) * target.Height;
                byte[] buffer = new byte[bytes];

                for (int y = 0; y < target.Height; y++)
                {
                    int row = y * stride;

                    for (int x = 0; x < target.Width; x++)
                    {
                        int index = row + x * 3;
                        buffer[index + 0] = color.B;
                        buffer[index + 1] = color.G;
                        buffer[index + 2] = color.R;
                    }
                }

                Marshal.Copy(buffer, 0, data.Scan0, bytes);
            }
            finally
            {
                target.UnlockBits(data);
            }
        }

        private void DrawFreeSegment(Bitmap target, Point p1, Point p2, Color color)
        {
            Primitives.LineMidpoint(target, p1, p2, color);
        }

        private void DrawVertex(Bitmap target, Point point, Color color)
        {
            for (int dx = -3; dx <= 3; dx++)
            {
                for (int dy = -3; dy <= 3; dy++)
                {
                    PutPixel(target, point.X + dx, point.Y + dy, color);
                }
            }
        }

        // ============= Redimensionamento =================

        private void panelDraw_Resize(object sender, EventArgs e)
        {
            if (panelDraw.Width > 0 && panelDraw.Height > 0)
            {
                if (canvas == null)
                    InitializeCanvas();
                else
                {
                    Bitmap newCanvas = new Bitmap(panelDraw.Width, panelDraw.Height, PixelFormat.Format24bppRgb);
                    ClearBitmap(newCanvas, Color.White);

                    CopyBitmapContent(canvas, newCanvas);

                    canvas.Dispose();
                    canvas = newCanvas;

                    ClearPreviewCanvas();
                    panelDraw.Invalidate();
                }
            }
        }

        private void CopyBitmapContent(Bitmap source, Bitmap destination)
        {
            int copyWidth = Math.Min(source.Width, destination.Width);
            int copyHeight = Math.Min(source.Height, destination.Height);

            Rectangle srcRect = new Rectangle(0, 0, source.Width, source.Height);
            Rectangle dstRect = new Rectangle(0, 0, destination.Width, destination.Height);

            BitmapData srcData = source.LockBits(srcRect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dstData = destination.LockBits(dstRect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            try
            {
                int rowBytes = copyWidth * 3;

                for (int y = 0; y < copyHeight; y++)
                {
                    IntPtr srcRow = IntPtr.Add(srcData.Scan0, y * srcData.Stride);
                    IntPtr dstRow = IntPtr.Add(dstData.Scan0, y * dstData.Stride);

                    byte[] rowBuffer = new byte[rowBytes];
                    Marshal.Copy(srcRow, rowBuffer, 0, rowBuffer.Length);
                    Marshal.Copy(rowBuffer, 0, dstRow, rowBuffer.Length);
                }
            }
            finally
            {
                source.UnlockBits(srcData);
                destination.UnlockBits(dstData);
            }
        }

        // ============= Eventos do mouse =================

        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (EstaNoModoPrimitivas)
                HandlePrimitiveMouseDown(e);
            else if (EstaNoModoPoligonos)
                HandlePolygonMouseDown(e);
        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (EstaNoModoPrimitivas)
                HandlePrimitiveMouseMove(e);
            else if (EstaNoModoPoligonos)
                HandlePolygonMouseMove(e);
        }

        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (EstaNoModoPrimitivas)
                HandlePrimitiveMouseUp(e);
            else if (EstaNoModoPoligonos)
                HandlePolygonMouseUp(e);
        }

        // ================== primitivas =========================

        private void HandlePrimitiveMouseDown(MouseEventArgs e)
        {
            if (freeDrawMode)
            {
                isDrawingFree = true;
                lastFreeDrawPoint = e.Location;
                return;
            }
            else
            {
                startPoint = e.Location;
                endPoint = e.Location;
                isPreviewingPrimitive = true;
            }
        }

        private void HandlePrimitiveMouseMove(MouseEventArgs e)
        {
            if (canvas != null)
            {
                if (freeDrawMode)
                {
                    if (isDrawingFree)
                    {
                        DrawFreeSegment(canvas, lastFreeDrawPoint, e.Location, Color.Black);
                        lastFreeDrawPoint = e.Location;
                        panelDraw.Invalidate();
                    }
                }
                else if (isPreviewingPrimitive)
                {
                    endPoint = e.Location;
                    BuildPrimitivePreview();
                    panelDraw.Invalidate();
                }
            }
        }

        private void HandlePrimitiveMouseUp(MouseEventArgs e)
        {
            if (canvas != null)
            {
                if (freeDrawMode)
                {
                    isDrawingFree = false;
                }
                else
                {
                    if (isPreviewingPrimitive)
                    {
                        endPoint = e.Location;
                        isPreviewingPrimitive = false;

                        DrawPrimitive(canvas, Color.Black);
                        ClearPreviewCanvas();

                        panelDraw.Invalidate();
                    }
                }
            }
        }

        private void DrawPrimitive(Bitmap target, Color color)
        {
            if (radioButtonEqReta.Checked)
            {
                Primitives.LineEquation(target, startPoint, endPoint, color);
            }
            else if (radioButtonDDA.Checked)
            {
                Primitives.LineDDA(target, startPoint, endPoint, color);
            }
            else if (radioButtonPontoMedioReta.Checked)
            {
                Primitives.LineMidpoint(target, startPoint, endPoint, color);
            }
            else if (radioButtonEqCircunferencia.Checked)
            {
                Primitives.CircleEquation(target, startPoint, endPoint, color);
            }
            else if (radioButtonTrigonometria.Checked)
            {
                Primitives.CircleTrigonometric(target, startPoint, endPoint, color);
            }
            else if (radioButtonPontoMedioCircunferencia.Checked)
            {
                Primitives.CircleMidpoint(target, startPoint, endPoint, color);
            }
            else if (radioButtonPontoMedioElipse.Checked)
            {
                Primitives.EllipseMidpoint(target, startPoint, endPoint, color);
            }
        }

        private void BuildPrimitivePreview()
        {
            if (canvas != null)
            {
                ClearPreviewCanvas();
                previewCanvas = (Bitmap)canvas.Clone();

                DrawPrimitive(previewCanvas, Color.Gray);
            }
        }

        // ================== polígonos =========================

        private void HandlePolygonMouseDown(MouseEventArgs e)
        {
            if (isDrawingPolygon && currentPolygon != null)
            {
                currentPolygon.Points.Add(new PointData(e.Location));
                UpdatePointsGrid(currentPolygon);
                RefreshTransformationReferencePoints();

                RedrawCanvas();
                BuildPolygonPreview();
                panelDraw.Invalidate();
            }
        }

        private void HandlePolygonMouseMove(MouseEventArgs e)
        {
            mousePositionPolygon = e.Location;

            if (!isDrawingPolygon)
                return;

            BuildPolygonPreview();
            panelDraw.Invalidate();
        }

        private void HandlePolygonMouseUp(MouseEventArgs e)
        {
            if (isDrawingPolygon)
                panelDraw.Invalidate();
        }

        private void DrawPolygon(Bitmap target, Polygon polygon, Color color, bool closePolygon)
        {
            int currentTotalPoints = polygon.Points.Count;

            if (currentTotalPoints > 0)
            {
                for (int i = 0; i < currentTotalPoints; i++)
                {
                    DrawVertex(target, polygon.Points[i].ToPoint(), color);
                }

                for (int i = 0; i < currentTotalPoints - 1; i++)
                {
                    Point p1 = polygon.Points[i].ToPoint();
                    Point p2 = polygon.Points[i + 1].ToPoint();
                    Primitives.LineMidpoint(target, p1, p2, color);
                }

                if (closePolygon && currentTotalPoints >= 3)
                {
                    Point first = polygon.Points[0].ToPoint();
                    Point last = polygon.Points[currentTotalPoints - 1].ToPoint();
                    Primitives.LineMidpoint(target, last, first, color);
                }
            }
        }

        private void RedrawCanvas()
        {
            if (canvas != null)
            {
                ClearBitmap(canvas, Color.White);

                foreach (Polygon polygon in polygonList)
                {
                    Color polygonColor = polygon == selectedPolygon ? Color.Red : Color.Black;
                    bool closePolygon = polygon != currentPolygon || !isDrawingPolygon;

                    DrawPolygon(canvas, polygon, polygonColor, closePolygon);

                    if (polygon.FillColor != null && closePolygon)
                    {
                        if (radioButtonFloodFill.Checked)
                        {
                            Point seed = GetPolygonCenter(polygon);
                            FloodFill(canvas, seed, Color.White, polygon.FillColor.Value);
                        }
                        else
                        {
                            ScanlineFill(canvas, polygon, polygon.FillColor.Value);
                        }
                    }
                }
            }
        }

        private void BuildPolygonPreview()
        {
            if (canvas != null)
            {
                ClearPreviewCanvas();
                previewCanvas = (Bitmap)canvas.Clone();

                if (isDrawingPolygon && currentPolygon != null && currentPolygon.Points.Count > 0)
                {
                    Point lastPoint = currentPolygon.Points[currentPolygon.Points.Count - 1].ToPoint();
                    Primitives.LineMidpoint(previewCanvas, lastPoint, mousePositionPolygon, Color.Gray);
                }
            }
        }

        private void buttonAddPolygon_Click(object sender, EventArgs e)
        {
            if (EstaNoModoPoligonos)
            {
                if (isDrawingPolygon)
                {
                    MessageBox.Show("Feche o polígono atual antes de criar outro.");
                }
                else
                {
                    string polygonLabel = GetPolygonLabel(polygonCounter);
                    polygonCounter++;

                    currentPolygon = new Polygon
                    {
                        Name = $"Polígono {polygonLabel}"
                    };

                    polygonList.Add(currentPolygon);
                    selectedPolygon = currentPolygon;
                    isDrawingPolygon = true;

                    listBoxPolygons.SelectedItem = currentPolygon;
                    UpdatePointsGrid(currentPolygon);
                    RefreshTransformationReferencePoints();

                    RedrawCanvas();
                    ClearPreviewCanvas();
                    panelDraw.Invalidate();
                }
            }
        }
        private void buttonClosePolygon_Click(object sender, EventArgs e)
        {
            if (EstaNoModoPoligonos && isDrawingPolygon && currentPolygon != null)
            {
                if (currentPolygon.Points.Count < 3)
                {
                    MessageBox.Show("Um polígono precisa ter pelo menos 3 pontos.");
                }
                else
                {
                    selectedPolygon = currentPolygon;
                    listBoxPolygons.SelectedItem = currentPolygon;

                    isDrawingPolygon = false;
                    currentPolygon = null;

                    RefreshTransformationReferencePoints();
                    ClearPreviewCanvas();
                    RedrawCanvas();
                    panelDraw.Invalidate();
                }
            }
        }

        private void buttonDeletePolygon_Click(object sender, EventArgs e)
        {
            if (EstaNoModoPoligonos)
            {
                if (listBoxPolygons.SelectedItem is Polygon polygon)
                {
                    if (polygon == currentPolygon)
                    {
                        currentPolygon = null;
                        isDrawingPolygon = false;
                    }

                    polygonList.Remove(polygon);
                    selectedPolygon = null;

                    UpdatePointsGrid(new Polygon());
                    comboBoxScalePoint.Items.Clear();
                    comboBoxRotatePoint.Items.Clear();

                    ClearPreviewCanvas();
                    RedrawCanvas();
                    panelDraw.Invalidate();
                }
            }
        }


        private void listBoxPolygons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isDrawingPolygon && currentPolygon != null)
            {
                listBoxPolygons.SelectedItem = currentPolygon;
            }
            else
            {
                if (listBoxPolygons.SelectedItem is Polygon polygon)
                {
                    selectedPolygon = polygon;
                    UpdatePointsGrid(polygon);
                    RefreshTransformationReferencePoints();

                    RedrawCanvas();
                    ClearPreviewCanvas();
                    panelDraw.Invalidate();
                }
            }
        }

        // =================== nomes e pontos dos poligonos =========================

        private string GetPolygonLabel(int index)
        {
            int repeatCount = (index / 26) + 1;
            int letterIndex = index % 26;

            char letter = (char)('A' + letterIndex);

            return new string(letter, repeatCount);
        }

        private string GetPolygonLabelFromName(string polygonName)
        {
            return polygonName.Replace("Polígono ", "").Trim();
        }

        private Point GetPolygonCenter(Polygon polygon)
        {
            int sumX = 0;
            int sumY = 0;

            for (int i = 0; i < polygon.Points.Count; i++)
            {
                sumX += polygon.Points[i].X;
                sumY += polygon.Points[i].Y;
            }

            int centerX = 0;
            int centerY = 0;

            if (polygon.Points.Count > 0)
            {
                centerX = sumX / polygon.Points.Count;
                centerY = sumY / polygon.Points.Count;
            }

            return new Point(centerX, centerY);
        }

        private void RefreshTransformationReferencePoints()
        {
            int selectedScaleIndex = comboBoxScalePoint.SelectedIndex;
            int selectedRotateIndex = comboBoxRotatePoint.SelectedIndex;

            comboBoxScalePoint.Items.Clear();
            comboBoxRotatePoint.Items.Clear();

            if (selectedPolygon != null)
            {
                string polygonLabel = GetPolygonLabelFromName(selectedPolygon.Name);

                Point center = GetPolygonCenter(selectedPolygon);

                comboBoxScalePoint.Items.Add(new ReferencePointItem
                {
                    Text = "Centro",
                    Point = center
                });

                comboBoxRotatePoint.Items.Add(new ReferencePointItem
                {
                    Text = "Centro",
                    Point = center
                });

                for (int i = 0; i < selectedPolygon.Points.Count; i++)
                {
                    Point point = selectedPolygon.Points[i].ToPoint();
                    string pointName = $"{polygonLabel}{i + 1}";

                    comboBoxScalePoint.Items.Add(new ReferencePointItem
                    {
                        Text = pointName,
                        Point = point
                    });

                    comboBoxRotatePoint.Items.Add(new ReferencePointItem
                    {
                        Text = pointName,
                        Point = point
                    });
                }

                // restaura índice
                if (selectedScaleIndex >= 0 && selectedScaleIndex < comboBoxScalePoint.Items.Count)
                    comboBoxScalePoint.SelectedIndex = selectedScaleIndex;
                else
                    comboBoxScalePoint.SelectedIndex = 0;

                if (selectedRotateIndex >= 0 && selectedRotateIndex < comboBoxRotatePoint.Items.Count)
                    comboBoxRotatePoint.SelectedIndex = selectedRotateIndex;
                else
                    comboBoxRotatePoint.SelectedIndex = 0;
            }
        }


        private Point GetReferencePointFromComboBox(ComboBox comboBox)
        {
            Point referencePoint = new Point(0, 0);

            if (comboBox.SelectedItem is ReferencePointItem item)
            {
                referencePoint = item.Point;
            }

            return referencePoint;
        }

        private bool IsPolygonClosed(Polygon polygon)
        {
            return polygon != currentPolygon || !isDrawingPolygon;
        }

        private void DrawPolygonPointLabels(Graphics g, Polygon polygon, Color color)
        {
            if (polygon.Points.Count > 0)
            {
                string polygonLabel = GetPolygonLabelFromName(polygon.Name);

                using Font font = new Font("Arial", 9, FontStyle.Bold);
                using SolidBrush brush = new SolidBrush(color);

                for (int i = 0; i < polygon.Points.Count; i++)
                {
                    Point point = polygon.Points[i].ToPoint();
                    string pointName = $"{polygonLabel}{i + 1}";

                    g.DrawString(pointName, font, brush, point.X + 8, point.Y - 18);
                }

                Point center = GetPolygonCenter(polygon);

                g.DrawString($"Centro {polygonLabel}", font, brush, center.X + 8, center.Y + 8);

                g.DrawEllipse(Pens.Blue, center.X - 3, center.Y - 3, 6, 6);
            }
        }

        // ================== Paint =========================

        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            if (canvas != null)
            {
                if (previewCanvas != null)
                    e.Graphics.DrawImageUnscaled(previewCanvas, 0, 0);
                else
                    e.Graphics.DrawImageUnscaled(canvas, 0, 0);

                foreach (Polygon polygon in polygonList)
                {
                    if (IsPolygonClosed(polygon))
                    {
                        Color labelColor = polygon == selectedPolygon ? Color.Red : Color.Blue;
                        DrawPolygonPointLabels(e.Graphics, polygon, labelColor);
                    }
                }
            }
        }

        // ================== transformações ======================

        private Point MultiplyPointByMatrix(Point point, double[,] matrix)
        {
            double x = point.X;
            double y = point.Y;
            double w = 1.0;

            double newX = matrix[0, 0] * x + matrix[0, 1] * y + matrix[0, 2] * w;
            double newY = matrix[1, 0] * x + matrix[1, 1] * y + matrix[1, 2] * w;
            double newW = matrix[2, 0] * x + matrix[2, 1] * y + matrix[2, 2] * w;

            if (newW != 0)
            {
                newX = newX / newW;
                newY = newY / newW;
            }

            return new Point((int)Math.Round(newX), (int)Math.Round(newY));
        }

        private double[,] MultiplyMatrices(double[,] a, double[,] b)
        {
            double[,] result = new double[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = 0;

                    for (int k = 0; k < 3; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        private double[,] CreateTranslationMatrix(double tx, double ty)
        {
            return new double[,]
            {
                { 1, 0, tx },
                { 0, 1, ty },
                { 0, 0, 1 }
            };
        }

        private double[,] CreateScaleMatrix(double sx, double sy)
        {
            return new double[,]
            {
                { sx, 0,  0 },
                { 0,  sy, 0 },
                { 0,  0,  1 }
            };
        }

        private double[,] CreateRotationMatrix(double angleDegrees)
        {
            double angleRadians = angleDegrees * Math.PI / 180.0;
            double cos = Math.Cos(angleRadians);
            double sin = Math.Sin(angleRadians);

            return new double[,]
            {
                { cos, -sin, 0 },
                { sin,  cos, 0 },
                { 0,    0,   1 }
            };
        }

        private double[,] CreateReflectionXMatrix()
        {
            return new double[,]
            {
                { 1,  0, 0 },
                { 0, -1, 0 },
                { 0,  0, 1 }
            };
        }

        private double[,] CreateReflectionYMatrix()
        {
            return new double[,]
            {
                { -1, 0, 0 },
                { 0,  1, 0 },
                { 0,  0, 1 }
            };
        }

        private double[,] CreateShearXMatrix(double shx)
        {
            return new double[,]
            {
                { 1, shx, 0 },
                { 0, 1,   0 },
                { 0, 0,   1 }
            };
        }

        private double[,] CreateShearYMatrix(double shy)
        {
            return new double[,]
            {
                { 1,   0, 0 },
                { shy, 1, 0 },
                { 0,   0, 1 }
            };
        }

        private double[,] CreateCompositeMatrixAroundPoint(double[,] transformationMatrix, Point pivot)
        {
            double[,] translateToOrigin = CreateTranslationMatrix(-pivot.X, -pivot.Y);
            double[,] translateBack = CreateTranslationMatrix(pivot.X, pivot.Y);

            double[,] partial = MultiplyMatrices(transformationMatrix, translateToOrigin);
            double[,] composite = MultiplyMatrices(translateBack, partial);

            return composite;
        }

        private void ApplyMatrixToSelectedPolygon(double[,] matrix)
        {
            if (selectedPolygon != null)
            {
                for (int i = 0; i < selectedPolygon.Points.Count; i++)
                {
                    Point originalPoint = selectedPolygon.Points[i].ToPoint();
                    Point transformedPoint = MultiplyPointByMatrix(originalPoint, matrix);

                    selectedPolygon.Points[i].X = transformedPoint.X;
                    selectedPolygon.Points[i].Y = transformedPoint.Y;
                }

                UpdatePointsGrid(selectedPolygon);
                RefreshTransformationReferencePoints();
                ClearPreviewCanvas();
                RedrawCanvas();
                panelDraw.Invalidate();
            }
        }

        private void ExecuteTransformation(double[,] transformationMatrix, bool usePivot, ComboBox? comboBoxPivot = null)
        {
            if (selectedPolygon != null)
            {
                double[,] finalMatrix = transformationMatrix;

                if (usePivot)
                {
                    Point pivot;

                    if (comboBoxPivot != null)
                        pivot = GetReferencePointFromComboBox(comboBoxPivot);
                    else
                        pivot = GetPolygonCenter(selectedPolygon);

                    finalMatrix = CreateCompositeMatrixAroundPoint(transformationMatrix, pivot);
                }

                ApplyMatrixToSelectedPolygon(finalMatrix);
            }
        }

        private void TranslateSelectedPolygon(double tx, double ty)
        {
            double[,] translationMatrix = CreateTranslationMatrix(tx, ty);
            ExecuteTransformation(translationMatrix, false);
        }

        private void ScaleSelectedPolygon(double sx, double sy)
        {
            double[,] scaleMatrix = CreateScaleMatrix(sx, sy);
            ExecuteTransformation(scaleMatrix, true, comboBoxScalePoint);
        }

        private void RotateSelectedPolygon(double angleDegrees)
        {
            double[,] rotationMatrix = CreateRotationMatrix(angleDegrees);
            ExecuteTransformation(rotationMatrix, true, comboBoxRotatePoint);
        }

        private void ReflectSelectedPolygonX()
        {
            double[,] reflectionMatrix = CreateReflectionXMatrix();
            ExecuteTransformation(reflectionMatrix, true);
        }

        private void ReflectSelectedPolygonY()
        {
            double[,] reflectionMatrix = CreateReflectionYMatrix();
            ExecuteTransformation(reflectionMatrix, true);
        }

        private void ShearSelectedPolygonX(double shx)
        {
            double[,] shearMatrix = CreateShearXMatrix(shx);
            ExecuteTransformation(shearMatrix, true);
        }

        private void ShearSelectedPolygonY(double shy)
        {
            double[,] shearMatrix = CreateShearYMatrix(shy);
            ExecuteTransformation(shearMatrix, true);
        }

        private void buttonTranslate_Click(object sender, EventArgs e)
        {
            if (selectedPolygon == null)
            {
                MessageBox.Show("Selecione um polígono.");
            }
            else
            {
                double tx = (double)numericTranslateX.Value;
                double ty = (double)numericTranslateY.Value;

                TranslateSelectedPolygon(tx, ty);
            }
        }

        private void buttonScale_Click(object sender, EventArgs e)
        {
            if (selectedPolygon == null)
            {
                MessageBox.Show("Selecione um polígono.");
            }
            else
            {
                double sx = (double)numericScaleX.Value;
                double sy = (double)numericScaleY.Value;

                ScaleSelectedPolygon(sx, sy);
            }
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            if (selectedPolygon == null)
            {
                MessageBox.Show("Selecione um polígono.");
            }
            else
            {
                double angle = (double)numericAngle.Value;

                RotateSelectedPolygon(angle);
            }
        }

        private void buttonReflectX_Click(object sender, EventArgs e)
        {
            if (selectedPolygon == null)
            {
                MessageBox.Show("Selecione um polígono.");
            }
            else
            {
                ReflectSelectedPolygonX();
            }
        }

        private void buttonReflectY_Click(object sender, EventArgs e)
        {
            if (selectedPolygon == null)
            {
                MessageBox.Show("Selecione um polígono.");
            }
            else
            {
                ReflectSelectedPolygonY();
            }
        }

        private void buttonShearX_Click(object sender, EventArgs e)
        {
            if (selectedPolygon == null)
            {
                MessageBox.Show("Selecione um polígono.");
            }
            else
            {
                double shx = (double)numericShearX.Value;

                ShearSelectedPolygonX(shx);
            }
        }

        private void buttonShearY_Click(object sender, EventArgs e)
        {
            if (selectedPolygon == null)
            {
                MessageBox.Show("Selecione um polígono.");
            }
            else
            {
                double shy = (double)numericShearY.Value;

                ShearSelectedPolygonY(shy);
            }
        }

        private void FloodFill(Bitmap target, Point seed, Color targetColor, Color fillColor)
        {
            int width = target.Width;
            int height = target.Height;

            if (seed.X >= 0 && seed.X < width && seed.Y >= 0 && seed.Y < height)
            {
                Rectangle rect = new Rectangle(0, 0, width, height);
                BitmapData data = target.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = data.Stride;
                byte[] buffer = new byte[Math.Abs(stride) * height];
                Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

                bool IsTarget(int x, int y)
                {
                    int idx = y * stride + x * 3;
                    return buffer[idx] == targetColor.B &&
                           buffer[idx + 1] == targetColor.G &&
                           buffer[idx + 2] == targetColor.R;
                }

                void SetFill(int x, int y)
                {
                    int idx = y * stride + x * 3;
                    buffer[idx] = fillColor.B;
                    buffer[idx + 1] = fillColor.G;
                    buffer[idx + 2] = fillColor.R;
                }

                if (IsTarget(seed.X, seed.Y))
                {
                    Stack<Point> stack = new Stack<Point>();
                    stack.Push(seed);

                    while (stack.Count > 0)
                    {
                        Point p = stack.Pop();
                        int x = p.X, y = p.Y;

                        if (x >= 0 && x < width && y >= 0 && y < height)
                        {
                            if (IsTarget(x, y))
                            {
                                SetFill(x, y);
                                stack.Push(new Point(x + 1, y));
                                stack.Push(new Point(x - 1, y));
                                stack.Push(new Point(x, y + 1));
                                stack.Push(new Point(x, y - 1));
                            }
                        }
                    }

                    Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
                    target.UnlockBits(data);
                }
                else
                {
                    target.UnlockBits(data);
                }
            }
        }

        private void ScanlineFill(Bitmap target, Polygon polygon, Color fillColor)
        {
            int n = polygon.Points.Count;
            int yMinPolygon = polygon.Points.Min(p => p.Y);
            int yMaxPolygon = polygon.Points.Max(p => p.Y);
            Dictionary<int, List<EdgeEntry>> edgeTable = new Dictionary<int, List<EdgeEntry>>();

            for (int i = 0; i < n; i++)
            {
                Point p1 = polygon.Points[i].ToPoint();
                Point p2 = polygon.Points[(i + 1) % n].ToPoint();

                if (p1.Y != p2.Y)
                {
                    if (p1.Y > p2.Y)
                    {
                        (p1, p2) = (p2, p1);
                    }

                    EdgeEntry entry = new EdgeEntry
                    {
                        YMax = p2.Y,
                        X = p1.X,
                        IncrementX = (double)(p2.X - p1.X) / (p2.Y - p1.Y)
                    };

                    if (!edgeTable.ContainsKey(p1.Y))
                        edgeTable[p1.Y] = new List<EdgeEntry>();

                    edgeTable[p1.Y].Add(entry);
                }
            }

            List<EdgeEntry> aet = new List<EdgeEntry>();
            Rectangle rect = new Rectangle(0, 0, target.Width, target.Height);
            BitmapData bmpData = target.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmpData.Stride;
            byte[] buffer = new byte[Math.Abs(stride) * target.Height];
            Marshal.Copy(bmpData.Scan0, buffer, 0, buffer.Length);

            void SetPixel(int x, int y)
            {
                if (x >= 0 && x < target.Width && y >= 0 && y < target.Height)
                {
                    int idx = y * stride + x * 3;
                    buffer[idx] = fillColor.B;
                    buffer[idx + 1] = fillColor.G;
                    buffer[idx + 2] = fillColor.R;
                }
            }

            for (int y = yMinPolygon; y <= yMaxPolygon; y++)
            {
                if (edgeTable.ContainsKey(y))
                    aet.AddRange(edgeTable[y]);

                aet.RemoveAll(e => e.YMax == y);

                aet.Sort((a, b) => a.X.CompareTo(b.X));

                for (int i = 0; i + 1 < aet.Count; i += 2)
                {
                    int xStart = (int)Math.Round(aet[i].X);
                    int xEnd = (int)Math.Round(aet[i + 1].X);

                    for (int x = xStart; x < xEnd; x++)
                        SetPixel(x, y);
                }

                foreach (EdgeEntry edge in aet)
                    edge.X += edge.IncrementX;
            }

            Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);
            target.UnlockBits(bmpData);
        }

        private void buttonPreencher_Click(object sender, EventArgs e)
        {
            if (selectedPolygon == null || selectedPolygon.Points.Count < 3)
            {
                MessageBox.Show("Selecione um polígono fechado.");
            }
            else if (isDrawingPolygon)
            {
                MessageBox.Show("Feche o polígono antes de preencher.");
            }
            else
            {
                Color fillColor = Color.Black;
                selectedPolygon.FillColor = fillColor;
                if (radioButtonFloodFill.Checked)
                {
                    Point seed = GetPolygonCenter(selectedPolygon);
                    FloodFill(canvas, seed, Color.White, fillColor);
                    panelDraw.Invalidate();
                }
                else
                {
                    ScanlineFill(canvas, selectedPolygon, fillColor);
                    panelDraw.Invalidate();
                }
            }
        }

        // ================== Limpar tela =========================

        private void buttonClearWindow_Click(object sender, EventArgs e)
        {
            isDrawingFree = false;
            isPreviewingPrimitive = false;
            isDrawingPolygon = false;

            currentPolygon = null;
            selectedPolygon = null;

            polygonList.Clear();
            UpdatePointsGrid(new Polygon());

            polygonCounter = 0;
            comboBoxScalePoint.Items.Clear();
            comboBoxRotatePoint.Items.Clear();

            ClearPreviewCanvas();

            if (canvas != null)
            {
                ClearBitmap(canvas, Color.White);
            }

            panelDraw.Invalidate();
        }

    }
}