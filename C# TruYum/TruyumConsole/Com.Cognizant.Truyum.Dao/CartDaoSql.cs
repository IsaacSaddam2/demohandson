using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Dao
{
   public class CartDaoSql : ICartDao
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        string conn = Helper.Constr;

        public void AddCartItem(long userId, long menuItemId)
        {
            using(con= new SqlConnection(conn))
            {
                using(cmd= new SqlCommand("insert into Cart values(@user,@item)",con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@user", userId);
                    cmd.Parameters.AddWithValue("@item",(int)menuItemId);
                    try
                    {

                        if (cmd.ExecuteNonQuery() > 0)
                            Console.WriteLine("Item {0} is added", menuItemId);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Item {0} is not valid", menuItemId);

                    }
                }
            }
        }

            public static List<int> c_id = new List<int>();
        public Cart GetAllCartItems(long userId)
        {
            List<MenuItem> clist = new List<MenuItem>();
            int cart_id;
            long id;
            string name;
            double price;
            bool active;
            DateTime dateOfLaunch;
            string category;
            bool freeDelivery;

            string constring = Helper.Constr;
            using (con = new SqlConnection(constring))
            {
                cmd = new SqlCommand("select c.cart_id, c.item_id,m.name,m.price,m.active,m.Dol,m.category,m.free_delivery from Cart c join MenuItems m on c.item_id=m.item_id where c.userid=@user order by item_id ", con);
                con.Open();
                cmd.Parameters.AddWithValue("@user", userId);
                SqlDataReader reads = cmd.ExecuteReader();
                while (reads.Read())
                {
                    cart_id = Convert.ToInt32(reads[0]);
                    id = Convert.ToInt64(reads[1]);
                    name = reads[2].ToString();
                    price = Convert.ToDouble(reads[3]);
                    active = Convert.ToBoolean(reads[4]);
                    dateOfLaunch = Convert.ToDateTime(reads[5]);
                    category = reads[6].ToString();
                    freeDelivery = Convert.ToBoolean(reads[7]);
                    clist.Add(new MenuItem(id, name, price, active, dateOfLaunch, category, freeDelivery));
                    c_id.Add(cart_id);
                }

            }
               return new Cart(clist);

        }

        public void RemoveCartItem(long userId, long menuItemId)
        {
            //Console.WriteLine(userId);

            using (con = new SqlConnection(conn))
            {
                using (cmd = new SqlCommand("deleteItems", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param;

                    //Note: ParameterDirection names shouls be same as indexer stored prodeure

                    param= cmd.Parameters.Add("@uid", SqlDbType.BigInt);
                    param.Value = userId;

                     param = cmd.Parameters.Add("@itemid", SqlDbType.Int);
                    param.Value = menuItemId;

                    try
                    {

                     if(cmd.ExecuteNonQuery()>1)
                        Console.WriteLine("Removed Item Successfully!");
                     else
                        Console.WriteLine("Your cart doesn't contain this item!");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine( e.Message);
                    }
                }
            }
        }
    }
}
