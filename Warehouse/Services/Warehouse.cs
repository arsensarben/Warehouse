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
                var product = Inventory.FirstOrDefault(p => p.Name == item.Product.Name);
                if (product != null)
                {
                    product.Quantity += item.Quantity;
                    product.LastDeliveryDate = waybill.Date;
                }
                else
                {
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
                var product = Inventory.FirstOrDefault(p => p.Name == item.Product.Name);

                if (product != null && product.Quantity >= item.Quantity)
                {
                    product.Quantity -= item.Quantity;
                }
                else
                {
                    throw new Exception($"Недостатньо товару {item.Product.Name} на складі!");
                }
            }
        }

        // Метод збереження у файл
        public void SaveData()
        {
            // Налаштовуємо красиве форматування JSON (з відступами)
            var options = new JsonSerializerOptions { WriteIndented = true };
            // Перетворюємо весь наш склад (товари і накладні) у текст
            string json = JsonSerializer.Serialize(this, options);
            // Записуємо текст у файл
            File.WriteAllText("warehouse_data.json", json);
        }

        // Метод завантаження з файлу
        public void LoadData()
        {
            // Перевіряємо, чи існує взагалі такий файл (щоб не було помилки при першому запуску)
            if (File.Exists("warehouse_data.json"))
            {
                string json = File.ReadAllText("warehouse_data.json");
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
