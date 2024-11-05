namespace Project5_DapperNorthwind
{
    partial class FrmCategories
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
            this.btnCategoryList = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbCategoryName = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCategoryId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCategoryCount = new System.Windows.Forms.Label();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.lblProductAvgInStock = new System.Windows.Forms.Label();
            this.lblSeafoodProductTotalPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCategoryList
            // 
            this.btnCategoryList.Location = new System.Drawing.Point(168, 240);
            this.btnCategoryList.Name = "btnCategoryList";
            this.btnCategoryList.Size = new System.Drawing.Size(160, 32);
            this.btnCategoryList.TabIndex = 0;
            this.btnCategoryList.Text = "List";
            this.btnCategoryList.UseVisualStyleBackColor = true;
            this.btnCategoryList.Click += new System.EventHandler(this.btnCategoryList_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(344, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(552, 288);
            this.dataGridView1.TabIndex = 1;
            // 
            // tbCategoryName
            // 
            this.tbCategoryName.Location = new System.Drawing.Point(160, 72);
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(168, 26);
            this.tbCategoryName.TabIndex = 2;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(160, 120);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(168, 104);
            this.rtbDescription.TabIndex = 3;
            this.rtbDescription.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description:";
            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Location = new System.Drawing.Point(16, 240);
            this.btnCreateCategory.Name = "btnCreateCategory";
            this.btnCreateCategory.Size = new System.Drawing.Size(144, 32);
            this.btnCreateCategory.TabIndex = 6;
            this.btnCreateCategory.Text = "Create";
            this.btnCreateCategory.UseVisualStyleBackColor = true;
            this.btnCreateCategory.Click += new System.EventHandler(this.btnCreateCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Location = new System.Drawing.Point(16, 280);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(144, 32);
            this.btnUpdateCategory.TabIndex = 7;
            this.btnUpdateCategory.Text = "Update";
            this.btnUpdateCategory.UseVisualStyleBackColor = true;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(168, 280);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(160, 32);
            this.btnDeleteCategory.TabIndex = 8;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Category ID:";
            // 
            // tbCategoryId
            // 
            this.tbCategoryId.Location = new System.Drawing.Point(160, 24);
            this.tbCategoryId.Name = "tbCategoryId";
            this.tbCategoryId.Size = new System.Drawing.Size(168, 26);
            this.tbCategoryId.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(16, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 2);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.lblSeafoodProductTotalPrice);
            this.groupBox2.Controls.Add(this.lblProductAvgInStock);
            this.groupBox2.Controls.Add(this.lblProductCount);
            this.groupBox2.Controls.Add(this.lblCategoryCount);
            this.groupBox2.Location = new System.Drawing.Point(16, 344);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(880, 208);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dapper Statistics";
            // 
            // lblCategoryCount
            // 
            this.lblCategoryCount.AutoSize = true;
            this.lblCategoryCount.Location = new System.Drawing.Point(24, 40);
            this.lblCategoryCount.Name = "lblCategoryCount";
            this.lblCategoryCount.Size = new System.Drawing.Size(18, 20);
            this.lblCategoryCount.TabIndex = 13;
            this.lblCategoryCount.Text = "0";
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Location = new System.Drawing.Point(24, 80);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(18, 20);
            this.lblProductCount.TabIndex = 14;
            this.lblProductCount.Text = "0";
            // 
            // lblProductAvgInStock
            // 
            this.lblProductAvgInStock.AutoSize = true;
            this.lblProductAvgInStock.Location = new System.Drawing.Point(24, 120);
            this.lblProductAvgInStock.Name = "lblProductAvgInStock";
            this.lblProductAvgInStock.Size = new System.Drawing.Size(51, 20);
            this.lblProductAvgInStock.TabIndex = 15;
            this.lblProductAvgInStock.Text = "label4";
            // 
            // lblSeafoodProductTotalPrice
            // 
            this.lblSeafoodProductTotalPrice.AutoSize = true;
            this.lblSeafoodProductTotalPrice.Location = new System.Drawing.Point(24, 152);
            this.lblSeafoodProductTotalPrice.Name = "lblSeafoodProductTotalPrice";
            this.lblSeafoodProductTotalPrice.Size = new System.Drawing.Size(51, 20);
            this.lblSeafoodProductTotalPrice.TabIndex = 16;
            this.lblSeafoodProductTotalPrice.Text = "label4";
            // 
            // FrmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCategoryId);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnUpdateCategory);
            this.Controls.Add(this.btnCreateCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.tbCategoryName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCategoryList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmCategories";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCategoryList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbCategoryName;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCategoryId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCategoryCount;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Label lblSeafoodProductTotalPrice;
        private System.Windows.Forms.Label lblProductAvgInStock;
    }
}

