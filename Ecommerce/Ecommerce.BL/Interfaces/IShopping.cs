using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Data.Models;

namespace Ecommerce.BL.Interfaces
{
   public interface IShopping
    {
        #region Store Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        List<Inventory> ListAllStoreInvens();

        List<Inventory> ListStoreInven(int storeId);

        List<FavoriteStore> ListAllFavoriteStores();

        public Cart CreateCart(int locationId, string username);

        public Cart EditCart(Cart cart);

        public Cart DeleteCart(Cart cart);

        public Order CreateOrder();

        public Order EditOrder(Order order);

        public Order DeleteOrder(Order order);

        public FavoriteStore AddFavoriteStore();
        #endregion

        #region Admin Store Methods
        List<Order> AllStoreOrders(int storeId);

        #endregion

        #region Helpers
        public Store GetStore(int storeId);

        public int GetLocationNumber(int storeId);

        public void ApplyDiscounts();
        #endregion

    }
}
