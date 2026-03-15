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
            panelSettings = new Panel();
            checkBoxFreeDraw = new CheckBox();
            groupBox2 = new GroupBox();
            radioButtonPontoMedioElipse = new RadioButton();
            groupBox1 = new GroupBox();
            radioButtonPontoMedioCircunferencia = new RadioButton();
            radioButtonEqCircunferencia = new RadioButton();
            radioButtonTrigonometria = new RadioButton();
            groupBoxReta = new GroupBox();
            radioButtonPontoMedioReta = new RadioButton();
            radioButtonDDA = new RadioButton();
            radioButtonEqReta = new RadioButton();
            panelSettings.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxReta.SuspendLayout();
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
            // panelSettings
            // 
            panelSettings.Controls.Add(checkBoxFreeDraw);
            panelSettings.Controls.Add(groupBox2);
            panelSettings.Controls.Add(groupBox1);
            panelSettings.Controls.Add(groupBoxReta);
            panelSettings.Dock = DockStyle.Top;
            panelSettings.Location = new Point(0, 0);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(1350, 120);
            panelSettings.TabIndex = 2;
            // 
            // checkBoxFreeDraw
            // 
            checkBoxFreeDraw.AutoSize = true;
            checkBoxFreeDraw.Location = new Point(663, 33);
            checkBoxFreeDraw.Name = "checkBoxFreeDraw";
            checkBoxFreeDraw.Size = new Size(135, 19);
            checkBoxFreeDraw.TabIndex = 2;
            checkBoxFreeDraw.Text = "Modo Desenho Livre";
            checkBoxFreeDraw.UseVisualStyleBackColor = true;
            checkBoxFreeDraw.CheckedChanged += checkBoxFreeDraw_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButtonPontoMedioElipse);
            groupBox2.Location = new Point(447, 15);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonPontoMedioCircunferencia);
            groupBox1.Controls.Add(radioButtonEqCircunferencia);
            groupBox1.Controls.Add(radioButtonTrigonometria);
            groupBox1.Location = new Point(231, 15);
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
            groupBoxReta.Location = new Point(15, 15);
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
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxReta.ResumeLayout(false);
            groupBoxReta.PerformLayout();
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
    }
}
