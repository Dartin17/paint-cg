namespace paint_cg
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelDraw = new SoftPanel();
            flowLayoutPanelPolygon = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            listBoxPolygons = new ListBox();
            groupBox4 = new GroupBox();
            button2 = new Button();
            buttonClosePolygon = new Button();
            buttonAddPolygon = new Button();
            groupBox5 = new GroupBox();
            dataGridViewPoints = new DataGridView();
            groupBox6 = new GroupBox();
            label8 = new Label();
            numericShearY = new NumericUpDown();
            numericShearX = new NumericUpDown();
            numericAngle = new NumericUpDown();
            comboBoxScalePoint = new ComboBox();
            comboBoxRotatePoint = new ComboBox();
            numericScaleY = new NumericUpDown();
            numericScaleX = new NumericUpDown();
            numericTranslateY = new NumericUpDown();
            numericTranslateX = new NumericUpDown();
            buttonReflectY = new Button();
            buttonReflectX = new Button();
            buttonShearY = new Button();
            buttonShearX = new Button();
            label7 = new Label();
            label6 = new Label();
            buttonRotate = new Button();
            label5 = new Label();
            buttonScale = new Button();
            label4 = new Label();
            label3 = new Label();
            buttonTranslate = new Button();
            label2 = new Label();
            label1 = new Label();
            groupBox7 = new GroupBox();
            buttonPreencher = new Button();
            radioButtonScanline = new RadioButton();
            radioButtonFloodFill = new RadioButton();
            panelSettings = new Panel();
            buttonClearWindow = new Button();
            groupBoxApppMode = new GroupBox();
            radioButtonPolygon = new RadioButton();
            radioButtonPrimitives = new RadioButton();
            flowLayoutPanelPrimitives = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            radioButtonPontoMedioCircunferencia = new RadioButton();
            radioButtonEqCircunferencia = new RadioButton();
            radioButtonTrigonometria = new RadioButton();
            groupBoxReta = new GroupBox();
            radioButtonPontoMedioReta = new RadioButton();
            radioButtonDDA = new RadioButton();
            radioButtonEqReta = new RadioButton();
            groupBox2 = new GroupBox();
            radioButtonPontoMedioElipse = new RadioButton();
            checkBoxFreeDraw = new CheckBox();
            flowLayoutPanelPolygon.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPoints).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericShearY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericShearX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericScaleY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericScaleX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericTranslateY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericTranslateX).BeginInit();
            groupBox7.SuspendLayout();
            panelSettings.SuspendLayout();
            groupBoxApppMode.SuspendLayout();
            flowLayoutPanelPrimitives.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxReta.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panelDraw
            // 
            panelDraw.BackColor = Color.White;
            panelDraw.Dock = DockStyle.Fill;
            panelDraw.Location = new Point(0, 0);
            panelDraw.Name = "panelDraw";
            panelDraw.Size = new Size(1350, 729);
            panelDraw.TabIndex = 1;
            panelDraw.Tag = "";
            panelDraw.Paint += panelDraw_Paint;
            panelDraw.MouseDown += panelDraw_MouseDown;
            panelDraw.MouseMove += panelDraw_MouseMove;
            panelDraw.MouseUp += panelDraw_MouseUp;
            panelDraw.Resize += panelDraw_Resize;
            // 
            // flowLayoutPanelPolygon
            // 
            flowLayoutPanelPolygon.Controls.Add(groupBox3);
            flowLayoutPanelPolygon.Controls.Add(groupBox4);
            flowLayoutPanelPolygon.Controls.Add(groupBox5);
            flowLayoutPanelPolygon.Controls.Add(groupBox6);
            flowLayoutPanelPolygon.Controls.Add(groupBox7);
            flowLayoutPanelPolygon.Location = new Point(6, 5);
            flowLayoutPanelPolygon.Name = "flowLayoutPanelPolygon";
            flowLayoutPanelPolygon.Size = new Size(1190, 146);
            flowLayoutPanelPolygon.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.Menu;
            groupBox3.BackgroundImageLayout = ImageLayout.None;
            groupBox3.Controls.Add(listBoxPolygons);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(117, 137);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Lista de Polígonos";
            // 
            // listBoxPolygons
            // 
            listBoxPolygons.FormattingEnabled = true;
            listBoxPolygons.ItemHeight = 15;
            listBoxPolygons.Location = new Point(6, 22);
            listBoxPolygons.Name = "listBoxPolygons";
            listBoxPolygons.Size = new Size(105, 109);
            listBoxPolygons.TabIndex = 0;
            listBoxPolygons.SelectedIndexChanged += listBoxPolygons_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = SystemColors.Menu;
            groupBox4.BackgroundImageLayout = ImageLayout.None;
            groupBox4.Controls.Add(button2);
            groupBox4.Controls.Add(buttonClosePolygon);
            groupBox4.Controls.Add(buttonAddPolygon);
            groupBox4.Location = new Point(126, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(136, 137);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Ações com Polígonos";
            // 
            // button2
            // 
            button2.Location = new Point(8, 82);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 2;
            button2.Text = "Excluir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonDeletePolygon_Click;
            // 
            // buttonClosePolygon
            // 
            buttonClosePolygon.Location = new Point(8, 58);
            buttonClosePolygon.Name = "buttonClosePolygon";
            buttonClosePolygon.Size = new Size(121, 23);
            buttonClosePolygon.TabIndex = 1;
            buttonClosePolygon.Text = "Fechar";
            buttonClosePolygon.UseVisualStyleBackColor = true;
            buttonClosePolygon.Click += buttonClosePolygon_Click;
            // 
            // buttonAddPolygon
            // 
            buttonAddPolygon.Location = new Point(8, 35);
            buttonAddPolygon.Name = "buttonAddPolygon";
            buttonAddPolygon.Size = new Size(121, 23);
            buttonAddPolygon.TabIndex = 0;
            buttonAddPolygon.Text = "Adicionar";
            buttonAddPolygon.UseVisualStyleBackColor = true;
            buttonAddPolygon.Click += buttonAddPolygon_Click;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = SystemColors.Menu;
            groupBox5.BackgroundImageLayout = ImageLayout.None;
            groupBox5.Controls.Add(dataGridViewPoints);
            groupBox5.Location = new Point(268, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(267, 137);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "Pontos do Polígono";
            // 
            // dataGridViewPoints
            // 
            dataGridViewPoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPoints.Location = new Point(6, 18);
            dataGridViewPoints.Name = "dataGridViewPoints";
            dataGridViewPoints.RowHeadersWidth = 51;
            dataGridViewPoints.Size = new Size(252, 113);
            dataGridViewPoints.TabIndex = 6;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = SystemColors.Menu;
            groupBox6.BackgroundImageLayout = ImageLayout.None;
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(numericShearY);
            groupBox6.Controls.Add(numericShearX);
            groupBox6.Controls.Add(numericAngle);
            groupBox6.Controls.Add(comboBoxScalePoint);
            groupBox6.Controls.Add(comboBoxRotatePoint);
            groupBox6.Controls.Add(numericScaleY);
            groupBox6.Controls.Add(numericScaleX);
            groupBox6.Controls.Add(numericTranslateY);
            groupBox6.Controls.Add(numericTranslateX);
            groupBox6.Controls.Add(buttonReflectY);
            groupBox6.Controls.Add(buttonReflectX);
            groupBox6.Controls.Add(buttonShearY);
            groupBox6.Controls.Add(buttonShearX);
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(label6);
            groupBox6.Controls.Add(buttonRotate);
            groupBox6.Controls.Add(label5);
            groupBox6.Controls.Add(buttonScale);
            groupBox6.Controls.Add(label4);
            groupBox6.Controls.Add(label3);
            groupBox6.Controls.Add(buttonTranslate);
            groupBox6.Controls.Add(label2);
            groupBox6.Controls.Add(label1);
            groupBox6.Location = new Point(541, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(501, 137);
            groupBox6.TabIndex = 9;
            groupBox6.TabStop = false;
            groupBox6.Text = "Transformações";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(433, 12);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 30;
            label8.Text = "Reflexão";
            // 
            // numericShearY
            // 
            numericShearY.DecimalPlaces = 2;
            numericShearY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericShearY.Location = new Point(328, 108);
            numericShearY.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericShearY.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericShearY.Name = "numericShearY";
            numericShearY.Size = new Size(46, 23);
            numericShearY.TabIndex = 29;
            // 
            // numericShearX
            // 
            numericShearX.DecimalPlaces = 2;
            numericShearX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericShearX.Location = new Point(102, 108);
            numericShearX.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numericShearX.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericShearX.Name = "numericShearX";
            numericShearX.Size = new Size(46, 23);
            numericShearX.TabIndex = 28;
            // 
            // numericAngle
            // 
            numericAngle.Location = new Point(52, 76);
            numericAngle.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericAngle.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericAngle.Name = "numericAngle";
            numericAngle.Size = new Size(46, 23);
            numericAngle.TabIndex = 27;
            // 
            // comboBoxScalePoint
            // 
            comboBoxScalePoint.FormattingEnabled = true;
            comboBoxScalePoint.Location = new Point(159, 50);
            comboBoxScalePoint.Name = "comboBoxScalePoint";
            comboBoxScalePoint.Size = new Size(108, 23);
            comboBoxScalePoint.TabIndex = 26;
            // 
            // comboBoxRotatePoint
            // 
            comboBoxRotatePoint.FormattingEnabled = true;
            comboBoxRotatePoint.Location = new Point(104, 76);
            comboBoxRotatePoint.Name = "comboBoxRotatePoint";
            comboBoxRotatePoint.Size = new Size(108, 23);
            comboBoxRotatePoint.TabIndex = 25;
            // 
            // numericScaleY
            // 
            numericScaleY.DecimalPlaces = 2;
            numericScaleY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericScaleY.Location = new Point(107, 48);
            numericScaleY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericScaleY.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericScaleY.Name = "numericScaleY";
            numericScaleY.Size = new Size(46, 23);
            numericScaleY.TabIndex = 24;
            numericScaleY.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // numericScaleX
            // 
            numericScaleX.DecimalPlaces = 2;
            numericScaleX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericScaleX.Location = new Point(30, 48);
            numericScaleX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericScaleX.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericScaleX.Name = "numericScaleX";
            numericScaleX.Size = new Size(46, 23);
            numericScaleX.TabIndex = 23;
            numericScaleX.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // numericTranslateY
            // 
            numericTranslateY.Location = new Point(107, 22);
            numericTranslateY.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericTranslateY.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericTranslateY.Name = "numericTranslateY";
            numericTranslateY.Size = new Size(46, 23);
            numericTranslateY.TabIndex = 22;
            // 
            // numericTranslateX
            // 
            numericTranslateX.Location = new Point(30, 22);
            numericTranslateX.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericTranslateX.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericTranslateX.Name = "numericTranslateX";
            numericTranslateX.Size = new Size(46, 23);
            numericTranslateX.TabIndex = 21;
            // 
            // buttonReflectY
            // 
            buttonReflectY.Location = new Point(420, 58);
            buttonReflectY.Name = "buttonReflectY";
            buttonReflectY.Size = new Size(75, 23);
            buttonReflectY.TabIndex = 20;
            buttonReflectY.Text = "Refletir Y";
            buttonReflectY.UseVisualStyleBackColor = true;
            buttonReflectY.Click += buttonReflectY_Click;
            // 
            // buttonReflectX
            // 
            buttonReflectX.Location = new Point(420, 30);
            buttonReflectX.Name = "buttonReflectX";
            buttonReflectX.Size = new Size(75, 23);
            buttonReflectX.TabIndex = 19;
            buttonReflectX.Text = "Refletir X";
            buttonReflectX.UseVisualStyleBackColor = true;
            buttonReflectX.Click += buttonReflectX_Click;
            // 
            // buttonShearY
            // 
            buttonShearY.Location = new Point(381, 108);
            buttonShearY.Name = "buttonShearY";
            buttonShearY.Size = new Size(75, 23);
            buttonShearY.TabIndex = 18;
            buttonShearY.Text = "Cisalhar Y";
            buttonShearY.UseVisualStyleBackColor = true;
            buttonShearY.Click += buttonShearY_Click;
            // 
            // buttonShearX
            // 
            buttonShearX.Location = new Point(154, 108);
            buttonShearX.Name = "buttonShearX";
            buttonShearX.Size = new Size(75, 23);
            buttonShearX.TabIndex = 17;
            buttonShearX.Text = "Cisalhar X";
            buttonShearX.UseVisualStyleBackColor = true;
            buttonShearX.Click += buttonShearX_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(235, 110);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 15;
            label7.Text = "Cisalhamento Y";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 110);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 13;
            label6.Text = "Cisalhamento X";
            // 
            // buttonRotate
            // 
            buttonRotate.Location = new Point(218, 75);
            buttonRotate.Name = "buttonRotate";
            buttonRotate.Size = new Size(75, 23);
            buttonRotate.TabIndex = 12;
            buttonRotate.Text = "Rotacionar";
            buttonRotate.UseVisualStyleBackColor = true;
            buttonRotate.Click += buttonRotate_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 79);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 10;
            label5.Text = "Ângulo";
            // 
            // buttonScale
            // 
            buttonScale.Location = new Point(273, 48);
            buttonScale.Name = "buttonScale";
            buttonScale.Size = new Size(75, 23);
            buttonScale.TabIndex = 9;
            buttonScale.Text = "Escalar";
            buttonScale.UseVisualStyleBackColor = true;
            buttonScale.Click += buttonScale_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(82, 52);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 7;
            label4.Text = "Sy";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 50);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 5;
            label3.Text = "Sx";
            // 
            // buttonTranslate
            // 
            buttonTranslate.Location = new Point(159, 24);
            buttonTranslate.Name = "buttonTranslate";
            buttonTranslate.Size = new Size(75, 23);
            buttonTranslate.TabIndex = 4;
            buttonTranslate.Text = "Transladar";
            buttonTranslate.UseVisualStyleBackColor = true;
            buttonTranslate.Click += buttonTranslate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 23);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 2;
            label2.Text = "Ty";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 24);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "Tx";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(buttonPreencher);
            groupBox7.Controls.Add(radioButtonScanline);
            groupBox7.Controls.Add(radioButtonFloodFill);
            groupBox7.Location = new Point(1048, 3);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(131, 137);
            groupBox7.TabIndex = 6;
            groupBox7.TabStop = false;
            groupBox7.Text = "Preenchimento";
            // 
            // buttonPreencher
            // 
            buttonPreencher.Location = new Point(6, 91);
            buttonPreencher.Name = "buttonPreencher";
            buttonPreencher.Size = new Size(119, 23);
            buttonPreencher.TabIndex = 2;
            buttonPreencher.Text = "Preencher";
            buttonPreencher.UseVisualStyleBackColor = true;
            buttonPreencher.Click += buttonPreencher_Click;
            // 
            // radioButtonScanline
            // 
            radioButtonScanline.AutoSize = true;
            radioButtonScanline.Location = new Point(6, 47);
            radioButtonScanline.Name = "radioButtonScanline";
            radioButtonScanline.Size = new Size(69, 19);
            radioButtonScanline.TabIndex = 1;
            radioButtonScanline.TabStop = true;
            radioButtonScanline.Text = "Scanline";
            radioButtonScanline.UseVisualStyleBackColor = true;
            // 
            // radioButtonFloodFill
            // 
            radioButtonFloodFill.AutoSize = true;
            radioButtonFloodFill.Location = new Point(6, 22);
            radioButtonFloodFill.Name = "radioButtonFloodFill";
            radioButtonFloodFill.Size = new Size(73, 19);
            radioButtonFloodFill.TabIndex = 0;
            radioButtonFloodFill.TabStop = true;
            radioButtonFloodFill.Text = "Flood Fill";
            radioButtonFloodFill.UseVisualStyleBackColor = true;
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(buttonClearWindow);
            panelSettings.Controls.Add(flowLayoutPanelPolygon);
            panelSettings.Controls.Add(groupBoxApppMode);
            panelSettings.Controls.Add(flowLayoutPanelPrimitives);
            panelSettings.Dock = DockStyle.Top;
            panelSettings.Location = new Point(0, 0);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(1350, 154);
            panelSettings.TabIndex = 2;
            // 
            // buttonClearWindow
            // 
            buttonClearWindow.Location = new Point(1202, 128);
            buttonClearWindow.Name = "buttonClearWindow";
            buttonClearWindow.Size = new Size(136, 23);
            buttonClearWindow.TabIndex = 5;
            buttonClearWindow.Text = "Limpar Tela";
            buttonClearWindow.UseVisualStyleBackColor = true;
            buttonClearWindow.Click += buttonClearWindow_Click;
            // 
            // groupBoxApppMode
            // 
            groupBoxApppMode.Controls.Add(radioButtonPolygon);
            groupBoxApppMode.Controls.Add(radioButtonPrimitives);
            groupBoxApppMode.Location = new Point(1202, 12);
            groupBoxApppMode.Name = "groupBoxApppMode";
            groupBoxApppMode.Size = new Size(136, 110);
            groupBoxApppMode.TabIndex = 4;
            groupBoxApppMode.TabStop = false;
            groupBoxApppMode.Text = "Modo do Aplicativo";
            // 
            // radioButtonPolygon
            // 
            radioButtonPolygon.AutoSize = true;
            radioButtonPolygon.Location = new Point(6, 43);
            radioButtonPolygon.Name = "radioButtonPolygon";
            radioButtonPolygon.Size = new Size(73, 19);
            radioButtonPolygon.TabIndex = 1;
            radioButtonPolygon.Text = "Polígono";
            radioButtonPolygon.UseVisualStyleBackColor = true;
            radioButtonPolygon.CheckedChanged += radioButtonModoAplicativo_CheckedChanged;
            // 
            // radioButtonPrimitives
            // 
            radioButtonPrimitives.AutoSize = true;
            radioButtonPrimitives.Checked = true;
            radioButtonPrimitives.Location = new Point(6, 18);
            radioButtonPrimitives.Name = "radioButtonPrimitives";
            radioButtonPrimitives.Size = new Size(77, 19);
            radioButtonPrimitives.TabIndex = 0;
            radioButtonPrimitives.TabStop = true;
            radioButtonPrimitives.Text = "Primitivas";
            radioButtonPrimitives.UseVisualStyleBackColor = true;
            radioButtonPrimitives.CheckedChanged += radioButtonModoAplicativo_CheckedChanged;
            // 
            // flowLayoutPanelPrimitives
            // 
            flowLayoutPanelPrimitives.Controls.Add(groupBox1);
            flowLayoutPanelPrimitives.Controls.Add(groupBoxReta);
            flowLayoutPanelPrimitives.Controls.Add(groupBox2);
            flowLayoutPanelPrimitives.Controls.Add(checkBoxFreeDraw);
            flowLayoutPanelPrimitives.Location = new Point(6, 5);
            flowLayoutPanelPrimitives.Name = "flowLayoutPanelPrimitives";
            flowLayoutPanelPrimitives.Size = new Size(878, 146);
            flowLayoutPanelPrimitives.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonPontoMedioCircunferencia);
            groupBox1.Controls.Add(radioButtonEqCircunferencia);
            groupBox1.Controls.Add(radioButtonTrigonometria);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(210, 90);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Métodos de Circunferências";
            // 
            // radioButtonPontoMedioCircunferencia
            // 
            radioButtonPontoMedioCircunferencia.AutoSize = true;
            radioButtonPontoMedioCircunferencia.Location = new Point(6, 62);
            radioButtonPontoMedioCircunferencia.Name = "radioButtonPontoMedioCircunferencia";
            radioButtonPontoMedioCircunferencia.Size = new Size(94, 19);
            radioButtonPontoMedioCircunferencia.TabIndex = 5;
            radioButtonPontoMedioCircunferencia.TabStop = true;
            radioButtonPontoMedioCircunferencia.Text = "Ponto Médio";
            radioButtonPontoMedioCircunferencia.UseVisualStyleBackColor = true;
            radioButtonPontoMedioCircunferencia.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonEqCircunferencia
            // 
            radioButtonEqCircunferencia.AutoSize = true;
            radioButtonEqCircunferencia.Location = new Point(6, 18);
            radioButtonEqCircunferencia.Name = "radioButtonEqCircunferencia";
            radioButtonEqCircunferencia.Size = new Size(166, 19);
            radioButtonEqCircunferencia.TabIndex = 3;
            radioButtonEqCircunferencia.TabStop = true;
            radioButtonEqCircunferencia.Text = "Equação da Circunferência";
            radioButtonEqCircunferencia.UseVisualStyleBackColor = true;
            radioButtonEqCircunferencia.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonTrigonometria
            // 
            radioButtonTrigonometria.AutoSize = true;
            radioButtonTrigonometria.Location = new Point(6, 40);
            radioButtonTrigonometria.Name = "radioButtonTrigonometria";
            radioButtonTrigonometria.Size = new Size(100, 19);
            radioButtonTrigonometria.TabIndex = 4;
            radioButtonTrigonometria.TabStop = true;
            radioButtonTrigonometria.Text = "Trigonometria";
            radioButtonTrigonometria.UseVisualStyleBackColor = true;
            radioButtonTrigonometria.CheckedChanged += radioButton_CheckedChanged;
            // 
            // groupBoxReta
            // 
            groupBoxReta.Controls.Add(radioButtonPontoMedioReta);
            groupBoxReta.Controls.Add(radioButtonDDA);
            groupBoxReta.Controls.Add(radioButtonEqReta);
            groupBoxReta.Location = new Point(219, 3);
            groupBoxReta.Name = "groupBoxReta";
            groupBoxReta.Size = new Size(210, 90);
            groupBoxReta.TabIndex = 0;
            groupBoxReta.TabStop = false;
            groupBoxReta.Text = "Métodos de Retas";
            // 
            // radioButtonPontoMedioReta
            // 
            radioButtonPontoMedioReta.AutoSize = true;
            radioButtonPontoMedioReta.Location = new Point(6, 62);
            radioButtonPontoMedioReta.Name = "radioButtonPontoMedioReta";
            radioButtonPontoMedioReta.Size = new Size(94, 19);
            radioButtonPontoMedioReta.TabIndex = 2;
            radioButtonPontoMedioReta.TabStop = true;
            radioButtonPontoMedioReta.Text = "Ponto Médio";
            radioButtonPontoMedioReta.UseVisualStyleBackColor = true;
            radioButtonPontoMedioReta.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonDDA
            // 
            radioButtonDDA.AutoSize = true;
            radioButtonDDA.Location = new Point(6, 40);
            radioButtonDDA.Name = "radioButtonDDA";
            radioButtonDDA.Size = new Size(49, 19);
            radioButtonDDA.TabIndex = 1;
            radioButtonDDA.TabStop = true;
            radioButtonDDA.Text = "DDA";
            radioButtonDDA.UseVisualStyleBackColor = true;
            radioButtonDDA.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonEqReta
            // 
            radioButtonEqReta.AutoSize = true;
            radioButtonEqReta.Location = new Point(6, 18);
            radioButtonEqReta.Name = "radioButtonEqReta";
            radioButtonEqReta.Size = new Size(112, 19);
            radioButtonEqReta.TabIndex = 0;
            radioButtonEqReta.TabStop = true;
            radioButtonEqReta.Text = "Equação da Reta";
            radioButtonEqReta.UseVisualStyleBackColor = true;
            radioButtonEqReta.CheckedChanged += radioButton_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButtonPontoMedioElipse);
            groupBox2.Location = new Point(435, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(210, 90);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Métodos de Elipses";
            // 
            // radioButtonPontoMedioElipse
            // 
            radioButtonPontoMedioElipse.AutoSize = true;
            radioButtonPontoMedioElipse.Location = new Point(6, 18);
            radioButtonPontoMedioElipse.Name = "radioButtonPontoMedioElipse";
            radioButtonPontoMedioElipse.Size = new Size(94, 19);
            radioButtonPontoMedioElipse.TabIndex = 0;
            radioButtonPontoMedioElipse.TabStop = true;
            radioButtonPontoMedioElipse.Text = "Ponto Médio";
            radioButtonPontoMedioElipse.UseVisualStyleBackColor = true;
            radioButtonPontoMedioElipse.CheckedChanged += radioButton_CheckedChanged;
            // 
            // checkBoxFreeDraw
            // 
            checkBoxFreeDraw.AutoSize = true;
            checkBoxFreeDraw.Location = new Point(651, 3);
            checkBoxFreeDraw.Name = "checkBoxFreeDraw";
            checkBoxFreeDraw.Size = new Size(135, 19);
            checkBoxFreeDraw.TabIndex = 2;
            checkBoxFreeDraw.Text = "Modo Desenho Livre";
            checkBoxFreeDraw.UseVisualStyleBackColor = true;
            checkBoxFreeDraw.CheckedChanged += checkBoxFreeDraw_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(panelSettings);
            Controls.Add(panelDraw);
            Name = "MainForm";
            Text = "Primitivas Gráficas";
            Load += MainForm_Load;
            flowLayoutPanelPolygon.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPoints).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericShearY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericShearX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericScaleY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericScaleX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericTranslateY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericTranslateX).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            panelSettings.ResumeLayout(false);
            groupBoxApppMode.ResumeLayout(false);
            groupBoxApppMode.PerformLayout();
            flowLayoutPanelPrimitives.ResumeLayout(false);
            flowLayoutPanelPrimitives.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxReta.ResumeLayout(false);
            groupBoxReta.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SoftPanel panelDraw;
        private Panel panelSettings;
        private GroupBox groupBoxReta;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private RadioButton radioButtonPontoMedioReta;
        private RadioButton radioButtonDDA;
        private RadioButton radioButtonEqReta;
        private RadioButton radioButtonPontoMedioCircunferencia;
        private RadioButton radioButtonEqCircunferencia;
        private RadioButton radioButtonTrigonometria;
        private RadioButton radioButtonPontoMedioElipse;
        private CheckBox checkBoxFreeDraw;
        private FlowLayoutPanel flowLayoutPanelPrimitives;
        private GroupBox groupBoxApppMode;
        private RadioButton radioButtonPolygon;
        private RadioButton radioButtonPrimitives;
        private FlowLayoutPanel flowLayoutPanelPolygon;
        private ListBox listBoxPolygons;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button button2;
        private Button buttonClosePolygon;
        private Button buttonAddPolygon;
        private DataGridView dataGridViewPoints;
        private Button buttonClearWindow;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Label label1;
        private Label label5;
        private Button buttonScale;
        private Label label4;
        private Label label3;
        private Button buttonTranslate;
        private Label label2;
        private Label label7;
        private Label label6;
        private Button buttonRotate;
        private Button buttonReflectY;
        private Button buttonReflectX;
        private Button buttonShearY;
        private Button buttonShearX;
        private NumericUpDown numericScaleY;
        private NumericUpDown numericScaleX;
        private NumericUpDown numericTranslateY;
        private NumericUpDown numericTranslateX;
        private NumericUpDown numericShearY;
        private NumericUpDown numericShearX;
        private NumericUpDown numericAngle;
        private ComboBox comboBoxScalePoint;
        private ComboBox comboBoxRotatePoint;
        private Label label8;
        private GroupBox groupBox7;
        private RadioButton radioButtonFloodFill;
        private RadioButton radioButtonScanline;
        private Button buttonPreencher;
    }
}
