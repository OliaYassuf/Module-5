using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Shop
    {


        public string Name { get; set; }
        public string Address { get; set; }
        public string ProfileDescription { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }

        private double area;
        public double Area
        {
            get { return area; }
            set
            {
                if (value >= 0)
                    area = value;
                else
                    throw new ArgumentException("Area cannot be negative.");
            }
        }

        public Shop() : this("Unknown", "Unknown", "No description", "No phone", "No email", 0) { }

        public Shop(string name, string address) : this(name, address, "No description", "No phone", "No email", 0) { }

        public Shop(string name, string address, string profileDescription) : this(name, address, profileDescription, "No phone", "No email", 0) { }

        public Shop(string name, string address, string profileDescription, string contactPhone, string email, double area)
        {
            Name = name;
            Address = address;
            ProfileDescription = profileDescription;
            ContactPhone = contactPhone;
            Email = email;
            Area = area;
        }

        public void DisplayData()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Profile Description: {ProfileDescription}");
            Console.WriteLine($"Contact Phone: {ContactPhone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Area: {Area} square meters");
        }

        public static Shop operator +(Shop shop, double increase)
        {
            shop.Area += increase;
            return shop;
        }

        public static Shop operator -(Shop shop, double decrease)
        {
            shop.Area -= decrease;
            return shop;
        }

        public static bool operator ==(Shop shop1, Shop shop2)
        {
            return shop1.Area == shop2.Area;
        }

        public static bool operator !=(Shop shop1, Shop shop2)
        {
            return !(shop1 == shop2);
        }

        public static bool operator <(Shop shop1, Shop shop2)
        {
            return shop1.Area < shop2.Area;
        }

        public static bool operator >(Shop shop1, Shop shop2)
        {
            return shop1.Area > shop2.Area;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Shop shop = (Shop)obj;
            return Area == shop.Area;
        }

        public override int GetHashCode()
        {
            return Area.GetHashCode();
        }
    }

}
