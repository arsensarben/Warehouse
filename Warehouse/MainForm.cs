using System;
using System.Windows.Forms;

namespace Warehouse // Здесь название твоего проекта
{
    public partial class MainForm : Form
    {
        private Warehouse myWarehouse = new Warehouse();

        public MainForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        // Метод, який бере список товарів і запихає його в таблицю
        private void UpdateGrid()
        {
            dataGridViewProducts.DataSource = null; // Очищаємо старі дані
            dataGridViewProducts.DataSource = myWarehouse.Inventory; // Підключаємо наш інвентар
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // 1. Створюємо екземпляр нашого нового вікна
            ProductForm form = new ProductForm();

            // 2. Відкриваємо його в модальному режимі (ShowDialog блокує головне вікно, поки це не закриють)
            if (form.ShowDialog() == DialogResult.OK)
            {
                // 3. Якщо користувач натиснув ОК і перевірки пройшли, забираємо готовий товар
                myWarehouse.Inventory.Add(form.CreatedProduct);

                // 4. Оновлюємо таблицю, щоб новий товар одразу з'явився на екрані
                UpdateGrid();
            }
        }
    }
}
