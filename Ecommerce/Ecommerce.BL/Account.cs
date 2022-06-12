using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Data.Models;
using Ecommerce.BL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce.BL
{
    public class Accounts : IAccounts
    {
        #region Fields

        private readonly p1mvcecommerceSQLDbContext dBContext;
        private ILogger logger;
        public Customer currentcustomer;

        #endregion

        #region Constructor
        public Accounts(Customer customer, p1mvcecommerceSQLDbContext context, ILogger log)
        {
            currentcustomer = customer;
            dBContext = context;
            logger = log;
        }
        #endregion

        #region Customer Methods
        /// <summary>
        /// Creates new Customer account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool AddAccount(Account account)
        {
            try
            {
                var context = dBContext;

                var currentAccounts = context.Accounts.Where(a => a.AccountId == account.AccountId && a.Email == account.Email || a.AccountId == account.AccountId).ToList();
                
                //validate 
                if (currentAccounts.Any() == false )
                {
                    dBContext.Add(account);
                    dBContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateException ex)
            {
                this.logger.LogError($"DbUpdateException caught at {DateTime.Now}", ex);
                return false;
            }
        }

        /// <summary>
        /// Updates user Account information
        /// </summary>
        /// <param name="account">Contains updated account information</param>
        /// <returns>Returns a boolean for UI</returns>
        public bool UpdateAccount(Account account)
        {
            try
            {
                var context = this.dBContext;

                var acc = context.Accounts.Where(a => a.AccountId == account.AccountId).ToList().FirstOrDefault();
                var updatedAcc = new Account(
                {
                    AccountId = account.AccountId,
                    Email = account.Email,
                    Fname = account.Fname,
                    Lname = account.Lname,
                    Usrname = account.Usrname,
                    Pwd = account.Pwd,
                    Membership = account.Membership,
                    Balance = account.Balance,
                    Carts = account.Carts,
                    Orders = account.Orders,
                    Sessions = account.Sessions,
                });

            }
            catch (DbUpdateException ex)
            {
                this.logger.LogError($"DbUpdateException caught at {DateTime.Now}", ex);
                return false;
            }
        }

        public void AddAccountPaymentMethod()
        {

        }
        public void UpdateAccountPaymentMethod()
        {

        }

        /// <summary>
        /// Enables user to login
        /// </summary>
        /// <param name="username">Account username</param>
        /// <param name="password">Account password</param>
        /// <returns></returns>
        public Data.Models.Account LoginCustomer(string username, string password)
        {

        }

        #endregion

        #region Admin Customer Methods

        /// <summary>
        /// Returns all 
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        List<Data.Models.Account> GetAccountList(string fName = "", string lName = "");



        public P1Models.Customer saveCustomer(P1Models.Customer cm)
        {
            //map cm to dbcustomer
            P1FinalDbContext.Customer dbcustomer = new P1FinalDbContext.Customer();
            {
                dbcustomer.Fname = cm.Fname;
                dbcustomer.Lname = cm.Lname;
                dbcustomer.Username = cm.Username;
                dbcustomer.Password = cm.Password;
                dbcustomer.Email = cm.Email;
            };
            _context.Add(dbcustomer);
            _context.SaveChanges();
            return cm;
        }

        /// <summary>
        /// This is the login method that maps context type to model type to be output into a view
        /// </summary>
        /// <param name="usn">user's username</param>
        /// <param name="pwd">user's paswword</param>
        /// <returns></returns>
        public P1Models.Customer Login(string usn, string pwd)
        {
            P1FinalDbContext.Customer dbcustomer;
            dbcustomer = _context.Customers.Where(x => x.Username == usn && x.Password == pwd).FirstOrDefault();
            //let's map
            if (dbcustomer == null)
            {
                currentcustomer = null;
                return currentcustomer;
            }
            else
            {
                P1Models.Customer q = new P1Models.Customer()
                {
                    Fname = dbcustomer.Fname,
                    Lname = dbcustomer.Lname,
                    Username = dbcustomer.Username,
                    Email = dbcustomer.Email,
                    Password = dbcustomer.Password,
                };
                currentcustomer = q;
            }
            return currentcustomer;
        }

        /// <summary>
        /// Returns List of Customers matching parameters or list of all customers on empty parameters
        /// </summary>
        /// <param name="fName">First name contains</param>
        /// <param name="lName">Last name contains</param>
        /// <returns>List of Customer Objects that contain input requirements</returns>
        public List<P1FinalDbContext.Customer> GetCustomerList(string fName = "", string lName = "")
        {
            var customerList = _context.Customers.Where(x => x.Fname.Contains(fName) && x.Lname.Contains(lName)).ToList();

            return customerList;
        }

        #endregion
    }
}
