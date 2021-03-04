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

        public double Price { get; set; }

        public Guid Id { get; private set; }

        public InventoryItem()
        {
            Id = System.Guid.NewGuid();
        }
    }
}
