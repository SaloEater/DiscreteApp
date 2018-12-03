namespace Lab3DM
{
    partial class SNF
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.header1 = new Lab3DM.Header();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.inputGroupBox1 = new Lab3DM.InputGroupBox();
            this.buttonAnotherSource1 = new Lab3DM.ButtonAnotherSource();
            this.panelMatrix = new System.Windows.Forms.Panel();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.textBoxVars = new System.Windows.Forms.TextBox();
            this.labelVars = new System.Windows.Forms.Label();
            this.groupBoxResult.SuspendLayout();
            this.inputGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(370, 60);
            this.header1.TabIndex = 0;
            this.header1.Title = "Какой-то НФ";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.BackColor = System.Drawing.Color.White;
            this.groupBoxResult.Controls.Add(this.textBoxResult);
            this.groupBoxResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxResult.Location = new System.Drawing.Point(4, 180);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(363, 46);
            this.groupBoxResult.TabIndex = 2;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Результат";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Location = new System.Drawing.Point(6, 19);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(347, 20);
            this.textBoxResult.TabIndex = 0;
            // 
            // inputGroupBox1
            // 
            this.inputGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputGroupBox1.BackColor = System.Drawing.Color.White;
            this.inputGroupBox1.Controls.Add(this.buttonAnotherSource1);
            this.inputGroupBox1.Controls.Add(this.panelMatrix);
            this.inputGroupBox1.Controls.Add(this.buttonBuild);
            this.inputGroupBox1.Controls.Add(this.textBoxVars);
            this.inputGroupBox1.Controls.Add(this.labelVars);
            this.inputGroupBox1.Location = new System.Drawing.Point(4, 67);
            this.inputGroupBox1.Name = "inputGroupBox1";
            this.inputGroupBox1.Size = new System.Drawing.Size(363, 107);
            this.inputGroupBox1.TabIndex = 3;
            this.inputGroupBox1.TabStop = false;
            // 
            // buttonAnotherSource1
            // 
            this.buttonAnotherSource1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnotherSource1.Location = new System.Drawing.Point(332, 10);
            this.buttonAnotherSource1.Name = "buttonAnotherSource1";
            this.buttonAnotherSource1.Size = new System.Drawing.Size(25, 25);
            this.buttonAnotherSource1.TabIndex = 20;
            // 
            // panelMatrix
            // 
            this.panelMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMatrix.AutoScroll = true;
            this.panelMatrix.Location = new System.Drawing.Point(5, 45);
            this.panelMatrix.Name = "panelMatrix";
            this.panelMatrix.Size = new System.Drawing.Size(352, 30);
            this.panelMatrix.TabIndex = 19;
            // 
            // buttonBuild
            // 
            this.buttonBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuild.Location = new System.Drawing.Point(127, 17);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(73, 22);
            this.buttonBuild.TabIndex = 18;
            this.buttonBuild.Text = "Построить";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // textBoxVars
            // 
            this.textBoxVars.Location = new System.Drawing.Point(76, 19);
            this.textBoxVars.Name = "textBoxVars";
            this.textBoxVars.Size = new System.Drawing.Size(45, 20);
            this.textBoxVars.TabIndex = 17;
            // 
            // labelVars
            // 
            this.labelVars.AutoSize = true;
            this.labelVars.Location = new System.Drawing.Point(6, 22);
            this.labelVars.Name = "labelVars";
            this.labelVars.Size = new System.Drawing.Size(73, 13);
            this.labelVars.TabIndex = 16;
            this.labelVars.Text = "Переменные";
            // 
            // SNF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputGroupBox1);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.header1);
            this.Name = "SNF";
            this.Size = new System.Drawing.Size(370, 228);
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.inputGroupBox1.ResumeLayout(false);
            this.inputGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Header header1;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.TextBox textBoxResult;
        private InputGroupBox inputGroupBox1;
        private System.Windows.Forms.Panel panelMatrix;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.TextBox textBoxVars;
        private System.Windows.Forms.Label labelVars;
        private ButtonAnotherSource buttonAnotherSource1;
    }
}
