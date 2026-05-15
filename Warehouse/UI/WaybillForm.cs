using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse.Models;


namespace Warehouse
{
    public partial class WaybillForm : Form
    {
        // Властивість для збереження новоствореної накладної, яку потім забере головна форма
        public Waybill CreatedWaybill { get; private set; }

        // Конструктор приймає актуальний список товарів зі складу для випадаючого списку
        public WaybillForm(List<Product> availableProducts)
        {
            // Ініціалізує та створює всі візуальні компоненти (таблиці, кнопки), налаштовані в дизайнері
            InitializeComponent();

            // Прив'язка даних до ComboBox: передаємо список об'єктів і кажемо відображати поле "Name"
            cmbProducts.DataSource = availableProducts;
            cmbProducts.DisplayMember = "Name";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // ВАЛІДАЦІЯ: Перевіряємо, чи користувач взагалі обрав товар
            if (cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Оберіть товар зі списку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numQuantity.Value;

            // ВАЛІДАЦІЯ: Перевірка на нуль або від'ємне значення 
            if (quantity <= 0)
            {
                MessageBox.Show("Кількість товару в накладній має бути більшою за нуль!", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Отримуємо фізичний об'єкт товару, який юзер виділив у випадаючому списку
            Product selectedProduct = (Product)cmbProducts.SelectedItem;

            // Створення накладної
            CreatedWaybill = new Waybill
            {
                // Генеруємо унікальний номер накладної на основі поточного часу (тіків процесора)
                Number = "INV-" + DateTime.Now.Ticks.ToString().Substring(10),
                Date = DateTime.Now,
                // Визначаємо тип операції за допомогою RadioButton (Прибуток/Видаток)
                IsIncoming = rbIncoming.Checked
            };

            // Додаємо вибраний товар і його кількість у словник накладної
            CreatedWaybill.Items.Add(new WaybillItem { Product = selectedProduct, Quantity = quantity });

            // Сигнал системі, що накладна успішно сформована
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

