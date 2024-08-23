namespace WinFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cnacel_button = new Button();
            signup_button = new Button();
            checkBox1 = new CheckBox();
            email_textBox = new TextBox();
            password_textBox = new TextBox();
            username_textBox = new TextBox();
            label3 = new Label();
            password_label = new Label();
            username_label = new Label();
            pictureBox1 = new PictureBox();
            checkBox2 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cnacel_button
            // 
            cnacel_button.BackColor = Color.DimGray;
            cnacel_button.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cnacel_button.ForeColor = Color.Black;
            cnacel_button.Location = new Point(449, 413);
            cnacel_button.Name = "cnacel_button";
            cnacel_button.Size = new Size(94, 29);
            cnacel_button.TabIndex = 19;
            cnacel_button.Text = "Cancel";
            cnacel_button.UseVisualStyleBackColor = false;
            cnacel_button.Click += cnacel_button_Click;
            // 
            // signup_button
            // 
            signup_button.BackColor = Color.DimGray;
            signup_button.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signup_button.Location = new Point(235, 413);
            signup_button.Name = "signup_button";
            signup_button.Size = new Size(94, 29);
            signup_button.TabIndex = 18;
            signup_button.Text = "Sign Up";
            signup_button.UseVisualStyleBackColor = false;
            signup_button.Click += signup_button_Click;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.DimGray;
            checkBox1.Location = new Point(235, 316);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(363, 24);
            checkBox1.TabIndex = 17;
            checkBox1.Tag = "signup_button";
            checkBox1.Text = "I Agree and Undesrtand The Terms and Conditions";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // email_textBox
            // 
            email_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            email_textBox.Location = new Point(235, 283);
            email_textBox.Name = "email_textBox";
            email_textBox.Size = new Size(308, 27);
            email_textBox.TabIndex = 16;
            // 
            // password_textBox
            // 
            password_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            password_textBox.Location = new Point(235, 222);
            password_textBox.Name = "password_textBox";
            password_textBox.PasswordChar = '*';
            password_textBox.Size = new Size(308, 27);
            password_textBox.TabIndex = 15;
            // 
            // username_textBox
            // 
            username_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            username_textBox.Location = new Point(235, 172);
            username_textBox.Name = "username_textBox";
            username_textBox.Size = new Size(308, 27);
            username_textBox.TabIndex = 14;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.DimGray;
            label3.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(143, 290);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 13;
            label3.Text = "Email";
            // 
            // password_label
            // 
            password_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            password_label.AutoSize = true;
            password_label.BackColor = Color.DimGray;
            password_label.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            password_label.Location = new Point(141, 229);
            password_label.Name = "password_label";
            password_label.Size = new Size(86, 20);
            password_label.TabIndex = 12;
            password_label.Text = "Password";
            // 
            // username_label
            // 
            username_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            username_label.AutoSize = true;
            username_label.BackColor = Color.DimGray;
            username_label.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username_label.Location = new Point(141, 175);
            username_label.Name = "username_label";
            username_label.Size = new Size(88, 20);
            username_label.TabIndex = 11;
            username_label.Text = "Username";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-57, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(805, 506);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.DimGray;
            checkBox2.Location = new Point(235, 364);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(129, 24);
            checkBox2.TabIndex = 20;
            checkBox2.Text = "Remember Me";
            checkBox2.UseVisualStyleBackColor = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 512);
            Controls.Add(checkBox2);
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
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cnacel_button;
        private Button signup_button;
        private CheckBox checkBox1;
        private TextBox email_textBox;
        private TextBox password_textBox;
        private TextBox username_textBox;
        private Label label3;
        private Label password_label;
        private Label username_label;
        private PictureBox pictureBox1;
        private CheckBox checkBox2;
    }
}
