namespace Server
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
            if (disposing && (components != null))
            {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SignButton = new System.Windows.Forms.Button();
            this.UserButton = new System.Windows.Forms.Button();
            this.MessageButton = new System.Windows.Forms.Button();
            this.LogSafe = new System.Windows.Forms.Button();
            this.CategoryButton = new System.Windows.Forms.Button();
            this.SQLButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(447, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(341, 426);
            this.textBox1.TabIndex = 1;
            // 
            // SignButton
            // 
            this.SignButton.Location = new System.Drawing.Point(13, 13);
            this.SignButton.Name = "SignButton";
            this.SignButton.Size = new System.Drawing.Size(182, 35);
            this.SignButton.TabIndex = 2;
            this.SignButton.Text = "Просмотр и редактирование объявлений";
            this.SignButton.UseVisualStyleBackColor = true;
            // 
            // UserButton
            // 
            this.UserButton.Location = new System.Drawing.Point(12, 54);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(183, 36);
            this.UserButton.TabIndex = 3;
            this.UserButton.Text = "Просмотр и редактирование пользователей";
            this.UserButton.UseVisualStyleBackColor = true;
            // 
            // MessageButton
            // 
            this.MessageButton.Location = new System.Drawing.Point(12, 96);
            this.MessageButton.Name = "MessageButton";
            this.MessageButton.Size = new System.Drawing.Size(183, 36);
            this.MessageButton.TabIndex = 4;
            this.MessageButton.Text = "Просмотр и редактирование сообщений";
            this.MessageButton.UseVisualStyleBackColor = true;
            // 
            // LogSafe
            // 
            this.LogSafe.Location = new System.Drawing.Point(296, 383);
            this.LogSafe.Name = "LogSafe";
            this.LogSafe.Size = new System.Drawing.Size(145, 55);
            this.LogSafe.TabIndex = 5;
            this.LogSafe.Text = "Сохранить текущий лог в файл";
            this.LogSafe.UseVisualStyleBackColor = true;
            // 
            // CategoryButton
            // 
            this.CategoryButton.Location = new System.Drawing.Point(12, 138);
            this.CategoryButton.Name = "CategoryButton";
            this.CategoryButton.Size = new System.Drawing.Size(182, 36);
            this.CategoryButton.TabIndex = 6;
            this.CategoryButton.Text = "Просмотр и редактирование категорий";
            this.CategoryButton.UseVisualStyleBackColor = true;
            // 
            // SQLButton
            // 
            this.SQLButton.Location = new System.Drawing.Point(13, 180);
            this.SQLButton.Name = "SQLButton";
            this.SQLButton.Size = new System.Drawing.Size(181, 35);
            this.SQLButton.TabIndex = 7;
            this.SQLButton.Text = "Ручной ввод SQL комманд";
            this.SQLButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SQLButton);
            this.Controls.Add(this.CategoryButton);
            this.Controls.Add(this.LogSafe);
            this.Controls.Add(this.MessageButton);
            this.Controls.Add(this.UserButton);
            this.Controls.Add(this.SignButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SignButton;
        private System.Windows.Forms.Button UserButton;
        private System.Windows.Forms.Button MessageButton;
        private System.Windows.Forms.Button LogSafe;
        private System.Windows.Forms.Button CategoryButton;
        private System.Windows.Forms.Button SQLButton;
    }
}

