using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Com.Cognizant.Truyum.Dao;
using Com.Cognizant.Truyum.Model;


namespace TruyumConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //MenuItemDaoTest test = new MenuItemDaoTest();
            //CartDaoCollection cd1 = null;
            CartDaoSql cd1 = null;
            long userId;

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
                        MenuItemDaoSql mc = new MenuItemDaoSql();


                        Console.WriteLine("Admin MenuList\n");
                        Console.WriteLine("{0}   {1,-12}    {2,-12}     {3,-12}     {4,-18}     {5,-12}     {6,-12}\n", "Id", "Name", "Price", "Active", "Date Of Launch", "Category", "FreeDelivery");
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
                       
                        MenuItemDaoSql mcc = new MenuItemDaoSql();
                        Console.WriteLine("Enter your user Id (any integer number)");
                        userId = long.Parse(Console.ReadLine());

                        Console.WriteLine("Customer MenuList\n");
                        Console.WriteLine("{0}   {1,-12}    {2,-12}     {3,-12}     {4,-18}     {5,-12}     {6,-12}\n", "Id", "Name", "Price", "Active", "Date Of Launch", "Category", "FreeDelivery");

                        foreach (MenuItem c in mcc.GetMenuItemListCustomer())
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
                                        CartDaoSql cd = new CartDaoSql();
                                        cd.AddCartItem(userId, long.Parse(ReadLine()));
                                        break;

                                    case 2:
                                        cd1 = new CartDaoSql();
                                        Console.WriteLine("\n{0}   {1,-12}    {2,-12}     {3,-12}     {4,-12}   {5,-12}\n","Cart_Id", "Id", "Name", "Price", "Category", "FreeDelivery");
                                        int i = 0;
                                        foreach (var l in cd1.GetAllCartItems(userId).MenuItemList)
                                        {

                                            Console.WriteLine(CartDaoSql.c_id[i]+" "+l.ToString());
                                            i++;
                                        }
                                        CartDaoSql.c_id = new List<int>();
                                        Console.WriteLine("\nTotal Price :   {0}\n\n", cd1.GetAllCartItems(userId).Total); ;
                                        break;

                                    case 3:
                                        Console.WriteLine("Enter Id of Item to remove from Cart\n");
                                        cd1 = new CartDaoSql();
                                        cd1.RemoveCartItem(userId, long.Parse(ReadLine()));
                                        break;

                                    default: loops = false; break;
                                }

                            }
                            else
                            {
                                break;
                            }


                        }

                        break;

                    default: loop = false; break;

                }

            }

            Console.Read();
        }
    }
}

/* MenuItemDaoSql sql = new MenuItemDaoSql(); 
 {
     sql.GetMenuItemList();
 }*/
