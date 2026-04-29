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
            myWarehouse.LoadData(); // Зчитуємо дані з файлу
            UpdateGrid();           // Показуємо їх у таблиці
        }

        // Метод оновлення таблиці
        private void UpdateGrid()
        {
            // Робимо свіжу копію списку (ToArray), щоб DataGridView не сходив з розуму 
            // при спробі зчитати дані, які в цей момент змінюються на складі
            var safeData = myWarehouse.Inventory.ToArray();

            dataGridView1.DataSource = safeData;
        }

        // Кнопка додавання нового товару в каталог
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (myWarehouse.Inventory.Any(p => p.Name.ToLower() == form.CreatedProduct.Name.ToLower()))
                {
                    MessageBox.Show("Товар з такою назвою вже існує на складі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
            if (dataGridView1.CurrentRow != null)
            {
                // Дістаємо товар з виділеного рядка (там, де стоїть чорна стрілочка)
                Product selectedProduct = (Product)dataGridView1.CurrentRow.DataBoundItem;

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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myWarehouse.SaveData(); // Зберігаємо дані перед тим, як вікно зникне
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm(myWarehouse.Waybills);
            historyForm.ShowDialog();
        }

        private void btnResetBase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Ви впевнені, що хочете ПОВНІСТЮ очистити склад і видалити всі накладні? Цю дію неможливо скасувати!",
        "Критична дія",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                myWarehouse.Inventory.Clear();
                myWarehouse.Waybills.Clear();
                UpdateGrid();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();
            var filteredList = myWarehouse.Inventory.Where(p => p.Name.ToLower().Contains(query)).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filteredList;
        }

        private void btnEditProduct_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Product selectedProduct = (Product)dataGridView1.CurrentRow.DataBoundItem;
                ProductForm form = new ProductForm(selectedProduct);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateGrid();
                }
            }
            else
            {
                MessageBox.Show("Оберіть товар для редагування!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Product p && p.Quantity == 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
            }
        }
    }
}