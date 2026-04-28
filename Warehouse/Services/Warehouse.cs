using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Models;

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
                var product = Inventory.FirstOrDefault(p => p.Name == item.Key.Name);
                if (product != null)
                {
                    product.Quantity += item.Value;
                    product.LastDeliveryDate = waybill.Date;
                }
                else
                {
                    item.Key.Quantity = item.Value;
                    item.Key.LastDeliveryDate = waybill.Date;
                    Inventory.Add(item.Key);
                }
            }
        }

        public void RegisterOutgoing(Waybill waybill)
        {
            Waybills.Add(waybill);
            foreach (var item in waybill.Items)
            {
                var product = Inventory.FirstOrDefault(p => p.Name == item.Key.Name);

                if (product != null && product.Quantity >= item.Value)
                {
                    product.Quantity -= item.Value;
                }
                else
                {
                    throw new Exception($"Недостатньо товару {item.Key.Name} на складі!");
                }
            }
        }
    }
}
