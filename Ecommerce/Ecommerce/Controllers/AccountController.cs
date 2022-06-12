using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Data.Models;

namespace Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly p1mvcecommerceSQLDbContext _context;
        private readonly Account _account;
        private readonly IShopping s;
        public AccountController(p1mvcecommerceSQLDbContext context, Account account)
        {
            _context = context;
            _account = account;
        }

        public IActionResult AccountLanding()
        {
            return View();
        }

        public IActionResult CreateAccount(Account acc)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("RegisterNewCustomer");
                ViewBag.messagefail = "There was an issue.";
            }


            // 3. render the start page for creating an order.
            ViewBag.messagesucc = "You have successfully created a new account.";
            return View(_account.saveCustomer(acc));
        }

        //GET: Customer/Login
        [HttpGet]
        public IActionResult LoginCustomer()
        {
            return View();
        }

        public IActionResult ErrLogin()
        {
            return View();
        }

        //POST: Customer/Login
        [HttpPost]
        public IActionResult LoginCustomer(Account acc)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("LoginCustomer");
                ViewBag.message = "There was an issue.";
            }
            string usn = cm.Username;
            string pwd = cm.Password;
            if(c.Login(usn, pwd) == null)
            {
                RedirectToAction("ErrLogin");
            }
            return View();
        }

        //POST: Customer/Login
        public IActionResult LogSucc(P1Models.Customer cm)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("LoginCustomer");
                ViewBag.message = "There was an issue.";
            }
            string usn = cm.Username;
            string pwd = cm.Password;
            if (c.Login(usn, pwd) == null)
            {
                RedirectToAction("ErrLogin");
            }
            return View();
        }

        //GET: Customer/PrintAllCustomers
        public IActionResult PrintAllCustomers()
        {
            List<P1FinalDbContext.Customer> c = _context.Customers.ToList();
            return View(c);
        }


        //use a GET method to dynamically change customerid
        //GET: Customer/PrintCustomerOrder
        public IActionResult OrderHistoryCustomer()//parameter of int customerid
        {
            List<Order> o = _context.Orders.Where(x => x.CustomerId >=0 ).ToList();//throwing exception because no orders exist
            return View(o);
        }

        public IActionResult OrderHistoryStore1()//parameter of int storeid - create the view
        {
            List<Order> o = _context.Orders.Where(x => x.StoreId == 1).ToList();//throwing exception because no orders exist
            return View(o);
        }

        public IActionResult OrderHistoryStore2()//parameter of int storeid - create the view
        {
            List<Order> o = _context.Orders.Where(x => x.StoreId == 2).ToList();//throwing exception because no orders exist
            return View(o);
        }
        public IActionResult OrderHistoryStore3()//parameter of int storeid - create the view
        {
            List<Order> o = _context.Orders.Where(x => x.StoreId == 3).ToList();//throwing exception because no orders exist
            return View(o);
        }
        public IActionResult OrderHistoryStore4()//parameter of int storeid - create the view
        {
            List<Order> o = _context.Orders.Where(x => x.StoreId == 4).ToList();//throwing exception because no orders exist
            return View(o);
        }
    }//eoc
}//eon
