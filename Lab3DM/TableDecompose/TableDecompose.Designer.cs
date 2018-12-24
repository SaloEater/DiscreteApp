namespace Lab3DM
{
    partial class TableDecompose
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelWork = new System.Windows.Forms.Panel();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.inputGroupBox1 = new Lab3DM.InputGroupBox();
            this.panelInput = new System.Windows.Forms.Panel();
            this.checkBoxNames = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxTables = new System.Windows.Forms.TextBox();
            this.textBoxRows = new System.Windows.Forms.TextBox();
            this.labelTables = new System.Windows.Forms.Label();
            this.labelRows = new System.Windows.Forms.Label();
            this.buttonAnotherSource1 = new Lab3DM.ButtonAnotherSource();
            this.groupBox1.SuspendLayout();
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
            this.header1.Size = new System.Drawing.Size(662, 58);
            this.header1.TabIndex = 0;
            this.header1.Title = "Таблица покрытий";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panelWork);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(4, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 351);
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
            this.panelWork.Size = new System.Drawing.Size(649, 332);
            this.panelWork.TabIndex = 0;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.BackColor = System.Drawing.Color.White;
            this.groupBoxResult.Controls.Add(this.textBoxResult);
            this.groupBoxResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxResult.Location = new System.Drawing.Point(4, 584);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(655, 48);
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
            this.textBoxResult.Size = new System.Drawing.Size(642, 20);
            this.textBoxResult.TabIndex = 0;
            // 
            // inputGroupBox1
            // 
            this.inputGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputGroupBox1.BackColor = System.Drawing.Color.White;
            this.inputGroupBox1.Controls.Add(this.panelInput);
            this.inputGroupBox1.Controls.Add(this.checkBoxNames);
            this.inputGroupBox1.Controls.Add(this.button1);
            this.inputGroupBox1.Controls.Add(this.textBoxTables);
            this.inputGroupBox1.Controls.Add(this.textBoxRows);
            this.inputGroupBox1.Controls.Add(this.labelTables);
            this.inputGroupBox1.Controls.Add(this.labelRows);
            this.inputGroupBox1.Controls.Add(this.buttonAnotherSource1);
            this.inputGroupBox1.Location = new System.Drawing.Point(4, 65);
            this.inputGroupBox1.Name = "inputGroupBox1";
            this.inputGroupBox1.Size = new System.Drawing.Size(649, 156);
            this.inputGroupBox1.TabIndex = 11;
            this.inputGroupBox1.TabStop = false;
            // 
            // panelInput
            // 
            this.panelInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInput.AutoScroll = true;
            this.panelInput.BackColor = System.Drawing.Color.Transparent;
            this.panelInput.Location = new System.Drawing.Point(10, 46);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(633, 78);
            this.panelInput.TabIndex = 8;
            // 
            // checkBoxNames
            // 
            this.checkBoxNames.AutoSize = true;
            this.checkBoxNames.Location = new System.Drawing.Point(194, 20);
            this.checkBoxNames.Name = "checkBoxNames";
            this.checkBoxNames.Size = new System.Drawing.Size(102, 17);
            this.checkBoxNames.TabIndex = 7;
            this.checkBoxNames.Text = "Наименования";
            this.checkBoxNames.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxTables
            // 
            this.textBoxTables.Location = new System.Drawing.Point(152, 17);
            this.textBoxTables.Name = "textBoxTables";
            this.textBoxTables.Size = new System.Drawing.Size(35, 20);
            this.textBoxTables.TabIndex = 5;
            // 
            // textBoxRows
            // 
            this.textBoxRows.Location = new System.Drawing.Point(50, 17);
            this.textBoxRows.Name = "textBoxRows";
            this.textBoxRows.Size = new System.Drawing.Size(35, 20);
            this.textBoxRows.TabIndex = 4;
            // 
            // labelTables
            // 
            this.labelTables.AutoSize = true;
            this.labelTables.Location = new System.Drawing.Point(91, 20);
            this.labelTables.Name = "labelTables";
            this.labelTables.Size = new System.Drawing.Size(55, 13);
            this.labelTables.TabIndex = 3;
            this.labelTables.Text = "Столбцов";
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(7, 20);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(37, 13);
            this.labelRows.TabIndex = 2;
            this.labelRows.Text = "Строк";
            // 
            // buttonAnotherSource1
            // 
            this.buttonAnotherSource1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnotherSource1.Location = new System.Drawing.Point(618, 12);
            this.buttonAnotherSource1.Name = "buttonAnotherSource1";
            this.buttonAnotherSource1.Size = new System.Drawing.Size(25, 25);
            this.buttonAnotherSource1.TabIndex = 1;
            // 
            // TableDecompose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputGroupBox1);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.header1);
            this.Name = "TableDecompose";
            this.Size = new System.Drawing.Size(662, 635);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.inputGroupBox1.ResumeLayout(false);
            this.inputGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Header header1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Panel panelWork;
        private System.Windows.Forms.TextBox textBoxResult;
        private InputGroupBox inputGroupBox1;
        private ButtonAnotherSource buttonAnotherSource1;
        private System.Windows.Forms.Label labelTables;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.TextBox textBoxTables;
        private System.Windows.Forms.TextBox textBoxRows;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxNames;
        private System.Windows.Forms.Panel panelInput;
    }
}
