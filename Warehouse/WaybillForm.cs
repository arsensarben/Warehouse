using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse.Models;

namespace Warehouse
{
    public partial class WaybillForm : Form
    {
        public Waybill CreatedWaybill { get; private set; }

        public WaybillForm(List<Product> availableProducts)
        {
            InitializeComponent();

            cmbProducts.DataSource = availableProducts;
            cmbProducts.DisplayMember = "Name";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Стара перевірка: чи обрано товар
            if (cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Оберіть товар зі списку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numQuantity.Value;

            // НОВА ПЕРЕВІРКА НА НУЛЬ АБО ВІД'ЄМНЕ ЗНАЧЕННЯ
            if (quantity <= 0)
            {
                MessageBox.Show("Кількість товару в накладній має бути більшою за нуль!", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product selectedProduct = (Product)cmbProducts.SelectedItem;

            // Створення накладної
            CreatedWaybill = new Waybill
            {
                Number = "INV-" + DateTime.Now.Ticks.ToString().Substring(10),
                Date = DateTime.Now,
                IsIncoming = rbIncoming.Checked
            };

            // Додаємо вибраний товар і його кількість у словник накладної
            CreatedWaybill.Items.Add(selectedProduct, quantity);

            // Кажемо системі, що все добре, і закриваємо вікно
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

