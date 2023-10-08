namespace Activity1V2
{
    partial class WelcomeForms
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
            this.WelcomeFormsBackPic = new System.Windows.Forms.PictureBox();
            this.BackBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomeFormsBackPic)).BeginInit();
            this.SuspendLayout();
            // 
            // WelcomeFormsBackPic
            // 
            this.WelcomeFormsBackPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WelcomeFormsBackPic.Image = global::Activity1V2.Properties.Resources.TUBA_Greetings;
            this.WelcomeFormsBackPic.Location = new System.Drawing.Point(0, 0);
            this.WelcomeFormsBackPic.Name = "WelcomeFormsBackPic";
            this.WelcomeFormsBackPic.Size = new System.Drawing.Size(1033, 497);
            this.WelcomeFormsBackPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WelcomeFormsBackPic.TabIndex = 0;
            this.WelcomeFormsBackPic.TabStop = false;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.Transparent;
            this.BackBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.Location = new System.Drawing.Point(12, 114);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(103, 48);
            this.BackBtn.TabIndex = 1;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // WelcomeForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 497);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.WelcomeFormsBackPic);
            this.Name = "WelcomeForms";
            this.Text = "Welcome Spaceman";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WelcomeFormsBackPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WelcomeFormsBackPic;
        private System.Windows.Forms.Button BackBtn;
    }
}