using System;
using System.Windows.Forms;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse
{
    public partial class MainForm : Form
    {
        // Створюємо наш склад
        private Warehouse.Services.Warehouse myWarehouse = new Warehouse.Services.Warehouse();

        public MainForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        // Метод оновлення таблиці
        private void UpdateGrid()
        {
            // Робимо свіжу копію списку (ToArray), щоб DataGridView не сходив з розуму 
            // при спробі зчитати дані, які в цей момент змінюються на складі
            var safeData = myWarehouse.Inventory.ToArray();

            dataGridViewProducts.DataSource = safeData;
        }

        // Кнопка додавання нового товару в каталог
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                myWarehouse.Inventory.Add(form.CreatedProduct);
                UpdateGrid();
            }
        }

        // НОВА КНОПКА: Оформлення накладної
        private void btnCreateWaybill_Click(object sender, EventArgs e)
        {
            // Перевірка: чи є взагалі товари в каталозі
            if (myWarehouse.Inventory.Count == 0)
            {
                MessageBox.Show("Спочатку додайте хоча б один товар у каталог!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Передаємо інвентар у конструктор форми накладної
            WaybillForm form = new WaybillForm(myWarehouse.Inventory);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Перевіряємо тип накладної і викликаємо потрібний метод зі складу
                    if (form.CreatedWaybill.IsIncoming)
                    {
                        myWarehouse.RegisterIncoming(form.CreatedWaybill);
                    }
                    else
                    {
                        myWarehouse.RegisterOutgoing(form.CreatedWaybill);
                    }

                    UpdateGrid(); // Оновлюємо таблицю, щоб побачити нові залишки

                    MessageBox.Show("Накладну успішно проведено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Тут ми ловимо throw new Exception("Недостатньо товару...")
                    MessageBox.Show(ex.Message, "Помилка проведення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи взагалі вибрано якийсь рядок у таблиці
            if (dataGridViewProducts.CurrentRow != null)
            {
                // Дістаємо товар з виділеного рядка (там, де стоїть чорна стрілочка)
                Product selectedProduct = (Product)dataGridViewProducts.CurrentRow.DataBoundItem;

                // Виводимо вікно з підтвердженням
                DialogResult result = MessageBox.Show(
                    $"Ви дійсно хочете видалити товар '{selectedProduct.Name}' з каталогу?",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Якщо користувач натиснув "Так"
                if (result == DialogResult.Yes)
                {
                    myWarehouse.Inventory.Remove(selectedProduct); // Видаляємо товар зі складу
                    UpdateGrid(); // Оновлюємо таблицю, щоб рядок зник з екрана
                }
            }
            else
            {
                // Якщо таблиця порожня або користувач клікнув кудись не туди
                MessageBox.Show("Будь ласка, оберіть товар для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}