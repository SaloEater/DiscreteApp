namespace Lab3DM
{
    partial class TruthTable
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.header1 = new Lab3DM.Header();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.panelResult = new System.Windows.Forms.Panel();
            this.inputGroupBox1 = new Lab3DM.InputGroupBox();
            this.groupBoxResult.SuspendLayout();
            this.inputGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(42, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(620, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "01010000110110010010001100010111";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "f(x)=";
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(676, 52);
            this.header1.TabIndex = 6;
            this.header1.Title = "Таблица истинности";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.AutoSize = true;
            this.groupBoxResult.BackColor = System.Drawing.SystemColors.HighlightText;
            this.groupBoxResult.Controls.Add(this.panelResult);
            this.groupBoxResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxResult.Location = new System.Drawing.Point(3, 136);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(668, 98);
            this.groupBoxResult.TabIndex = 3;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Результат";
            // 
            // panelResult
            // 
            this.panelResult.AutoScroll = true;
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResult.Location = new System.Drawing.Point(3, 16);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(662, 79);
            this.panelResult.TabIndex = 0;
            // 
            // inputGroupBox1
            // 
            this.inputGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputGroupBox1.BackColor = System.Drawing.Color.White;
            this.inputGroupBox1.Controls.Add(this.textBox1);
            this.inputGroupBox1.Controls.Add(this.label1);
            this.inputGroupBox1.Location = new System.Drawing.Point(3, 58);
            this.inputGroupBox1.Name = "inputGroupBox1";
            this.inputGroupBox1.Size = new System.Drawing.Size(668, 72);
            this.inputGroupBox1.TabIndex = 7;
            this.inputGroupBox1.TabStop = false;
            // 
            // TruthTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.inputGroupBox1);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.header1);
            this.Name = "TruthTable";
            this.Size = new System.Drawing.Size(676, 237);
            this.groupBoxResult.ResumeLayout(false);
            this.inputGroupBox1.ResumeLayout(false);
            this.inputGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Header header1;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelResult;
        private InputGroupBox inputGroupBox1;
    }
}
