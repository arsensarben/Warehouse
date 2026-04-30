namespace Warehouse
{
    partial class ProductForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxName = new TextBox();
            textBoxUnit = new TextBox();
            numPrice = new NumericUpDown();
            btnOK = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 36);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Назва";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 68);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 1;
            label2.Text = "Одиниця вимірювання";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 98);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 2;
            label3.Text = "Ціна";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(220, 33);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(120, 23);
            textBoxName.TabIndex = 0;
            // 
            // textBoxUnit
            // 
            textBoxUnit.Location = new Point(220, 65);
            textBoxUnit.Name = "textBoxUnit";
            textBoxUnit.Size = new Size(120, 23);
            textBoxUnit.TabIndex = 1;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(220, 98);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(120, 23);
            numPrice.TabIndex = 2;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(71, 150);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(220, 150);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Відміна";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(440, 240);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(numPrice);
            Controls.Add(textBoxUnit);
            Controls.Add(textBoxName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "ProductForm";
            Text = "Дані товару ";
            KeyDown += ProductForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxName;
        private TextBox textBoxUnit;
        private NumericUpDown numPrice;
        private Button btnOK;
        private Button btnCancel;
    }
}