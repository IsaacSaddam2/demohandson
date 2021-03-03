using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Model
{
    public class MenuItem
    {
        private long id;
        private string name;
        private double price;
        private bool active;
        private DateTime dateOfLaunch;
        private string category;
        private bool freeDelivery;

        public MenuItem(long id, string name, double price, bool active, DateTime dateOfLaunch, string category, bool freeDelivery)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Active = active;
            this.DateOfLaunch = dateOfLaunch;
            this.Category = category;
            this.FreeDelivery = freeDelivery;
        }

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public bool Active { get => active; set => active = value; }
        public DateTime DateOfLaunch { get => dateOfLaunch; set => dateOfLaunch = value; }
        public string Category { get => category; set => category = value; }
        public bool FreeDelivery { get => freeDelivery; set => freeDelivery = value; }

        public override string ToString()
        {
            return String.Format("{0}   {1,-12}     {2,-12}     {3,-12}     {4,-18}     {5,-12} {6,-12}",id,name,price,active,dateOfLaunch.ToShortDateString(),category,freeDelivery);
        }

    }
}
