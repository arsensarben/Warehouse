using System;
using System.Windows.Forms; 

namespace Warehouse // Здесь название твоего проекта
{
    public partial class Form1 : Form // 2. ВОТ ГЛАВНАЯ ОШИБКА: у тебя пропало ": Form"
    {
        private Warehouse myWarehouse = new Warehouse();

        public Form1()
        {
            InitializeComponent();
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