using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicButtons.Models
{
    public class InventoryItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Display
        {
            get
            {
                return String.Format("{0,-25}{1,-25} Price per {2,-12} ${3,-4}",$"{Name}",$"{Description}",$"{Type}",$"{Price}");
            }
        }

        public double Price { get; set; }

        public Guid Id { get; private set; }

        public InventoryItem()
        {
            Id = System.Guid.NewGuid();
        }
    }
}
