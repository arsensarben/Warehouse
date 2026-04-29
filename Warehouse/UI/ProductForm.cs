using System;
using System.Windows.Forms;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse
{
    public partial class ProductForm : Form
    {
        public Product CreatedProduct { get; private set; }
        private Product _productToEdit;

        public ProductForm()
        {
            InitializeComponent();
            this.Text = "Додати товар";
        }

        public ProductForm(Product product)
        {
            InitializeComponent();
            this.Text = "Редагувати товар";
            _productToEdit = product;

            textBoxName.Text = product.Name;
            textBoxUnit.Text = product.Unit;
            numPrice.Value = product.Price;
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

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Ціна товару має бути більшою за нуль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_productToEdit != null)
            {
                _productToEdit.Name = textBoxName.Text.Trim();
                _productToEdit.Unit = textBoxUnit.Text.Trim();
                _productToEdit.Price = numPrice.Value;
            }
            else
            {
                CreatedProduct = new Product
                {
                    Name = textBoxName.Text.Trim(),
                    Unit = textBoxUnit.Text.Trim(),
                    Price = numPrice.Value,
                    Quantity = 0,
                    LastDeliveryDate = DateTime.MinValue
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}