using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Com.Cognizant.Truyum.Model;

namespace Com.Cognizant.Truyum.Dao
{
    public class MenuItemDaoTest
    {

        public MenuItemDaoTest()
        {
            CartDaoCollection cd1 = null;
            bool loop = true;
            while (loop)
            {
                WriteLine("************************************************************");
                WriteLine("Choose ur activity.");
                WriteLine("1.Display Admin Menu List \n2.Display Customer Menu List\n");
                int choice = int.Parse(ReadLine());
                WriteLine();
                switch (choice)
                {
                    case 1:
                        MenuItemDaoCollection mc = new MenuItemDaoCollection();
                        Console.WriteLine("Admin MenuList\n");
                        Console.WriteLine("{0}   {1,-12}    {2,-12}     {3,-12}     {4,-12}\n", "Id", "Name", "Price", "Category", "FreeDelivery");
                        foreach (MenuItem c in mc.GetMenuItemListAdmin())
                        {
                            Console.WriteLine(c.ToString());
                        }

                        WriteLine("\nPress 1 to Modify MenuItem");

                        string temp = ReadLine();
                        if (temp.Length != 0)
                        {
                            if (int.Parse(temp) == 1)
                            {
                                Console.WriteLine("\nEnter Menu Item Id which you want to edit");
                                long r = int.Parse(ReadLine());

                                if (mc.GetMenuItemListAdmin().Contains(mc.GetMenuItem(r)))
                                {
                                    mc.ModifyMenuItem(mc.GetMenuItem(r));
                                }
                            }

                        }
                        break;
                    case 2:
                        MenuItemDaoCollection m = new MenuItemDaoCollection();
                        Console.WriteLine("Customer MenuList\n");
                        Console.WriteLine("{0}   {1,-12}    {2,-12}     {3,-12}     {4,-12}\n", "Id", "Name", "Price", "Category", "FreeDelivery");
                        foreach (MenuItem c in m.GetMenuItemListCustomer())
                        {
                            Console.WriteLine(c.ToString());
                        }

                        bool loops = true;
                        while (loops)
                        {
                            Console.WriteLine("\nChoose an activity");
                            Console.WriteLine("1.Add to Cart");
                            Console.WriteLine("2.Show CartItems");
                            Console.WriteLine("3.Remove CartItem");

                            string temp2 = ReadLine();

                            if (temp2.Length != 0)
                            {

                                switch (int.Parse(temp2))
                                {
                                    case 1:
                                        Console.WriteLine("\nEnter Menu Item Id To add Into Cart\n");
                                        CartDaoCollection cd = new CartDaoCollection();
                                        cd.AddCartItem(1001, long.Parse(ReadLine()));
                                        break;

                                    case 2:
                                        cd1 = new CartDaoCollection();
                                        Console.WriteLine("\n{0}   {1,-12}    {2,-12}     {3,-12}     {4,-12}\n", "Id", "Name", "Price", "Category", "FreeDelivery");
                                        foreach (var l in cd1.GetAllCartItems(1001).MenuItemList)
                                            Console.WriteLine(l.ToString());

                                        Console.WriteLine("\nTotal Price :   {0}\n\n", cd1.GetAllCartItems(1001).Total); ;
                                        break;

                                    case 3:
                                        Console.WriteLine("Enter Id of Item to remove from Cart\n");
                                        cd1 = new CartDaoCollection();
                                        cd1.RemoveCartItem(1001, long.Parse(ReadLine()));
                                        break;

                                    default: loops = false; break;
                                }

                            }

                        }

                        break;

                    default: loop = false; break;

                }

            }

        }




    }

    }
