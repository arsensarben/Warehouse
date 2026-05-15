using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Models;
using System.IO;
using System.Text.Json;

namespace Warehouse.Services
{
    // Головний клас, який об'єднує всі дані програми
    public class Warehouse
    {
        public List<Product> Inventory { get; set; } = new List<Product>();
        public List<Waybill> Waybills { get; set; } = new List<Waybill>();

        public void RegisterIncoming(Waybill waybill)
        {
            Waybills.Add(waybill);
            foreach (var item in waybill.Items)
            {
                // ШУКАЄМО ПО СНАПШОТУ, щоб уникнути втрати зв'язку, якщо оригінал змінено
                var product = Inventory.FirstOrDefault(p => p.Name == item.ProductNameSnapshot);

                if (product != null)
                {
                    product.Quantity += item.Quantity;
                    product.LastDeliveryDate = waybill.Date;
                }
                else
                {
                    // Просто перевірка ()
                    item.Product.Quantity = item.Quantity;
                    item.Product.LastDeliveryDate = waybill.Date;
                    Inventory.Add(item.Product);
                }
            }
        }

        public void RegisterOutgoing(Waybill waybill)
        {
            Waybills.Add(waybill);
            foreach (var item in waybill.Items)
            {
                // ШУКАЄМО ПО СНАПШОТУ для збереження цілісності історії
                var product = Inventory.FirstOrDefault(p => p.Name == item.ProductNameSnapshot);

                if (product != null && product.Quantity >= item.Quantity)
                {
                    product.Quantity -= item.Quantity;
                }
                else
                {
                    // У помилці теж використовуємо снапшот, бо item.Product може бути null
                    throw new Exception($"Недостатньо товару '{item.ProductNameSnapshot}' на складі!");
                }
            }
        }

        public void SaveData(string filePath = "warehouse_data.json")
        {
            // Налаштовуємо красиве форматування JSON (з відступами)
            var options = new JsonSerializerOptions { WriteIndented = true };
            // Перетворюємо весь наш склад (товари і накладні) у JSON-рядок
            string json = JsonSerializer.Serialize(this, options);
            // Записуємо текст у файл (стандартний або обраний користувачем)
            File.WriteAllText(filePath, json);
        }

        // Метод завантаження з файлу
        public void LoadData(string filePath = "warehouse_data.json")
        {
            // Перевіряємо, чи існує взагалі такий файл (щоб не було помилки при першому запуску)
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                // Розшифровуємо об'єкт Warehouse із збереженого JSON-рядка
                var loaded = JsonSerializer.Deserialize<Warehouse>(json);

                if (loaded != null)
                {
                    this.Inventory = loaded.Inventory;
                    this.Waybills = loaded.Waybills;
                }
            }
        }
    }
}
