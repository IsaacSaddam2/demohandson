using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.Truyum.Utility;

namespace Com.Cognizant.Truyum.Dao
{
    public class MenuItemDaoCollection : IMenuItemDao
    {
        static List<MenuItem> menuItemList = new List<MenuItem>();
        public MenuItemDaoCollection()
        {
            if (menuItemList.Count == 0)
            {
                menuItemList.Add(new MenuItem(0, "Sandwich", 99.00, true, DateUtility.ConvertToDate("2017-03-15"), "Main Course", true));

                menuItemList.Add(new MenuItem(1, "Biryani", 129.00, true, DateUtility.ConvertToDate("2017-12-23"), "Main Course", false));

                menuItemList.Add(new MenuItem(2, "Pizza", 149.00, true, DateUtility.ConvertToDate("2018-08-21"), "Main Course", false));

                menuItemList.Add(new MenuItem(3, "French Fries", 57.00, false, DateUtility.ConvertToDate("2017-07-02"), "Starters", true));

                menuItemList.Add(new MenuItem(4, "Choclate", 32.00, true, DateUtility.ConvertToDate("2022-11-02"), "Dessert", true));
            }
            /* foreach(var l in menuItemList)
             {
                 Console.WriteLine(  l.ToString());
             }*/
        }


        public static List<MenuItem> MenuItemList { get => menuItemList; set => menuItemList = value; }

        public MenuItem GetMenuItem(long menuItemId)
        {
            return menuItemList.Find(c => c.Id == menuItemId);
        }

        public List<MenuItem> GetMenuItemListAdmin()
        {
            return menuItemList;
        }

        public List<MenuItem> GetMenuItemListCustomer()
        {
            List<MenuItem> clist = new List<MenuItem>();

            foreach (var list in menuItemList)
            {
                if (list.DateOfLaunch < DateTime.Now
                    && list.Active == true)
                {
                    clist.Add(list);
                    /*Console.WriteLine(list.ToString());*/
                }
            }



            return clist;
        }

        public void ModifyMenuItem(MenuItem menuItem)
        {
            Console.WriteLine("\nEnter new Name");
            string name = Console.ReadLine();
            Console.WriteLine("\nEnter new Price");
            //double price = Convert.ToDouble(Console.ReadLine());
            string price = Console.ReadLine();

            Console.WriteLine("\nEnter new Active Status  true/false");
            //bool status = Convert.ToBoolean(Console.ReadLine());
            string status = Console.ReadLine();

            Console.WriteLine("\nEnter category");
            //string category = Console.ReadLine();
            string category = Console.ReadLine();
            Console.WriteLine("\nEnter delivery status  true/false\n");
            //bool delstatus = Convert.ToBoolean(Console.ReadLine());
            string delstatus = Console.ReadLine();

            int id = Convert.ToInt32(menuItem.Id);
            if (name.Length != 0)
            menuItem.Name = name;

            if(price.Length!=0)
            menuItem.Price = Convert.ToDouble(price);
            
            if(status.Length!=0)
            menuItem.Active = Convert.ToBoolean(status);

            if(category.Length!=0)
            menuItem.Category = category;

            if(delstatus.Length!=0)
            menuItem.FreeDelivery = Convert.ToBoolean(delstatus);


           /* menuItemList.Insert(id, menuItem);
            menuItemList.RemoveAt(id+1);*/

            Console.WriteLine("Items modified successfully\n\n");

        }
    }
}
