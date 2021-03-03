using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Model
{
    public  class Cart
    {
        private List<MenuItem> menuItemList= new List<MenuItem>();

        private double total;

        public Cart()
        {

        }

        public Cart(List<MenuItem> menuItemList)
        {
            this.menuItemList = menuItemList;
           
        }

        public List<MenuItem> MenuItemList { get => menuItemList; set => menuItemList = value; }
        public double Total {
            get
            {
               double sum = this.menuItemList.Sum(c => c.Price);
                //debugging
                //Console.WriteLine(sum);
                return sum;
            }
        }
    }
}
