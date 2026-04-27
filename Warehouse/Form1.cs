using System;
using System.Windows.Forms;

namespace WarehouseApp //  простір імен
{
    public partial class Form1 : Form
    {
        // 1. Створюємо "мозок" нашої програми — екземпляр складу
        private Warehouse myWarehouse = new Warehouse();

        public Form1()
        {
            InitializeComponent();

            // 2. Викликаємо метод, щоб відмалювати таблицю при запуску
            UpdateGrid();
        }

        // 3. Метод, який бере список товарів і запихає його в таблицю
        private void UpdateGrid()
        {
            dataGridViewProducts.DataSource = null; // Очищаємо старі дані
            dataGridViewProducts.DataSource = myWarehouse.Inventory; // Підключаємо наш інвентар
        }
    }
}