using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class ProductByQuantity : Product
    {
        private double price;
        private double unitPrice;
        private int units;

        public override double Price
        {
            get { return (unitPrice * units); }
            set { price = value; }
        }

        /// <summary>
        /// displays the proper promt for console output
        /// </summary>
        public override void Prompt()
        {
            Console.WriteLine("How many units would of this item would you like?");
        }

        /// <summary>
        /// sets the quantity of an item
        /// </summary>
        /// <param name="unit">the number of unit quantity to set</param>
        public override void SetUnits(int unit)
        {
            units = unit;
        }

        /// <summary>
        /// returns a string of the quantity type of an item
        /// </summary>
        /// <returns></returns>
        public override string GetUnits()
        {
            return units.ToString();
        }

        /// <summary>
        /// returns the name of the units for console output
        /// </summary>
        /// <returns></returns>
        public override string GetUnitsName()
        {
            return "units";
        }

        /// <summary>
        /// decreases the quantity of the products units
        /// </summary>
        /// <param name="decrease">the amount to decrease the quantity by</param>
        public override void DecreaseUnits(int decrease)
        {
            units -= decrease;
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public int Units
        {
            get { return units; }
            set { units = value; }
        }

    }
}
