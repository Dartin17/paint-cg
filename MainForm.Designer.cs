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
            label1 = new Label();
            dataGridViewPoints = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewPoints).BeginInit();
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
            flowLayoutPanelPolygon.Controls.Add(label1);
            flowLayoutPanelPolygon.Controls.Add(dataGridViewPoints);
            flowLayoutPanelPolygon.Location = new Point(6, 5);
            flowLayoutPanelPolygon.Name = "flowLayoutPanelPolygon";
            flowLayoutPanelPolygon.Size = new Size(878, 108);
            flowLayoutPanelPolygon.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.Menu;
            groupBox3.BackgroundImageLayout = ImageLayout.None;
            groupBox3.Controls.Add(listBoxPolygons);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(210, 100);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Lista de Polígonos";
            groupBox3.UseWaitCursor = true;
            // 
            // listBoxPolygons
            // 
            listBoxPolygons.FormattingEnabled = true;
            listBoxPolygons.ItemHeight = 15;
            listBoxPolygons.Location = new Point(6, 22);
            listBoxPolygons.Name = "listBoxPolygons";
            listBoxPolygons.Size = new Size(198, 64);
            listBoxPolygons.TabIndex = 0;
            listBoxPolygons.UseWaitCursor = true;
            listBoxPolygons.SelectedIndexChanged += listBoxPolygons_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = SystemColors.Menu;
            groupBox4.BackgroundImageLayout = ImageLayout.None;
            groupBox4.Controls.Add(button2);
            groupBox4.Controls.Add(buttonClosePolygon);
            groupBox4.Controls.Add(buttonAddPolygon);
            groupBox4.Location = new Point(219, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(210, 100);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Ações com Polígonos";
            groupBox4.UseWaitCursor = true;
            // 
            // button2
            // 
            button2.Location = new Point(45, 69);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 2;
            button2.Text = "Excluir";
            button2.UseVisualStyleBackColor = true;
            button2.UseWaitCursor = true;
            button2.Click += buttonDeletePolygon_Click;
            // 
            // buttonClosePolygon
            // 
            buttonClosePolygon.Location = new Point(45, 45);
            buttonClosePolygon.Name = "buttonClosePolygon";
            buttonClosePolygon.Size = new Size(121, 23);
            buttonClosePolygon.TabIndex = 1;
            buttonClosePolygon.Text = "Fechar";
            buttonClosePolygon.UseVisualStyleBackColor = true;
            buttonClosePolygon.UseWaitCursor = true;
            buttonClosePolygon.Click += buttonClosePolygon_Click;
            // 
            // buttonAddPolygon
            // 
            buttonAddPolygon.Location = new Point(45, 22);
            buttonAddPolygon.Name = "buttonAddPolygon";
            buttonAddPolygon.Size = new Size(121, 23);
            buttonAddPolygon.TabIndex = 0;
            buttonAddPolygon.Text = "Adicionar";
            buttonAddPolygon.UseVisualStyleBackColor = true;
            buttonAddPolygon.UseWaitCursor = true;
            buttonAddPolygon.Click += buttonAddPolygon_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(435, 0);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 7;
            label1.Text = "Pontos do Polígono";
            // 
            // dataGridViewPoints
            // 
            dataGridViewPoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPoints.Location = new Point(553, 3);
            dataGridViewPoints.Name = "dataGridViewPoints";
            dataGridViewPoints.RowHeadersWidth = 51;
            dataGridViewPoints.Size = new Size(293, 100);
            dataGridViewPoints.TabIndex = 6;
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
            panelSettings.Size = new Size(1350, 120);
            panelSettings.TabIndex = 2;
            // 
            // buttonClearWindow
            // 
            buttonClearWindow.Location = new Point(1109, 12);
            buttonClearWindow.Name = "buttonClearWindow";
            buttonClearWindow.Size = new Size(87, 23);
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
            groupBoxApppMode.Size = new Size(136, 90);
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
            flowLayoutPanelPrimitives.Size = new Size(878, 108);
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
            flowLayoutPanelPolygon.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPoints).EndInit();
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
        private Label label1;
        private Button buttonClearWindow;
    }
}
