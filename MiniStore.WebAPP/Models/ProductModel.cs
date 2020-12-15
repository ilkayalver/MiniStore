using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.WebAPP.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public int Stock { get; set; }
        public string PhotoUrl { get; set; }
        public double Price { get; set; }
    }
}
