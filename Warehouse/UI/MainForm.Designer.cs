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
            btnAddProduct = new Button();
            btnCreateWaybill = new Button();
            btnDeleteProduct = new Button();
            btnHistory = new Button();
            btnResetBase = new Button();
            txtSearch = new TextBox();
            btnEditProduct = new Button();
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            openAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            lblStatistics = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddProduct.Location = new Point(11, 368);
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
            btnCreateWaybill.Location = new Point(381, 368);
            btnCreateWaybill.Name = "btnCreateWaybill";
            btnCreateWaybill.Size = new Size(137, 29);
            btnCreateWaybill.TabIndex = 4;
            btnCreateWaybill.Text = "Оформити накладну";
            btnCreateWaybill.UseVisualStyleBackColor = true;
            btnCreateWaybill.Click += btnCreateWaybill_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteProduct.Location = new Point(254, 368);
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
            btnHistory.Location = new Point(530, 368);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(121, 29);
            btnHistory.TabIndex = 5;
            btnHistory.Text = "Історія операцій";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += button1_Click;
            // 
            // btnResetBase
            // 
            btnResetBase.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnResetBase.Location = new Point(665, 423);
            btnResetBase.Name = "btnResetBase";
            btnResetBase.Size = new Size(123, 24);
            btnResetBase.TabIndex = 6;
            btnResetBase.TabStop = false;
            btnResetBase.Text = "Скинути базу";
            btnResetBase.UseVisualStyleBackColor = true;
            btnResetBase.Click += btnResetBase_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(12, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Пошук...";
            txtSearch.Size = new Size(776, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TabStop = false;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnEditProduct
            // 
            btnEditProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditProduct.Location = new Point(116, 368);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(122, 29);
            btnEditProduct.TabIndex = 2;
            btnEditProduct.Text = "Редагувати товар";
            btnEditProduct.UseVisualStyleBackColor = true;
            btnEditProduct.Click += btnEditProduct_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.Size = new Size(776, 291);
            dataGridView1.TabIndex = 1;
            dataGridView1.TabStop = false;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripMenuItem1, openToolStripMenuItem, openAsToolStripMenuItem, toolStripMenuItem2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(117, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click_1;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(117, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(114, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(117, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openAsToolStripMenuItem
            // 
            openAsToolStripMenuItem.Name = "openAsToolStripMenuItem";
            openAsToolStripMenuItem.Size = new Size(117, 22);
            openAsToolStripMenuItem.Text = "Open as";
            openAsToolStripMenuItem.Click += openAsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(114, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(117, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // lblStatistics
            // 
            lblStatistics.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblStatistics.AutoSize = true;
            lblStatistics.Location = new Point(312, 350);
            lblStatistics.Name = "lblStatistics";
            lblStatistics.Size = new Size(53, 15);
            lblStatistics.TabIndex = 8;
            lblStatistics.Text = "Statistics";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatistics);
            Controls.Add(btnEditProduct);
            Controls.Add(txtSearch);
            Controls.Add(btnResetBase);
            Controls.Add(btnHistory);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnCreateWaybill);
            Controls.Add(btnAddProduct);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Керування складом";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAddProduct;
        private Button btnCreateWaybill;
        private Button btnDeleteProduct;
        private Button btnHistory;
        private Button btnResetBase;
        private TextBox txtSearch;
        private Button btnEditProduct;
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openAsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label lblStatistics;
    }
}
