using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.Truyum.Model;
using Com.Cognizant.Truyum.Utility;

namespace Com.Cognizant.Truyum.Dao
{
  public class MenuItemDaoSql:IMenuItemDao
    {

        static List<MenuItem> mlist = null;
        static List<MenuItem> clist = null;
        SqlConnection con = null;
        SqlCommand cmd = null;

        DateUtility du = new DateUtility();

        long id;
        string name;
        double price;
        bool active;
        DateTime dateOfLaunch;
        string category;
        bool freeDelivery;

        public MenuItemDaoSql()
        {
            mlist= new List<MenuItem>();
        }
        string constring = Helper.Constr;
        public List<MenuItem> GetMenuItemListAdmin()
        {
            using (con = new SqlConnection(constring))
            {
                cmd = new SqlCommand("select * from Menuitems", con);
                con.Open();
                SqlDataReader reads = cmd.ExecuteReader();
                while (reads.Read())
                {
                    id = Convert.ToInt64(reads[0]);
                    name = reads[1].ToString();
                    price = Convert.ToDouble(reads[2]);
                    active = Convert.ToBoolean(reads[3]);
                    dateOfLaunch = Convert.ToDateTime(reads[4]);
                    category = reads[5].ToString();
                    freeDelivery = Convert.ToBoolean(reads[6]);
                    mlist.Add(new MenuItem(id, name, price, active, dateOfLaunch, category, freeDelivery));

                }
            }

          
                return mlist;

        }

        public List<MenuItem> GetMenuItemListCustomer()
        {
             clist = new List<MenuItem>();
            List<MenuItem> resultlist = new List<MenuItem>();

            using (con = new SqlConnection(constring))
            {
                cmd = new SqlCommand("select * from Menuitems", con);
                con.Open();
                SqlDataReader reads = cmd.ExecuteReader();
                while (reads.Read())
                {
                    id = Convert.ToInt64(reads[0]);
                    name = reads[1].ToString();
                    price = Convert.ToDouble(reads[2]);
                    active = Convert.ToBoolean(reads[3]);
                    dateOfLaunch = Convert.ToDateTime(reads[4]);
                    category = reads[5].ToString();
                    freeDelivery = Convert.ToBoolean(reads[6]);
                    clist.Add(new MenuItem(id, name, price, active, dateOfLaunch, category, freeDelivery));

                }

            }



            foreach (var list in clist)
            {
                    /*Console.WriteLine(list.ToString());*/

                if (list.DateOfLaunch < DateTime.Now
                    && list.Active == true)
                {
                    resultlist.Add(list);
                }
            }
            return resultlist;

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

            Console.WriteLine("\nEnter new date in yyyy-MM-dd");
            string date = Console.ReadLine();

            Console.WriteLine("\nEnter category");
            //string category = Console.ReadLine();
            string category = Console.ReadLine();
            Console.WriteLine("\nEnter delivery status  true/false\n");
            //bool delstatus = Convert.ToBoolean(Console.ReadLine());
            string delstatus = Console.ReadLine();

            int id = Convert.ToInt32(menuItem.Id);
            if (name.Length != 0)
                menuItem.Name = name;

            if (price.Length != 0)
                menuItem.Price = Convert.ToDouble(price);

            if (date.Length != 0)
                menuItem.DateOfLaunch = DateUtility.ConvertToDate(date);

            if (status.Length != 0)
                menuItem.Active = Convert.ToBoolean(status);

            if (category.Length != 0)
                menuItem.Category = category;

            if (delstatus.Length != 0)
                menuItem.FreeDelivery = Convert.ToBoolean(delstatus);

            using(con= new SqlConnection(constring))
            {
               /* string query = String.Format("update Menuitems set name = {0}, price={1}, active ={2},Dol= {3}, category={4}, free_delivery={5} where item_id={6}", menuItem.Name, menuItem.Price, menuItem.Active.ToString(), menuItem.DateOfLaunch, menuItem.Category, menuItem.FreeDelivery.ToString(),id);*/
                    
                using(cmd= new SqlCommand("update Menuitems set name=@name, price=@price,active=@active,Dol=@dateol,category=@category,free_delivery=@free where item_id=@id",con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", menuItem.Name);
                    cmd.Parameters.AddWithValue("@price", menuItem.Price);
                    cmd.Parameters.AddWithValue("@active", menuItem.Active.ToString());
                    cmd.Parameters.AddWithValue("@dateol", menuItem.DateOfLaunch);
                    cmd.Parameters.AddWithValue("@category", menuItem.Category);
                    cmd.Parameters.AddWithValue("@free", menuItem.FreeDelivery.ToString());
                    cmd.Parameters.AddWithValue("@id", id); 
                    int result = cmd.ExecuteNonQuery();
                    
                }
            }
        }

        public MenuItem GetMenuItem(long menuItemId)
        {
            return mlist[(int)menuItemId];
        }
    }
}
