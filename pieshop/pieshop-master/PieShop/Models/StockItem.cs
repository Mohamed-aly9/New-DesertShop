using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PieShop.Models
{
    public class StockItem
    {
        [Key]
        public Guid id { get; set; }

        public string name { get; set; }

        public decimal Price { get; set; }
    }
}
