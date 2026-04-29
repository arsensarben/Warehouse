using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Warehouse.Models
{
    // Клас для зберігання однієї позиції в накладній
    public class WaybillItem
    {
        private Product _product;
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                if (value != null && string.IsNullOrEmpty(ProductNameSnapshot))
                {
                    ProductNameSnapshot = value.Name;
                    ProductUnitSnapshot = value.Unit;
                }
            }
        }
        public int Quantity { get; set; }

        // Поля для збереження "скриншоту" даних
        public string ProductNameSnapshot { get; set; }
        public string ProductUnitSnapshot { get; set; }
    }

    // Клас самої накладної
    public class Waybill
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public bool IsIncoming { get; set; }

        public List<WaybillItem> Items { get; set; } = new List<WaybillItem>();

        [JsonIgnore]
        public string Operation => IsIncoming ? "Прихід (+)" : "Витрата (-)";

        [JsonIgnore]
        public string Details
        {
            get
            {
                if (Items == null || Items.Count == 0) return "Немає товарів";

                var list = new System.Collections.Generic.List<string>();
                foreach (var item in Items)
                {
                    string name = !string.IsNullOrEmpty(item.ProductNameSnapshot) ? item.ProductNameSnapshot : item.Product?.Name;
                    string unit = !string.IsNullOrEmpty(item.ProductUnitSnapshot) ? item.ProductUnitSnapshot : item.Product?.Unit;

                    list.Add($"{name}: {item.Quantity} {unit}");
                }
                return string.Join("; ", list);
            }
        }
    }
}