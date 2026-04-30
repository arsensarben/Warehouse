using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Models;
using System.IO;
using System.Text.Json;

namespace Warehouse.Services
{
    public class Warehouse
    {
        public List<Product> Inventory { get; set; } = new List<Product>();
        public List<Waybill> Waybills { get; set; } = new List<Waybill>();

        public void RegisterIncoming(Waybill waybill)
        {
            Waybills.Add(waybill);
            foreach (var item in waybill.Items)
            {
                // ШУКАЄМО ПО СНАПШОТУ
                var product = Inventory.FirstOrDefault(p => p.Name == item.ProductNameSnapshot);

                if (product != null)
                {
                    product.Quantity += item.Quantity;
                    product.LastDeliveryDate = waybill.Date;
                }
                else
                {
                    // Якщо це зовсім новий товар (з UI він сюди прийде живим)
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
                // ШУКАЄМО ПО СНАПШОТУ!
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
            // Перетворюємо весь наш склад (товари і накладні) у текст
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
                // Розшифровуємо текст назад у об'єкт складу
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
