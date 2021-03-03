using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class ShoppingCart
    {
        private List<Product> Cart = new List<Product>();
        private int size;

        /// <summary>
        /// adds an item to the cart
        /// </summary>
        /// <param name="p">item to add to the cart</param>
        public void AddItem(Product p)
        {
            Cart.Add(p);
            size++;
        }

        /// <summary>
        /// removes a product from the cart
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(int item)
        {
            Cart.RemoveAt(item);
        }

        /// <summary>
        /// returns the number of items in the cart
        /// </summary>
        /// <returns>number of items</returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// Displays all of the users items and the total price
        /// </summary>
        public void CheckoutCart()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("\n{0,-3} {1,-25} {2,-16} {3,-8}\n\n", "ID", "Name", "Quantity/Ounces", "Total"));

            foreach (var item in Cart)
            {
                sb.Append(String.Format("{0,-3} {1,-25} {2,-16} {3,-8:0.00}\n", item.ID, item.Name, item.GetUnits(), item.Price));
                sb.Append("--------------------------------------------------------------------------\n");
            }
            Console.WriteLine(sb);
            Console.WriteLine("Subtotal: " + String.Format("{0:0.00}", GetTotal()));
            double salesTax = (GetTotal() * .07);
            Console.WriteLine("Sales Tax: " + String.Format("{0:0.00}", salesTax));
            double grandTotal = (GetTotal() + salesTax);
            Console.WriteLine("Grand Total: " + String.Format("{0:0.00}\n", grandTotal));
        }

        /// <summary>
        /// shows the users shopping cart and allows them to remove items
        /// </summary>
        public void ShowCart()
        {
            int itemID = 0;
            string input = "";
            bool itemFound = false;
            int remove = 0;
            int increment = 0;
            int i = 0;

            do
            {
                increment = 0;
                itemFound = false;
                itemID = 0;

                Console.WriteLine("\nYour Current Shopping Cart:");
                var sb = new System.Text.StringBuilder();
                sb.Append(String.Format("{0,-3} {1,-25} {2,-16} {3,-8}\n\n", "ID", "Name", "Quantity/Ounces", "Total"));

                if (input.Contains("previous"))
                {
                    if (i % 5 == 0 && i > 5)
                    {
                        i -= 5;
                    }
                    else
                    {
                        i = ((i - 5) - (i % 5));
                    }
                }
                do
                {
                    sb.Append(String.Format("{0,-3} {1,-25} {2,-16} {3,-8:0.00}\n", Cart[i].ID, Cart[i].Name, Cart[i].GetUnits(), Cart[i].Price));
                    i++;
                } while (i % 5 != 0 && i != Cart.Count);

                Console.WriteLine(sb);

                Console.WriteLine("\nPlease select an option:");
                if (i > 5)
                {
                    Console.WriteLine("Type \"Previous\" to view the previous page");
                }
                if (i < Cart.Count)
                {
                    Console.WriteLine("Type \"Next\" to view the next page");
                }

                Console.WriteLine("Enter the item id you would like to remove, or type \"Menu\" to exit to the menu.");

                input = Console.ReadLine();
                input = input.ToLower();
                bool result = int.TryParse(input, out itemID);

                if (result)
                {
                    foreach (var item in Cart)
                    {
                        if (item.ID == itemID)
                        {
                            itemID = increment;
                            itemFound = true;
                        }
                        increment++;
                    }
                    if (itemFound)
                    {
                        Console.Write("How many " + Cart[itemID].GetUnitsName() + " of " + Cart[itemID].Name + " would you like to remove? ");
                        remove = Convert.ToInt32(Console.ReadLine());
                        if (remove == Convert.ToInt32(Cart[itemID].GetUnits()))
                        {
                            Console.WriteLine("All " + Cart[itemID].GetUnitsName() + " of " + Cart[itemID].Name + " removed.");
                            RemoveItem(itemID);
                        }
                        else if (remove < Convert.ToInt32(Cart[itemID].GetUnits()))
                        {
                            Cart[itemID].DecreaseUnits(remove);
                            Console.WriteLine(remove.ToString() + " " + Cart[itemID].GetUnitsName() + " of " + Cart[itemID].Name + " removed.");
                        }
                        else
                        {
                            Console.WriteLine("You cannot remove more than the number of " + Cart[itemID].GetUnitsName() + " you have in your cart");
                        }
                    }
                    else
                    {
                        Console.WriteLine("This item cannot be found.");
                    }
                }

                if (input.Contains("next"))
                {
                    //keep i the same
                }
                else
                {
                    if ((i % 5) == 0)
                    {
                        i -= 5;
                    }
                    else
                    {
                        i -= (i % 5);
                    }
                }
            } while (!input.Contains("menu"));
        }

        /// <summary>
        /// gets the subtotal of all the items in the cart
        /// </summary>
        /// <returns></returns>
        public double GetTotal()
        {
            double total = 0;

            foreach(var product in Cart)
            {
                total += product.Price;
            }

            return total;
        }

    }
}
