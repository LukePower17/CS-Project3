using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DynamicButtons.Models
{
    public class Product: INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Display
        {
            get
            {
                return $"{Name} x{Units}";
            }
        }

        public double UnitPrice { get; set; }

        private int units;
        public int Units { 
            get
            {
                return units;
            }

            set
            {
                units = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Display");
            }
        }

        public double Price => UnitPrice * Units;

        public Guid Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
