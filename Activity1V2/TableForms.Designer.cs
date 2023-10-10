namespace Activity1V2
{
    partial class TableForms
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchTxtBox = new System.Windows.Forms.TextBox();
            this.ActivateBtn = new System.Windows.Forms.Button();
            this.DeactivateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.AdminLbl = new System.Windows.Forms.Label();
            this.SearchIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 123);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(949, 427);
            this.dataGridView1.TabIndex = 1;
            // 
            // SearchTxtBox
            // 
            this.SearchTxtBox.Font = new System.Drawing.Font("Nasalization Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTxtBox.Location = new System.Drawing.Point(308, 84);
            this.SearchTxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchTxtBox.Multiline = true;
            this.SearchTxtBox.Name = "SearchTxtBox";
            this.SearchTxtBox.Size = new System.Drawing.Size(615, 34);
            this.SearchTxtBox.TabIndex = 2;
            this.SearchTxtBox.TextChanged += new System.EventHandler(this.SearchTxtBox_TextChanged);
            // 
            // ActivateBtn
            // 
            this.ActivateBtn.BackColor = System.Drawing.Color.Black;
            this.ActivateBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ActivateBtn.FlatAppearance.BorderSize = 2;
            this.ActivateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActivateBtn.Font = new System.Drawing.Font("Nasalization Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivateBtn.ForeColor = System.Drawing.Color.White;
            this.ActivateBtn.Location = new System.Drawing.Point(1008, 123);
            this.ActivateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ActivateBtn.Name = "ActivateBtn";
            this.ActivateBtn.Size = new System.Drawing.Size(180, 46);
            this.ActivateBtn.TabIndex = 4;
            this.ActivateBtn.Text = "ACTIVATE";
            this.ActivateBtn.UseVisualStyleBackColor = false;
            this.ActivateBtn.Click += new System.EventHandler(this.ActivateBtn_Click);
            // 
            // DeactivateBtn
            // 
            this.DeactivateBtn.BackColor = System.Drawing.Color.Black;
            this.DeactivateBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DeactivateBtn.FlatAppearance.BorderSize = 2;
            this.DeactivateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeactivateBtn.Font = new System.Drawing.Font("Nasalization Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeactivateBtn.ForeColor = System.Drawing.Color.White;
            this.DeactivateBtn.Location = new System.Drawing.Point(1008, 247);
            this.DeactivateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeactivateBtn.Name = "DeactivateBtn";
            this.DeactivateBtn.Size = new System.Drawing.Size(180, 46);
            this.DeactivateBtn.TabIndex = 5;
            this.DeactivateBtn.Text = "DEACTIVATE";
            this.DeactivateBtn.UseVisualStyleBackColor = false;
            this.DeactivateBtn.Click += new System.EventHandler(this.DeactivateBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.Black;
            this.DeleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DeleteBtn.FlatAppearance.BorderSize = 2;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Nasalization Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Location = new System.Drawing.Point(1008, 375);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(180, 46);
            this.DeleteBtn.TabIndex = 6;
            this.DeleteBtn.Text = "DELETE";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.Black;
            this.BackBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BackBtn.FlatAppearance.BorderSize = 2;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Nasalization Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.ForeColor = System.Drawing.Color.White;
            this.BackBtn.Location = new System.Drawing.Point(1008, 505);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(180, 46);
            this.BackBtn.TabIndex = 7;
            this.BackBtn.Text = "BACK";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // AdminLbl
            // 
            this.AdminLbl.AutoSize = true;
            this.AdminLbl.BackColor = System.Drawing.Color.Transparent;
            this.AdminLbl.Font = new System.Drawing.Font("Space Age", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminLbl.ForeColor = System.Drawing.Color.White;
            this.AdminLbl.Location = new System.Drawing.Point(16, 11);
            this.AdminLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AdminLbl.Name = "AdminLbl";
            this.AdminLbl.Size = new System.Drawing.Size(960, 51);
            this.AdminLbl.TabIndex = 8;
            this.AdminLbl.Text = "ADMIN CONTROL PANEL";
            this.AdminLbl.Click += new System.EventHandler(this.AdminLbl_Click);
            // 
            // SearchIcon
            // 
            this.SearchIcon.Image = global::Activity1V2.Properties.Resources.SearchIcon;
            this.SearchIcon.Location = new System.Drawing.Point(925, 84);
            this.SearchIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchIcon.Name = "SearchIcon";
            this.SearchIcon.Size = new System.Drawing.Size(49, 34);
            this.SearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SearchIcon.TabIndex = 9;
            this.SearchIcon.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Activity1V2.Properties.Resources.TUBA_OuterSpace;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1223, 567);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TableForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 567);
            this.Controls.Add(this.SearchIcon);
            this.Controls.Add(this.AdminLbl);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.DeactivateBtn);
            this.Controls.Add(this.ActivateBtn);
            this.Controls.Add(this.SearchTxtBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TableForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableForms";
            this.Load += new System.EventHandler(this.TableForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox SearchTxtBox;
        private System.Windows.Forms.Button ActivateBtn;
        private System.Windows.Forms.Button DeactivateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Label AdminLbl;
        private System.Windows.Forms.PictureBox SearchIcon;
    }
}