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
            CreatedWaybill.Items.Add(new WaybillItem { Product = selectedProduct, Quantity = quantity });

            // Кажемо системі, що все добре, і закриваємо вікно
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void WaybillForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Якщо натиснута клавіша F1
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show(
                    "Вікно оформлення складських накладних.\n\n" +
                    "• Прибуткова накладна — додає вказану кількість товару на склад.\n" +
                    "• Видаткова накладна — списує вказану кількість товару зі складу (переконайтеся, що залишків достатньо).\n" +
                    "• Оберіть товар — виберіть потрібну позицію з існуючих у базі.\n" +
                    "• Кількість — вкажіть, скільки одиниць прибуває або вибуває.\n\n" +
                    "Гарячі клавіші:\n" +
                    "Enter — підтвердити операцію (ОК).\n" +
                    "Esc — закрити вікно без збереження (Скасувати).",
                    "Довідка: Накладні",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}

