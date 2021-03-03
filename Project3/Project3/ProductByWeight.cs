using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class ProductByWeight : Product
    {
        private double price;
        private double pricePerOunce;
        private double ounces;

        public override double Price
        {
            get { return (pricePerOunce * ounces); }
            set { price = value; }
        }

        /// <summary>
        /// displays the proper promt for console output
        /// </summary>
        public override void Prompt()
        {
            Console.WriteLine("How many ounces would of this item would you like?");
        }

        /// <summary>
        /// sets the quantity of an item
        /// </summary>
        /// <param name="unit">the number of unit quantity to set</param>
        public override void SetUnits(int unit)
        {
            ounces = unit;
        }

        /// <summary>
        /// returns a string of the quantity type of an item
        /// </summary>
        /// <returns></returns>
        public override string GetUnits()
        {
            return ounces.ToString();
        }

        /// <summary>
        /// returns the name of the units for console output
        /// </summary>
        /// <returns></returns>
        public override string GetUnitsName()
        {
            return "ounces";
        }

        /// <summary>
        /// decreases the quantity of the products units
        /// </summary>
        /// <param name="decrease">the amount to decrease the quantity by</param>
        public override void DecreaseUnits(int decrease)
        {
            ounces -= decrease;
        }

        public double PricePerOunce
        {
            get { return pricePerOunce; }
            set { pricePerOunce = value; }
        }
        public double Ounces
        {
            get { return ounces; }
            set { ounces = value; }
        }
    }
}
