using DynamicButtons.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DynamicButtons.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<InventoryItem> Products { get; set; }
        public InventoryItem SelectedProduct { get; set; }
        public ObservableCollection<Product> Cart { get; set; }

        public string Total => $"Total {Cart.Sum(i => i.Price):C}";

        public MainViewModel()
        {
            Products = new ObservableCollection<InventoryItem>();
            Cart = new ObservableCollection<Product>();
            Products.Add(new InventoryItem { Name = "Water", Description = "You need it", Price = 1.5 });
            Products.Add(new InventoryItem { Name = "Coffee", Description = "You need it more", Price = 3.5 });
        }

        public void AddToCart()
        {
            if(SelectedProduct == null)
            {
                return;
            }
            if(Cart.Any(i => i.Id.Equals(SelectedProduct.Id)))
            {
                Cart.FirstOrDefault(i => i.Id.Equals(SelectedProduct.Id)).Units++;
            } else
            {
                Cart.Add(new Product { Name = SelectedProduct.Name, Description = SelectedProduct.Name, UnitPrice = SelectedProduct.Price, Units = 1, Id = SelectedProduct.Id });
            }

            SelectedProduct = null;
            NotifyPropertyChanged("SelectedProduct");
            NotifyPropertyChanged("Total");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
