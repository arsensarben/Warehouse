using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Warehouse.Models
{
    // Клас для зберігання однієї позиції в накладній
    public class WaybillItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    // Клас самої накладної
    public class Waybill
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public bool IsIncoming { get; set; }

        public List<WaybillItem> Items { get; set; } = new List<WaybillItem>();

        // Спеціальна колонка для історії: показує тип операції текстом
        [JsonIgnore]
        public string Operation => IsIncoming ? "Прихід (+)" : "Витрата (-)";

        // Спеціальна колонка для історії: виводить список товарів та їх кількість
        [JsonIgnore]
        public string Details
        {
            get
            {
                if (Items == null || Items.Count == 0) return "Немає товарів";

                var list = new System.Collections.Generic.List<string>();
                foreach (var item in Items)
                {
                    list.Add($"{item.Product.Name}: {item.Quantity} {item.Product.Unit}");
                }
                return string.Join("; ", list);
            }
        }
    }
}