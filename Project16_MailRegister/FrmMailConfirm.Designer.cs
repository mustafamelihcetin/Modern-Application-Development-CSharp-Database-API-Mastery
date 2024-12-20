namespace Project16_MailRegister
{
    partial class FrmMailConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMailConfirm));
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSixDigitsCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMailConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.txtEmail.Location = new System.Drawing.Point(152, 24);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(232, 28);
            this.txtEmail.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(64, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-posta: ";
            // 
            // txtSixDigitsCode
            // 
            this.txtSixDigitsCode.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.txtSixDigitsCode.Location = new System.Drawing.Point(152, 64);
            this.txtSixDigitsCode.Name = "txtSixDigitsCode";
            this.txtSixDigitsCode.Size = new System.Drawing.Size(232, 28);
            this.txtSixDigitsCode.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(27, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "6 Haneli Kod: ";
            // 
            // btnMailConfirm
            // 
            this.btnMailConfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnMailConfirm.Appearance.Options.UseFont = true;
            this.btnMailConfirm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMailConfirm.ImageOptions.Image")));
            this.btnMailConfirm.Location = new System.Drawing.Point(168, 104);
            this.btnMailConfirm.Name = "btnMailConfirm";
            this.btnMailConfirm.Size = new System.Drawing.Size(208, 40);
            this.btnMailConfirm.TabIndex = 14;
            this.btnMailConfirm.Text = "Aktivasyonu Tamamla";
            this.btnMailConfirm.Click += new System.EventHandler(this.btnMailConfirm_Click);
            // 
            // FrmMailConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 167);
            this.Controls.Add(this.btnMailConfirm);
            this.Controls.Add(this.txtSixDigitsCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Name = "FrmMailConfirm";
            this.Text = "Aktivasyon";
            this.Load += new System.EventHandler(this.FrmMailConfirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSixDigitsCode;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnMailConfirm;
    }
}