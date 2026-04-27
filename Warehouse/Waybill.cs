using System;
using System.Collections.Generic;

namespace Warehouse
{
    public class Waybill
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public bool IsIncoming { get; set; } // true - прибуткова, false - видаткова
        public Dictionary<Product, int> Items { get; set; } = new Dictionary<Product, int>();
    }
}