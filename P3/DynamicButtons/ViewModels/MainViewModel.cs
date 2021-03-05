using DynamicButtons.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DynamicButtons.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<InventoryItem> Products { get; set; }
        public InventoryItem SelectedProduct { get; set; }

        public Product SelectedCartItem { get; set; }
        public ObservableCollection<Product> Cart { get; set; }

        public string Subtotal => $"Subtotal {Cart.Sum(i => i.Price):C}";
        public string Tax => $"Tax {(Cart.Sum(i => i.Price))*.07:C}";
        public string Total => $"Total {(Cart.Sum(i => i.Price))*1.07:C}";

        public string localData;

        public MainViewModel()
        {
            Products = new ObservableCollection<InventoryItem>();
            Cart = new ObservableCollection<Product>();
            localData = AppDataPaths.GetDefault().LocalAppData;
            var filePath = $"{localData}\\Inventory.txt";

            //if there is no XML, create these 20 entries for purchase
            if(!File.Exists(filePath))
            {

                //price by quantity items
                Products.Add(new InventoryItem { Name = "Water", Description = "You need it", Price = 1.5, Type="Quantity:" });
                Products.Add(new InventoryItem { Name = "Coffee", Description = "You need it more", Price = 3.5, Type = "Quantity:" });
                Products.Add(new InventoryItem { Name = "Cinnamon Toast Crunch", Description = "Kelogs Cereal", Price = 2.59, Type = "Quantity:" });
                Products.Add(new InventoryItem { Name = "Frosted Flakes", Description = "Kelogs Cereal", Price = 2.39, Type = "Quantity:" });
                Products.Add(new InventoryItem { Name = "Pop Tarts", Description = "Kelogs", Price = 3.59, Type = "Quantity:" });
                Products.Add(new InventoryItem { Name = "Kombucha", Description = "GT Dave's", Price = 2.99, Type = "Quantity:" });
                Products.Add(new InventoryItem { Name = "Cheese", Description = "Fresh Mozzarella", Price = 3.99, Type = "Quantity:" });
                Products.Add(new InventoryItem { Name = "Eggs", Description = "1 Dozen", Price = 1.99, Type = "Quantity:" });
                Products.Add(new InventoryItem { Name = "Bacon", Description = "12 Strips", Price = 4.49, Type = "Quantity:" });
                Products.Add(new InventoryItem { Name = "Milk", Description = "1 Gallon", Price = 2.39, Type = "Quantity:" });

                Products.Add(new InventoryItem { Name = "Apples", Description = "Granny Smith Apple", Price = 0.59, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Bananas", Description = "Organic", Price = 0.69, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Tomatoes", Description = "Vine Ripe", Price = 0.89, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Potatos", Description = "Russet", Price = 0.49, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Sweet Potatos", Description = "Organic", Price = 0.59, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Asparagus", Description = "Organic", Price = 0.79, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Bell Peppers", Description = "Green", Price = 0.69, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Peaches", Description = "Sweet Georia", Price = 0.59, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Onions", Description = "Yellow", Price = 0.39, Type = "Ounces:" });
                Products.Add(new InventoryItem { Name = "Plum", Description = "Red", Price = 0.49, Type = "Ounces:" });

                File.WriteAllText(filePath, JsonConvert.SerializeObject(Products));
            }

            Products = JsonConvert.DeserializeObject<ObservableCollection<InventoryItem>>(File.ReadAllText(filePath));
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
            NotifyPropertyChanged("Subtotal");
        }

        public void Remove()
        {
            if (SelectedCartItem == null)
            {
                return;
            }
            if (Cart.Any(i => i.Id.Equals(SelectedCartItem.Id)))
            {
                Cart.FirstOrDefault(i => i.Id.Equals(SelectedCartItem.Id)).Units--;
                if((SelectedCartItem).Units <= 0)
                {
                    Cart.Remove(SelectedCartItem);
                }
            }

            SelectedCartItem = null;
            NotifyPropertyChanged("SelectedCartItem");
            NotifyPropertyChanged("Subtotal");
        }

        public void CheckOut()
        {
            using (StreamWriter reciept = new StreamWriter($"{localData}\\reciept"))
            {
                foreach(Product p in Cart)
                {
                    reciept.WriteLine(p.Display);
                }
                reciept.WriteLine("-----------------------");
                reciept.WriteLine(Subtotal);
                reciept.WriteLine(Tax);
                reciept.WriteLine(Total);
            }
            Cart.Clear();
            NotifyPropertyChanged("Cart");
            NotifyPropertyChanged("Subtotal");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
