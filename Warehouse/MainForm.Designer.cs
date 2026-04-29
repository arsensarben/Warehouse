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
            dataGridViewProducts = new DataGridView();
            btnAddProduct = new Button();
            btnCreateWaybill = new Button();
            btnDeleteProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(12, 12);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.Size = new Size(776, 426);
            dataGridViewProducts.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(195, 115);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(92, 29);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "Додати товар";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnCreateWaybill
            // 
            btnCreateWaybill.Location = new Point(457, 115);
            btnCreateWaybill.Name = "btnCreateWaybill";
            btnCreateWaybill.Size = new Size(137, 29);
            btnCreateWaybill.TabIndex = 2;
            btnCreateWaybill.Text = "Оформити накладну";
            btnCreateWaybill.UseVisualStyleBackColor = true;
            btnCreateWaybill.Click += btnCreateWaybill_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(316, 115);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(111, 29);
            btnDeleteProduct.TabIndex = 3;
            btnDeleteProduct.Text = "Видалити товар";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnCreateWaybill);
            Controls.Add(btnAddProduct);
            Controls.Add(dataGridViewProducts);
            Name = "MainForm";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewProducts;
        private Button btnAddProduct;
        private Button btnCreateWaybill;
        private Button btnDeleteProduct;
    }
}
