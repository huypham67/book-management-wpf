﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }       
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Book? Book { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
