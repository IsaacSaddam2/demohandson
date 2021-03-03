using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Dao
{
  public  class CartDaoCollection : ICartDao
    {
        static Dictionary<long, Cart> userCarts;

        public CartDaoCollection()
        {
            if(userCarts==null)
            {
                userCarts = new Dictionary<long, Cart>();
                MenuItemDaoCollection dao = new MenuItemDaoCollection();


                // creating users and storing carts for users  
                List<MenuItem> list = new List<MenuItem>();
                list.Add(dao.GetMenuItem(1));
                Cart c = new Cart(list);
                userCarts.Add(1000, c);

                MenuItem item = dao.GetMenuItem(2);
                userCarts[1000].MenuItemList.Add(item);

                userCarts.Add(1001, c);
                userCarts[1001].MenuItemList.Add(dao.GetMenuItem(0));

                //debugging
             
           /*     foreach( var l in userCarts[1000].MenuItemList)
                {
                    Console.WriteLine(l.Name+" "+l.Price);
                }
                Console.WriteLine("the user 1000 price"+UserCarts[1000].Total);*/
                


            }
        }

        public static Dictionary<long, Cart> UserCarts { get => userCarts; set => userCarts = value; }

        public void AddCartItem(long userId, long menuItemId)
        {
            MenuItemDaoCollection menuItemDao = new MenuItemDaoCollection();

            MenuItem item = menuItemDao.GetMenuItem(menuItemId);

            if (userCarts.ContainsKey(userId))
            {
                userCarts[userId].MenuItemList.Add(item);
            }
            else
            {
               // if useris new create new user and new cart 

                List<MenuItem> l = new List<MenuItem>();
                l.Add(item);

                Cart c = new Cart(l);

                UserCarts.Add(userId, c);
            }
        }

        public Cart GetAllCartItems(long userId)
        {

            return userCarts[userId];
        }

        public void RemoveCartItem(long userId, long productId)
        {
            Cart c = userCarts[userId];
            c.MenuItemList.RemoveAt(Convert.ToInt32(productId));
        }
    }
}
