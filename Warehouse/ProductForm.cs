using System;
using System.Windows.Forms;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse
{
    public partial class ProductForm : Form
    {
        public Product CreatedProduct { get; private set; }

        public ProductForm()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введіть назву товару!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxUnit.Text))
            {
                MessageBox.Show("Введіть одиницю виміру (наприклад, шт., кг)!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CreatedProduct = new Product
            {
                Name = textBoxName.Text.Trim(),
                Unit = textBoxUnit.Text.Trim(),
                Price = numPrice.Value,
                Quantity = 0, 
                LastDeliveryDate = DateTime.MinValue
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
