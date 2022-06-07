using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Data.Models;

namespace Ecommerce.BL.Interfaces
{
    public interface IAccounts
    {

        #region Customer methods
        /// <summary>
        /// Creates new Customer account in Db
        /// </summary>
        /// <param name="account">user Account information</param>
        /// <returns>Return boolean for UI</returns>
        public bool AddAccount(Account account);

        /// <summary>
        /// Updates user Account information
        /// </summary>
        /// <param name="account">Contains updated account information</param>
        /// <returns>Returns a boolean for UI</returns>
        public bool UpdateAccount(Account account);

        public void AddAccountPaymentMethod();
        public void UpdateAccountPaymentMethod();
        /// <summary>
        /// Enables user to login
        /// </summary>
        /// <param name="username">Account username</param>
        /// <param name="password">Account password</param>
        /// <returns></returns>
        public Data.Models.Account LoginCustomer(string username, string password);

        #endregion

        #region Admin Customer Methods

        /// <summary>
        /// Returns all 
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        List<Data.Models.Account> GetAccountList(string fName = "", string lName = "");

        #endregion

    }
}
