using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToTechnical.Models
{
    public class ItemMaster
    {
        public Guid Id { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string imagePath { get; set; }
 
    }
}
