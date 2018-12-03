namespace Lab3DM
{
    partial class Name
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
            this.labelName = new System.Windows.Forms.Label();
            this.panelName = new System.Windows.Forms.Panel();
            this.panelName.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(0, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(226, 25);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Шаблонное название";
            // 
            // panelName
            // 
            this.panelName.AutoSize = true;
            this.panelName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelName.Controls.Add(this.labelName);
            this.panelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(233, 29);
            this.panelName.TabIndex = 1;
            // 
            // Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelName);
            this.Name = "Name";
            this.Size = new System.Drawing.Size(233, 29);
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelName;
    }
}
