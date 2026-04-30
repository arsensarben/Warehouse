using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse.Models;

namespace Warehouse
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(List<Waybill> waybills)
        {
            InitializeComponent();
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
        }
    }
}