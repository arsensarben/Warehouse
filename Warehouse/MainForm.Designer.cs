namespace Warehouse
{
    partial class MainForm
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
            dataGridView1 = new DataGridView();
            btnAddProduct = new Button();
            btnCreateWaybill = new Button();
            btnDeleteProduct = new Button();
            btnHistory = new Button();
            btnResetBase = new Button();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 333);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddProduct.Location = new Point(11, 375);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(92, 29);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "Додати товар";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnCreateWaybill
            // 
            btnCreateWaybill.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreateWaybill.Location = new Point(269, 375);
            btnCreateWaybill.Name = "btnCreateWaybill";
            btnCreateWaybill.Size = new Size(137, 29);
            btnCreateWaybill.TabIndex = 2;
            btnCreateWaybill.Text = "Оформити накладну";
            btnCreateWaybill.UseVisualStyleBackColor = true;
            btnCreateWaybill.Click += btnCreateWaybill_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteProduct.Location = new Point(128, 375);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(111, 29);
            btnDeleteProduct.TabIndex = 3;
            btnDeleteProduct.Text = "Видалити товар";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnHistory
            // 
            btnHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHistory.Location = new Point(431, 375);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(121, 29);
            btnHistory.TabIndex = 4;
            btnHistory.Text = "Історія операцій";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += button1_Click;
            // 
            // btnResetBase
            // 
            btnResetBase.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnResetBase.Location = new Point(670, 415);
            btnResetBase.Name = "btnResetBase";
            btnResetBase.Size = new Size(118, 23);
            btnResetBase.TabIndex = 5;
            btnResetBase.Text = "Скинути базу";
            btnResetBase.UseVisualStyleBackColor = true;
            btnResetBase.Click += btnResetBase_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(12, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Пошук...";
            txtSearch.Size = new Size(776, 23);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtSearch);
            Controls.Add(btnResetBase);
            Controls.Add(btnHistory);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnCreateWaybill);
            Controls.Add(btnAddProduct);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAddProduct;
        private Button btnCreateWaybill;
        private Button btnDeleteProduct;
        private Button btnHistory;
        private Button btnResetBase;
        private TextBox txtSearch;
    }
}
