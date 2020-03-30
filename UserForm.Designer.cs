namespace bavito_server
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Back = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Submit = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Login_label = new System.Windows.Forms.Label();
            this.Login_textBox = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.FIO_label = new System.Windows.Forms.Label();
            this.FIO_textBox = new System.Windows.Forms.TextBox();
            this.Email_label = new System.Windows.Forms.Label();
            this.Email_textBox = new System.Windows.Forms.TextBox();
            this.Adress_label = new System.Windows.Forms.Label();
            this.Adress_textBox = new System.Windows.Forms.TextBox();
            this.Phone_label = new System.Windows.Forms.Label();
            this.Phone_textBox = new System.Windows.Forms.TextBox();
            this.Rating_label = new System.Windows.Forms.Label();
            this.Rating_textBox = new System.Windows.Forms.TextBox();
            this.RegDate_label = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(12, 12);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(79, 32);
            this.Back.TabIndex = 1;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(293, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(740, 551);
            this.dataGridView1.TabIndex = 6;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(12, 394);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(175, 23);
            this.Submit.TabIndex = 8;
            this.Submit.Text = "Внести изменения в базу";
            this.Submit.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(12, 304);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(114, 23);
            this.Search.TabIndex = 7;
            this.Search.Text = "Поиск";
            this.Search.UseVisualStyleBackColor = true;
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.Location = new System.Drawing.Point(12, 65);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(36, 13);
            this.Login_label.TabIndex = 9;
            this.Login_label.Text = "Login:";
            // 
            // Login_textBox
            // 
            this.Login_textBox.Location = new System.Drawing.Point(87, 58);
            this.Login_textBox.Name = "Login_textBox";
            this.Login_textBox.Size = new System.Drawing.Size(100, 20);
            this.Login_textBox.TabIndex = 10;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(12, 91);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(56, 13);
            this.Password_label.TabIndex = 9;
            this.Password_label.Text = "Password:";
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(87, 84);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.Size = new System.Drawing.Size(100, 20);
            this.Password_textBox.TabIndex = 10;
            // 
            // FIO_label
            // 
            this.FIO_label.AutoSize = true;
            this.FIO_label.Location = new System.Drawing.Point(12, 117);
            this.FIO_label.Name = "FIO_label";
            this.FIO_label.Size = new System.Drawing.Size(27, 13);
            this.FIO_label.TabIndex = 9;
            this.FIO_label.Text = "FIO:";
            // 
            // FIO_textBox
            // 
            this.FIO_textBox.Location = new System.Drawing.Point(87, 110);
            this.FIO_textBox.Name = "FIO_textBox";
            this.FIO_textBox.Size = new System.Drawing.Size(100, 20);
            this.FIO_textBox.TabIndex = 10;
            // 
            // Email_label
            // 
            this.Email_label.AutoSize = true;
            this.Email_label.Location = new System.Drawing.Point(12, 143);
            this.Email_label.Name = "Email_label";
            this.Email_label.Size = new System.Drawing.Size(38, 13);
            this.Email_label.TabIndex = 9;
            this.Email_label.Text = "E-mail:";
            // 
            // Email_textBox
            // 
            this.Email_textBox.Location = new System.Drawing.Point(87, 136);
            this.Email_textBox.Name = "Email_textBox";
            this.Email_textBox.Size = new System.Drawing.Size(100, 20);
            this.Email_textBox.TabIndex = 10;
            // 
            // Adress_label
            // 
            this.Adress_label.AutoSize = true;
            this.Adress_label.Location = new System.Drawing.Point(12, 169);
            this.Adress_label.Name = "Adress_label";
            this.Adress_label.Size = new System.Drawing.Size(42, 13);
            this.Adress_label.TabIndex = 9;
            this.Adress_label.Text = "Adress:";
            // 
            // Adress_textBox
            // 
            this.Adress_textBox.Location = new System.Drawing.Point(87, 162);
            this.Adress_textBox.Name = "Adress_textBox";
            this.Adress_textBox.Size = new System.Drawing.Size(100, 20);
            this.Adress_textBox.TabIndex = 10;
            // 
            // Phone_label
            // 
            this.Phone_label.AutoSize = true;
            this.Phone_label.Location = new System.Drawing.Point(12, 195);
            this.Phone_label.Name = "Phone_label";
            this.Phone_label.Size = new System.Drawing.Size(41, 13);
            this.Phone_label.TabIndex = 9;
            this.Phone_label.Text = "Phone:";
            // 
            // Phone_textBox
            // 
            this.Phone_textBox.Location = new System.Drawing.Point(87, 188);
            this.Phone_textBox.Name = "Phone_textBox";
            this.Phone_textBox.Size = new System.Drawing.Size(100, 20);
            this.Phone_textBox.TabIndex = 10;
            // 
            // Rating_label
            // 
            this.Rating_label.AutoSize = true;
            this.Rating_label.Location = new System.Drawing.Point(12, 221);
            this.Rating_label.Name = "Rating_label";
            this.Rating_label.Size = new System.Drawing.Size(41, 13);
            this.Rating_label.TabIndex = 9;
            this.Rating_label.Text = "Rating:";
            // 
            // Rating_textBox
            // 
            this.Rating_textBox.Location = new System.Drawing.Point(87, 214);
            this.Rating_textBox.Name = "Rating_textBox";
            this.Rating_textBox.Size = new System.Drawing.Size(100, 20);
            this.Rating_textBox.TabIndex = 10;
            // 
            // RegDate_label
            // 
            this.RegDate_label.AutoSize = true;
            this.RegDate_label.Location = new System.Drawing.Point(12, 247);
            this.RegDate_label.Name = "RegDate_label";
            this.RegDate_label.Size = new System.Drawing.Size(53, 13);
            this.RegDate_label.TabIndex = 9;
            this.RegDate_label.Text = "RegDate:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 241);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 567);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.RegDate_label);
            this.Controls.Add(this.Rating_textBox);
            this.Controls.Add(this.Rating_label);
            this.Controls.Add(this.Phone_textBox);
            this.Controls.Add(this.Phone_label);
            this.Controls.Add(this.Adress_textBox);
            this.Controls.Add(this.Adress_label);
            this.Controls.Add(this.Email_textBox);
            this.Controls.Add(this.Email_label);
            this.Controls.Add(this.FIO_textBox);
            this.Controls.Add(this.FIO_label);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Login_textBox);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Back);
            this.Name = "UserForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.TextBox Login_textBox;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label FIO_label;
        private System.Windows.Forms.TextBox FIO_textBox;
        private System.Windows.Forms.Label Email_label;
        private System.Windows.Forms.TextBox Email_textBox;
        private System.Windows.Forms.Label Adress_label;
        private System.Windows.Forms.TextBox Adress_textBox;
        private System.Windows.Forms.Label Phone_label;
        private System.Windows.Forms.TextBox Phone_textBox;
        private System.Windows.Forms.Label Rating_label;
        private System.Windows.Forms.TextBox Rating_textBox;
        private System.Windows.Forms.Label RegDate_label;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}