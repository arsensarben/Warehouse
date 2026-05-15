using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse.Models;

namespace Warehouse
{
    public partial class HistoryForm : Form
    {
        // Конструктор форми приймає готовий список накладних із головного вікна
        public HistoryForm(List<Waybill> waybills)
        {
            // Ініціалізує та створює всі візуальні компоненти (таблиці, кнопки), налаштовані в дизайнері
            InitializeComponent();

            // Напряму згодовуємо список таблиці, і вона сама розіб'є його на колонки
            dataGridViewHistory.DataSource = waybills;
        }

        private void HistoryForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Обробка клавіші F1 (Довідка)
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show(
                    "Вікно історії операцій.\n\n" +
                    "Тут відображається незмінний журнал усіх накладних.\n" +
                    "• Number — унікальний номер транзакції.\n" +
                    "• Date — дата та час проведення.\n" +
                    "• Operation — тип операції: Прихід (+) або Витрата (-).\n" +
                    "• Details — який саме товар і в якій кількості було проведено.\n\n" +
                    "Гарячі клавіші:\n" +
                    "Esc — закрити вікно історії.",
                    "Довідка: Історія",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            // Реалізовано закриття форми на Esc
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}