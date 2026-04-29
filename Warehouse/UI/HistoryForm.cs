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
    }
}