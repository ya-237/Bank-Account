namespace WinFormsApp1
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            pictureBox1 = new PictureBox();
            username_label = new Label();
            password_label = new Label();
            label3 = new Label();
            username_textBox = new TextBox();
            password_textBox = new TextBox();
            email_textBox = new TextBox();
            checkBox1 = new CheckBox();
            signup_button = new Button();
            cnacel_button = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-8, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(805, 495);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // username_label
            // 
            username_label.AutoSize = true;
            username_label.BackColor = Color.DimGray;
            username_label.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username_label.Location = new Point(245, 169);
            username_label.Name = "username_label";
            username_label.Size = new Size(88, 20);
            username_label.TabIndex = 1;
            username_label.Text = "Username";
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.BackColor = Color.DimGray;
            password_label.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            password_label.Location = new Point(245, 218);
            password_label.Name = "password_label";
            password_label.Size = new Size(86, 20);
            password_label.TabIndex = 2;
            password_label.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.DimGray;
            label3.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(245, 267);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 3;
            label3.Text = "Email";
            label3.Click += label3_Click;
            // 
            // username_textBox
            // 
            username_textBox.Location = new Point(339, 166);
            username_textBox.Name = "username_textBox";
            username_textBox.Size = new Size(308, 27);
            username_textBox.TabIndex = 4;
            // 
            // password_textBox
            // 
            password_textBox.Location = new Point(339, 218);
            password_textBox.Name = "password_textBox";
            password_textBox.PasswordChar = 'b';
            password_textBox.Size = new Size(308, 27);
            password_textBox.TabIndex = 5;
            // 
            // email_textBox
            // 
            email_textBox.Location = new Point(339, 260);
            email_textBox.Name = "email_textBox";
            email_textBox.Size = new Size(308, 27);
            email_textBox.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.DimGray;
            checkBox1.Location = new Point(425, 318);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(363, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "I Agree and Undesrtand The Terms and Conditions";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // signup_button
            // 
            signup_button.BackColor = Color.DimGray;
            signup_button.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signup_button.Location = new Point(284, 361);
            signup_button.Name = "signup_button";
            signup_button.Size = new Size(94, 29);
            signup_button.TabIndex = 8;
            signup_button.Text = "Sign Up";
            signup_button.UseVisualStyleBackColor = false;
            // 
            // cnacel_button
            // 
            cnacel_button.BackColor = Color.DimGray;
            cnacel_button.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cnacel_button.ForeColor = Color.Black;
            cnacel_button.Location = new Point(519, 361);
            cnacel_button.Name = "cnacel_button";
            cnacel_button.Size = new Size(94, 29);
            cnacel_button.TabIndex = 9;
            cnacel_button.Text = "Cancel";
            cnacel_button.UseVisualStyleBackColor = false;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 489);
            Controls.Add(cnacel_button);
            Controls.Add(signup_button);
            Controls.Add(checkBox1);
            Controls.Add(email_textBox);
            Controls.Add(password_textBox);
            Controls.Add(username_textBox);
            Controls.Add(label3);
            Controls.Add(password_label);
            Controls.Add(username_label);
            Controls.Add(pictureBox1);
            Name = "Form4";
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label username_label;
        private Label password_label;
        private Label label3;
        private TextBox username_textBox;
        private TextBox password_textBox;
        private TextBox email_textBox;
        private CheckBox checkBox1;
        private Button signup_button;
        private Button cnacel_button;
    }
}