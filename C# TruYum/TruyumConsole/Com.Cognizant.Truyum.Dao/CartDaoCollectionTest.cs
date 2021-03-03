using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.Truyum.Model;

namespace Com.Cognizant.Truyum.Dao
{
    class CartDaoCollectionTest
    {
        public static void TestRemoveCartItem()
        {
            CartDaoCollection cartDao = new CartDaoCollection();

            cartDao.RemoveCartItem(1000, 1);

       Cart c=     cartDao.GetAllCartItems(1000);

        foreach(var l in c.MenuItemList)
            {
                Console.WriteLine(l.ToString());
            }


        }
    }
}
