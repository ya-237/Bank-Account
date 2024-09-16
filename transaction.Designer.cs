namespace Ktypton_Bank
{
    partial class transaction
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
            this.label6 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.transactionsDataGridView = new System.Windows.Forms.Button();
            this.textbox_transactionType = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTransactionDate = new System.Windows.Forms.TextBox();
            this.textbox_accountID = new System.Windows.Forms.TextBox();
            this.label_transactionType = new System.Windows.Forms.Label();
            this.label_amount = new System.Windows.Forms.Label();
            this.label_transactionDate = new System.Windows.Forms.Label();
            this.label_accountID = new System.Windows.Forms.Label();
            this.label_TID = new System.Windows.Forms.Label();
            this.textbottun_TID = new System.Windows.Forms.TextBox();
            this.textbox_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(628, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "Transaction";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.Transparent;
            this.btn_delete.Location = new System.Drawing.Point(500, 228);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(99, 36);
            this.btn_delete.TabIndex = 13;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_update
            // 
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.Transparent;
            this.btn_update.Location = new System.Drawing.Point(381, 228);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(99, 36);
            this.btn_update.TabIndex = 12;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.Transparent;
            this.btn_add.Location = new System.Drawing.Point(262, 228);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(99, 36);
            this.btn_add.TabIndex = 11;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // transactionsDataGridView
            // 
            this.transactionsDataGridView.FlatAppearance.BorderSize = 0;
            this.transactionsDataGridView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transactionsDataGridView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionsDataGridView.ForeColor = System.Drawing.Color.Transparent;
            this.transactionsDataGridView.Location = new System.Drawing.Point(142, 228);
            this.transactionsDataGridView.Name = "transactionsDataGridView";
            this.transactionsDataGridView.Size = new System.Drawing.Size(99, 36);
            this.transactionsDataGridView.TabIndex = 10;
            this.transactionsDataGridView.Text = "Save";
            this.transactionsDataGridView.UseVisualStyleBackColor = true;
            this.transactionsDataGridView.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // textbox_transactionType
            // 
            this.textbox_transactionType.Location = new System.Drawing.Point(196, 69);
            this.textbox_transactionType.Name = "textbox_transactionType";
            this.textbox_transactionType.Size = new System.Drawing.Size(403, 22);
            this.textbox_transactionType.TabIndex = 9;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(196, 110);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(403, 22);
            this.txtAmount.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.transactionsDataGridView);
            this.panel1.Controls.Add(this.textbox_transactionType);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.txtTransactionDate);
            this.panel1.Controls.Add(this.textbox_accountID);
            this.panel1.Controls.Add(this.label_transactionType);
            this.panel1.Controls.Add(this.label_amount);
            this.panel1.Controls.Add(this.label_transactionDate);
            this.panel1.Controls.Add(this.label_accountID);
            this.panel1.Controls.Add(this.label_TID);
            this.panel1.Controls.Add(this.textbottun_TID);
            this.panel1.Location = new System.Drawing.Point(-6, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 280);
            this.panel1.TabIndex = 5;
            // 
            // txtTransactionDate
            // 
            this.txtTransactionDate.Location = new System.Drawing.Point(196, 153);
            this.txtTransactionDate.Name = "txtTransactionDate";
            this.txtTransactionDate.Size = new System.Drawing.Size(403, 22);
            this.txtTransactionDate.TabIndex = 7;
            // 
            // textbox_accountID
            // 
            this.textbox_accountID.Location = new System.Drawing.Point(196, 195);
            this.textbox_accountID.Name = "textbox_accountID";
            this.textbox_accountID.Size = new System.Drawing.Size(403, 22);
            this.textbox_accountID.TabIndex = 6;
            // 
            // label_transactionType
            // 
            this.label_transactionType.AutoSize = true;
            this.label_transactionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_transactionType.ForeColor = System.Drawing.Color.Transparent;
            this.label_transactionType.Location = new System.Drawing.Point(8, 69);
            this.label_transactionType.Name = "label_transactionType";
            this.label_transactionType.Size = new System.Drawing.Size(158, 20);
            this.label_transactionType.TabIndex = 5;
            this.label_transactionType.Text = "Transaction_Type";
            // 
            // label_amount
            // 
            this.label_amount.AutoSize = true;
            this.label_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_amount.ForeColor = System.Drawing.Color.Transparent;
            this.label_amount.Location = new System.Drawing.Point(38, 110);
            this.label_amount.Name = "label_amount";
            this.label_amount.Size = new System.Drawing.Size(72, 20);
            this.label_amount.TabIndex = 4;
            this.label_amount.Text = "Amount";
            // 
            // label_transactionDate
            // 
            this.label_transactionDate.AutoSize = true;
            this.label_transactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_transactionDate.ForeColor = System.Drawing.Color.Transparent;
            this.label_transactionDate.Location = new System.Drawing.Point(8, 153);
            this.label_transactionDate.Name = "label_transactionDate";
            this.label_transactionDate.Size = new System.Drawing.Size(158, 20);
            this.label_transactionDate.TabIndex = 3;
            this.label_transactionDate.Text = "Transaction_Date";
            this.label_transactionDate.Click += new System.EventHandler(this.label_transactionDate_Click);
            // 
            // label_accountID
            // 
            this.label_accountID.AutoSize = true;
            this.label_accountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_accountID.ForeColor = System.Drawing.Color.Transparent;
            this.label_accountID.Location = new System.Drawing.Point(38, 195);
            this.label_accountID.Name = "label_accountID";
            this.label_accountID.Size = new System.Drawing.Size(106, 20);
            this.label_accountID.TabIndex = 2;
            this.label_accountID.Text = "Account_ID";
            // 
            // label_TID
            // 
            this.label_TID.AutoSize = true;
            this.label_TID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TID.ForeColor = System.Drawing.Color.Transparent;
            this.label_TID.Location = new System.Drawing.Point(38, 30);
            this.label_TID.Name = "label_TID";
            this.label_TID.Size = new System.Drawing.Size(39, 20);
            this.label_TID.TabIndex = 0;
            this.label_TID.Text = "TID";
            // 
            // textbottun_TID
            // 
            this.textbottun_TID.Location = new System.Drawing.Point(196, 30);
            this.textbottun_TID.Name = "textbottun_TID";
            this.textbottun_TID.Size = new System.Drawing.Size(403, 22);
            this.textbottun_TID.TabIndex = 1;
            // 
            // textbox_search
            // 
            this.textbox_search.Location = new System.Drawing.Point(75, 6);
            this.textbox_search.Name = "textbox_search";
            this.textbox_search.Size = new System.Drawing.Size(551, 22);
            this.textbox_search.TabIndex = 14;
            this.textbox_search.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // btn_search
            // 
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.Transparent;
            this.btn_search.Location = new System.Drawing.Point(673, 1);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(99, 30);
            this.btn_search.TabIndex = 14;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 311);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(808, 207);
            this.dataGridView1.TabIndex = 15;
            // 
            // transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(808, 518);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.textbox_search);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "transaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "transaction";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button transactionsDataGridView;
        private System.Windows.Forms.TextBox textbox_transactionType;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTransactionDate;
        private System.Windows.Forms.TextBox textbox_accountID;
        private System.Windows.Forms.Label label_transactionType;
        private System.Windows.Forms.Label label_amount;
        private System.Windows.Forms.Label label_transactionDate;
        private System.Windows.Forms.Label label_accountID;
        private System.Windows.Forms.Label label_TID;
        private System.Windows.Forms.TextBox textbottun_TID;
        private System.Windows.Forms.TextBox textbox_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}