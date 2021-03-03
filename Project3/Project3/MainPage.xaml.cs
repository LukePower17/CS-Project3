using Assignment3;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
//initial commit to laptop

namespace Project3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        int items;
        int page = 0;
        List<Product> Inventory;
        List<int> addedItems;
        ShoppingCart cart;
        static string label = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage()
        {
            this.InitializeComponent();

            Inventory = new List<Product>();
            addedItems = new List<int>();
            LoadInv(ref Inventory);
            cart = new ShoppingCart();
        }

        private string Item
        {
            get
            {
                return label;
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            page++;
            ViewInv(Inventory, ref cart, ref addedItems, page);
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            Debug.Write("In inventory click");

            ViewInv(Inventory, ref cart, ref addedItems, page);
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Item1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Item2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Allows the user to view the inventory and update their cart
        /// </summary>
        /// <param name="inv">passes the list of products to be output to console</param>
        /// <param name="cart">passes the users cart by refernce so it can be updated</param>
        /// <param name="addedItems">A list of items that have already been added to the cart. allows for item quantity to be updated</param>
        void ViewInv(List<Product> inv, ref ShoppingCart cart, ref List<int> addedItems, int page)
        {
            int i = 0;
            int item = 0;

            Debug.Write("In view inv");
            label = "TEST";
            NotifyPropertyChanged("Item");

            for (i = 0; i < 5; i++)
            {
                //if ((page * 5 - 5) > inv.Count)
                //{

                //}
                //else if(i==0)
                //{
                //    label = inv[i].ID + inv[i].Name + "Descrption: " + inv[i].Description;
                //    NotifyPropertyChanged("Item");
                //}

                label = "TEST";
                NotifyPropertyChanged("Item");
            }
        }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            Debug.Write("In prop changed");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// initializes the inventory list of products that the user will be available to use
        /// </summary>
        /// <param name="inv">passes the inv list by refernce so inv can be updated</param>
        static void LoadInv(ref List<Product> inv)
        {
            //Console.WriteLine("In Load inv");

            Debug.Write("In Load inv");

            ProductByWeight[] pw = new ProductByWeight[10];
            ProductByQuantity[] pq = new ProductByQuantity[10];

            for (int i = 0; i < 10; i++)
            {
                pw[i] = new ProductByWeight();
            }
            for (int i = 0; i < 10; i++)
            {
                pq[i] = new ProductByQuantity();
            }


            pw[0].Name = "Apples";
            pw[0].Description = "Granny Smith Apple";
            pw[0].PricePerOunce = 0.59;
            pw[0].ID = 1;

            pw[1].Name = "Bananas";
            pw[1].Description = "Organic";
            pw[1].PricePerOunce = 0.69;
            pw[1].ID = 2;

            pw[2].Name = "Tomatoes";
            pw[2].Description = "Vine Ripe";
            pw[2].PricePerOunce = 0.89;
            pw[2].ID = 3;

            pw[3].Name = "Potatos";
            pw[3].Description = "Russet";
            pw[3].PricePerOunce = 0.49;
            pw[3].ID = 4;

            pw[4].Name = "Sweet Potatos";
            pw[4].Description = "Organic";
            pw[4].PricePerOunce = 0.59;
            pw[4].ID = 5;

            pw[5].Name = "Asparagus";
            pw[5].Description = "Organic";
            pw[5].PricePerOunce = 0.79;
            pw[5].ID = 6;

            pw[6].Name = "Bell Peppers";
            pw[6].Description = "Green";
            pw[6].PricePerOunce = 0.69;
            pw[6].ID = 7;

            pw[7].Name = "Peaches";
            pw[7].Description = "Sweet Georia";
            pw[7].PricePerOunce = 0.59;
            pw[7].ID = 8;

            pw[8].Name = "Onions";
            pw[8].Description = "Yellow";
            pw[8].PricePerOunce = 0.39;
            pw[8].ID = 9;

            pw[9].Name = "Plum";
            pw[9].Description = "Red";
            pw[9].PricePerOunce = 0.49;
            pw[9].ID = 10;

            ///////////////////////////////

            pq[0].Name = "Cinnamon Toast Crunch";
            pq[0].Description = "Kelogs Cereal";
            pq[0].UnitPrice = 2.59;
            pq[0].ID = 11;

            pq[1].Name = "Frosted Flakes";
            pq[1].Description = "Kelogs Cereal";
            pq[1].UnitPrice = 2.39;
            pq[1].ID = 12;

            pq[2].Name = "Pop Tarts";
            pq[2].Description = "Kelogs";
            pq[2].UnitPrice = 3.59;
            pq[2].ID = 13;

            pq[3].Name = "Kombucha";
            pq[3].Description = "GT Dave's";
            pq[3].UnitPrice = 2.99;
            pq[3].ID = 14;

            pq[4].Name = "Cheese";
            pq[4].Description = "Fresh Mozzarella";
            pq[4].UnitPrice = 3.99;
            pq[4].ID = 15;

            pq[5].Name = "Eggs";
            pq[5].Description = "1 Dozen";
            pq[5].UnitPrice = 1.99;
            pq[5].ID = 16;

            pq[6].Name = "Bacon";
            pq[6].Description = "12 Strips";
            pq[6].UnitPrice = 4.49;
            pq[6].ID = 17;

            pq[7].Name = "Milk";
            pq[7].Description = "1 Gallon";
            pq[7].UnitPrice = 2.39;
            pq[7].ID = 18;

            pq[8].Name = "Orange Juice";
            pq[8].Description = "Half Gallon";
            pq[8].UnitPrice = 3.49;
            pq[8].ID = 19;

            pq[9].Name = "Bread";
            pq[9].Description = "Pepperidge Farms Loaf";
            pq[9].UnitPrice = 1.99;
            pq[9].ID = 20;

            foreach (var product in pw)
            {
                inv.Add(product);
            }
            foreach (var product in pq)
            {
                inv.Add(product);
            }

        }


        private void Item1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Item2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Item3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Item4_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Item5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
