using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model
{
    [Table("ItemOrder")]

    public class ItemOrder
    {
        
        public int OId { get; set; }

        public int ProductId { get; set; } 

        public int Quantity { get; set; } = 0;

        public Order Order { get; set; }

        public Product Product { get; set; }
        
    }
}
