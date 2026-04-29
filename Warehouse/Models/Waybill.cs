using System;
using System.Collections.Generic;

namespace Warehouse.Models
{
    // Новый маленький класс для хранения одной записи в накладной
    public class WaybillItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Waybill
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public bool IsIncoming { get; set; }

        // Меняем словарь на правильный список
        public List<WaybillItem> Items { get; set; } = new List<WaybillItem>();
    }
}