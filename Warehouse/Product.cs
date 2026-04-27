using System;

namespace WarehouseApp
{
    public class Product
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime LastDeliveryDate { get; set; }
    }
}
