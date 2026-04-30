namespace Warehouse
{
    partial class HistoryForm
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
            dataGridViewHistory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Location = new Point(12, 12);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.Size = new Size(776, 426);
            dataGridViewHistory.TabIndex = 0;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewHistory);
            KeyPreview = true;
            Name = "HistoryForm";
            Text = "Історія операцій";
            KeyDown += HistoryForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewHistory;
    }
}