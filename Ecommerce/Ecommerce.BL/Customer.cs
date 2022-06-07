using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;

namespace Ecommerce.BL
{
    public class Customer //: ICustomer
    {
        //private readonly p1mvcecommerceSQLDbContext _context;//similar to Store class
        //public Customer(p1mvcecommerceSQLDbContext context)
        //{
        //    this._context = context;
        //}

        ////all customers have a list property to use for the GetAllCustomerList
        ////List<P1TestDbContext.Customer> list;

        /////<summary>
        /////This is a method to register any new customers using CustomerModel data from the view and persist to the Db
        /////</summary>
        /////<parameter>
        /////</parameter>
        /////


        //// register new customer 

        ///*public async Task<bool> RegisterCustomerAsync(P1FinalDbContext.Customer cm)
        //{
        //    // create a try/catch  to save user
        //    await _context.Customers.AddAsync(cm);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //        //await _context.SaveChangesAsync();

        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
        //        return false;
        //    }
        //    catch (DbUpdateException ex)
        //    {       //change this to logging
        //        Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
        //        return false;
        //    }
        //    // currentUser
        //    currentUser = user;
        //    // instantiate a shopping cart iimediately for the new customer 
        //    var newCart = new Cart(user.UserId);
        //    _context.Carts.Add(newCart);
        //    _context.SaveChanges();
        //    return true;
        //}
        //*/


        /////<<summary>
        /////This is a method to login a new user
        /////</summary>
        ////public async Task<bool> LoginAsync(CustomerModel customer)
        ////{
        ////    // create a try/catch  to save user
        ////    try 
        ////    { 
        ////        var current = _context.Customers.ToList().Where(x => x.Email == customer).FirstOrDefault(); 
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Console.WriteLine($"User not found => {ex.InnerException}");
        ////        return false;
        ////    }
        ////    return true;
        ////}
       

        //public List<p1mvcecommerceSQLDbContext.Customer> PrintAllCustomers()
        //{
        //    List<p1mvcecommerceSQLDbContext.Customer> c = _context.Customers.ToList();
        //    return (c);
        //}

        ////use a GET method to dynamically change customerid
        //public List<P1FinalDbContext.Order> PrintCustomerOrder(int customerid)
        //{
        //    List<Order> o = _context.Orders.Where(x => x.CustomerId == customerid).ToList();
        //    return (o);
        //}

       

        /// <summary>
        /// This is an interface that implements a View of StoreList & allows users to view all stores
        /// </summary>
        /// <returns>Returns a view of all stores</returns>

        /* public ArrayList AllCustomerList()
         {

             ArrayList customerlist = new ArrayList();
             var customers = _context.Customers.Where(x => x.CustomerId >= 0).ToList();
             foreach(var c in customers)
             {
                 CustomerModel cm = new CustomerModel();
                 cm.CustomerId = c.CustomerId;
                 cm.Fname = c.Fname;
                 cm.Lname = c.Lname;
                 cm.Username = c.Username;
                 cm.Password = c.Password;
                 cm.Email = c.Email;
             }

             try
             {
                 list = _context.Customers.ToList();
             }
             catch (ArgumentNullException ex)
             {
                 Console.WriteLine($"There was a problem gettign the players list => {ex.InnerException}");
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"There was a problem gettign the players list => {ex}");
             }
             return list;
         }

         */









        ////blic static void SortCustomersFirst()
        ////
        ////  
        ////
        ////  using (context)
        ////  {
        ////      //create an ordered list of context type Customer via lambda
        ////      List<context.Customer> namedList = context.Customers.OrderBy(b => b.Fname).ToList();
        ////      Console.WriteLine("All customers and basic information, ordered by first name.");
        ////      foreach (var cust in namedList)//output basic information
        ////      {
        ////          Console.WriteLine($"Name: {cust.Fname} {cust.Lname}  ID: {cust.CustomerId}   -  Email: {cust.Email}  - " +
        ////              $"Address: {cust.Mailing} {cust.State},{cust.State} {cust.Zip}");
        ////      }
        ////  }
        ////
        ////
        ////blic static void SortCustomersMemberStatus()
        ////
        ////  context.P0DbContext context = new context.P0DbContext();
        ////  using (context)
        ////  {
        ////      //create an ordered list of context type Customer via lambda
        ////      List<context.Customer> memberList = context.Customers.OrderBy(b => b.Member).ToList();
        ////      Console.WriteLine("All customers and basic information, with non-members first.");
        ////      foreach (var cust in memberList)//output basic information
        ////      {
        ////          Console.WriteLine($"Name: {cust.Fname} {cust.Lname}  - Member:{cust.Member}   Email: {cust.Email}  - " +
        ////              $"Address: {cust.Mailing} {cust.State},{cust.State} {cust.Zip}");
        ////      }
        ////  }
        ////
        ////method to show all order history of a customer
        ///public static void CustomerOrderHistory(int customerId)
        ///{
        ////  context.P0DbContext context = new context.P0DbContext();
        ////  using (context)
        ////  {
        ////      //select star
        ////      List<context.Order> history = context.Orders.OrderBy(b => b.CustomerId == customerId).ToList();
        ////      Console.WriteLine("Order History for a customer");
        ////      int count = 0;
        ////      foreach (var order in history.Where(c => c.CustomerId == customerId))
        ////      {
        ////          Console.WriteLine($"The order history for {order.CustomerId}: {count++}. {order.QuanOrder} " +
        ////              $"{order.Product} ordered on {order.DateOrder}");
        ////      }
        ////  }
        ///}
        ///blic static void AllOrderHistory(int customerId)
        ///
        ///  context.P0DbContext context = new context.P0DbContext();
        ///  using (context)
        ///  {
        ///      //select star
        ///      List<context.Order> history = context.Orders.OrderBy(b => b.CustomerId == customerId).ToList();
        ///      Console.WriteLine("Order History for all customers");
        ///      int count = 0;
        ///      foreach (var order in history)
        ///      {
        ///          Console.WriteLine($"The order history for {order.CustomerId}: {count++}. {order.QuanOrder} " +
        ///              $"{order.Product} ordered on {order.DateOrder}");
        ///      }
        ///  }
        ///
        //

        /*
        Task<bool> RegisterUserAsync(User user);
        Task<bool> LoginAsync(User user);
        Task<List<User>> UserListAsync();
        */




    }//eoc
}//eon
