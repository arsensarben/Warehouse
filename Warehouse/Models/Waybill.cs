using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Warehouse.Models
{
    // Клас для зберігання однієї позиції в накладній
    public class WaybillItem
    {
        private Product _product;

        // Ігноруємо при збереженні в JSON, щоб уникнути дублювання всього об'єкта товару і зациклення
        [JsonIgnore]
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                // Автоматично робимо "знімок" даних при прив'язці товару, 
                // щоб історія накладної не зламалася, якщо сам товар колись видалять із каталогу
                if (value != null && string.IsNullOrEmpty(ProductNameSnapshot))
                {
                    ProductNameSnapshot = value.Name;
                    ProductUnitSnapshot = value.Unit;
                }
            }
        }
        public int Quantity { get; set; }

        // Поля для збереження "скриншоту" даних (саме вони назавжди записуються у файл)
        public string ProductNameSnapshot { get; set; }
        public string ProductUnitSnapshot { get; set; }
    }

    // Клас самої накладної
    public class Waybill
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }

        // Вказує тип операції: true — прибуття на склад, false — видаток (списання)
        public bool IsIncoming { get; set; }

        // Список усіх позицій товарів у цій накладній
        public List<WaybillItem> Items { get; set; } = new List<WaybillItem>();

        // Динамічне поле для інтерфейсу. Не зберігаємо в JSON, бо воно обчислюється "на льоту" з IsIncoming
        [JsonIgnore]
        public string Operation => IsIncoming ? "Прихід (+)" : "Витрата (-)";

        // Динамічний текст для таблиці історії. Склеює всі позиції в один рядок
        [JsonIgnore]
        public string Details
        {
            get
            {
                if (Items == null || Items.Count == 0) return "Немає товарів";

                var list = new List<string>();
                foreach (var item in Items)
                {
                    // Пріоритетно беремо назву зі збереженого знімка (це надійніше), 
                    // а якщо знімок порожній — тягнемо з самого об'єкта Product
                    string name = !string.IsNullOrEmpty(item.ProductNameSnapshot) ? item.ProductNameSnapshot : item.Product?.Name;
                    string unit = !string.IsNullOrEmpty(item.ProductUnitSnapshot) ? item.ProductUnitSnapshot : item.Product?.Unit;

                    list.Add($"{name}: {item.Quantity} {unit}");
                }
                return string.Join("; ", list);
            }
        }
    }
}