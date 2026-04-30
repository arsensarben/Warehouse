namespace Warehouse
{
    partial class WaybillForm
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
            cmbProducts = new ComboBox();
            numQuantity = new NumericUpDown();
            rbIncoming = new RadioButton();
            rbOutgoing = new RadioButton();
            btnOK = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(153, 88);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(172, 23);
            cmbProducts.TabIndex = 2;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(153, 128);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(125, 23);
            numQuantity.TabIndex = 3;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // rbIncoming
            // 
            rbIncoming.AutoSize = true;
            rbIncoming.Checked = true;
            rbIncoming.Location = new Point(60, 23);
            rbIncoming.Name = "rbIncoming";
            rbIncoming.Size = new Size(145, 19);
            rbIncoming.TabIndex = 0;
            rbIncoming.TabStop = true;
            rbIncoming.Text = "Прибуткова накладна";
            rbIncoming.UseVisualStyleBackColor = true;
            // 
            // rbOutgoing
            // 
            rbOutgoing.AutoSize = true;
            rbOutgoing.Location = new Point(60, 53);
            rbOutgoing.Name = "rbOutgoing";
            rbOutgoing.Size = new Size(135, 19);
            rbOutgoing.TabIndex = 1;
            rbOutgoing.Text = "Видаткова накладна";
            rbOutgoing.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(153, 187);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(80, 23);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(278, 187);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 91);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 6;
            label1.Text = "Оберіть товар:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 129);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 7;
            label2.Text = "Кількість:";
            // 
            // WaybillForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(442, 241);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(rbOutgoing);
            Controls.Add(rbIncoming);
            Controls.Add(numQuantity);
            Controls.Add(cmbProducts);
            KeyPreview = true;
            Name = "WaybillForm";
            Text = "Накладні";
            KeyDown += WaybillForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbProducts;
        private NumericUpDown numQuantity;
        private RadioButton rbIncoming;
        private RadioButton rbOutgoing;
        private Button btnOK;
        private Button btnCancel;
        private Label label1;
        private Label label2;
    }
}