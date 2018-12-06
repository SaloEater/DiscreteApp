namespace Lab3DM
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаИстинностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сДНФToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сКНФToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.карноКНФToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.карноДНФToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьЭлементToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьЭлементToolStripMenuItem
            // 
            this.добавитьЭлементToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаИстинностиToolStripMenuItem,
            this.сДНФToolStripMenuItem,
            this.сКНФToolStripMenuItem,
            this.карноКНФToolStripMenuItem,
            this.карноДНФToolStripMenuItem});
            this.добавитьЭлементToolStripMenuItem.Name = "добавитьЭлементToolStripMenuItem";
            this.добавитьЭлементToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.добавитьЭлементToolStripMenuItem.Text = "Добавить элемент";
            // 
            // таблицаИстинностиToolStripMenuItem
            // 
            this.таблицаИстинностиToolStripMenuItem.Name = "таблицаИстинностиToolStripMenuItem";
            this.таблицаИстинностиToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.таблицаИстинностиToolStripMenuItem.Text = "Таблица истинности";
            this.таблицаИстинностиToolStripMenuItem.Click += new System.EventHandler(this.таблицаИстинностиToolStripMenuItem_Click);
            // 
            // сДНФToolStripMenuItem
            // 
            this.сДНФToolStripMenuItem.Name = "сДНФToolStripMenuItem";
            this.сДНФToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.сДНФToolStripMenuItem.Text = "СДНФ";
            this.сДНФToolStripMenuItem.Click += new System.EventHandler(this.сДНФToolStripMenuItem_Click);
            // 
            // сКНФToolStripMenuItem
            // 
            this.сКНФToolStripMenuItem.Name = "сКНФToolStripMenuItem";
            this.сКНФToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.сКНФToolStripMenuItem.Text = "СКНФ";
            this.сКНФToolStripMenuItem.Click += new System.EventHandler(this.сКНФToolStripMenuItem_Click);
            // 
            // карноКНФToolStripMenuItem
            // 
            this.карноКНФToolStripMenuItem.Name = "карноКНФToolStripMenuItem";
            this.карноКНФToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.карноКНФToolStripMenuItem.Text = "Карно КНФ";
            this.карноКНФToolStripMenuItem.Click += new System.EventHandler(this.карноКНФToolStripMenuItem_Click);
            // 
            // карноДНФToolStripMenuItem
            // 
            this.карноДНФToolStripMenuItem.Name = "карноДНФToolStripMenuItem";
            this.карноДНФToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.карноДНФToolStripMenuItem.Text = "Карно ДНФ";
            this.карноДНФToolStripMenuItem.Click += new System.EventHandler(this.карноДНФToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 426);
            this.tabControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Дискретный модуль";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьЭлементToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаИстинностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сДНФToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сКНФToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem карноКНФToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem карноДНФToolStripMenuItem;
    }
}

