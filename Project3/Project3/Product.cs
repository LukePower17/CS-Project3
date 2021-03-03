using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class Product
    {
        private double price;
        private string name;
        private string description;
        private int id;

        public virtual double Price
        {
            get { return price; }
            set { price = value; }
        }
        public virtual void Prompt() { }
        public virtual void SetUnits(int unit) { }
        public virtual string GetUnits() { return ""; }
        public virtual string GetUnitsName() { return ""; }
        public virtual void DecreaseUnits(int decrease) { }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
