namespace Lab3DM
{
    partial class Karno
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.inputGroupBox1 = new Lab3DM.InputGroupBox();
            this.buttonAnotherSource1 = new Lab3DM.ButtonAnotherSource();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelWork = new System.Windows.Forms.Panel();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.inputGroupBox1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(470, 58);
            this.header1.TabIndex = 0;
            this.header1.Title = "Карта Карно";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(42, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(416, 20);
            this.textBox1.TabIndex = 2;
            // 
            // inputGroupBox1
            // 
            this.inputGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputGroupBox1.BackColor = System.Drawing.Color.White;
            this.inputGroupBox1.Controls.Add(this.buttonAnotherSource1);
            this.inputGroupBox1.Controls.Add(this.textBox1);
            this.inputGroupBox1.Controls.Add(this.label1);
            this.inputGroupBox1.Location = new System.Drawing.Point(3, 64);
            this.inputGroupBox1.Name = "inputGroupBox1";
            this.inputGroupBox1.Size = new System.Drawing.Size(464, 72);
            this.inputGroupBox1.TabIndex = 8;
            this.inputGroupBox1.TabStop = false;
            // 
            // buttonAnotherSource1
            // 
            this.buttonAnotherSource1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnotherSource1.Location = new System.Drawing.Point(434, 41);
            this.buttonAnotherSource1.Name = "buttonAnotherSource1";
            this.buttonAnotherSource1.Size = new System.Drawing.Size(25, 25);
            this.buttonAnotherSource1.TabIndex = 3;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panelWork);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(4, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 209);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ход работы";
            // 
            // panelWork
            // 
            this.panelWork.AutoScroll = true;
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(3, 16);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(457, 190);
            this.panelWork.TabIndex = 0;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.BackColor = System.Drawing.Color.White;
            this.groupBoxResult.Controls.Add(this.textBoxResult);
            this.groupBoxResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxResult.Location = new System.Drawing.Point(4, 358);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(463, 48);
            this.groupBoxResult.TabIndex = 10;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Результат";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Location = new System.Drawing.Point(7, 20);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(450, 20);
            this.textBoxResult.TabIndex = 0;
            // 
            // Karno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.inputGroupBox1);
            this.Controls.Add(this.header1);
            this.Name = "Karno";
            this.Size = new System.Drawing.Size(470, 409);
            this.inputGroupBox1.ResumeLayout(false);
            this.inputGroupBox1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Header header1;
        private System.Windows.Forms.TextBox textBox1;
        private InputGroupBox inputGroupBox1;
        private System.Windows.Forms.Label label1;
        private ButtonAnotherSource buttonAnotherSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}
