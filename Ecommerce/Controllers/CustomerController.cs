using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1Final.Controllers
{
    public class CustomerController : Controller
    {
        private readonly P1TestDbContext _context;
        private readonly ICustomer c;
        private readonly IStore s;
        public CustomerController(P1TestDbContext context, ICustomer c, IStore s)
        {
            _context = context;
            this.c = c;
        }


        //POST: CustomerController/RegisterNewCustomer
        public IActionResult RegisterNewCustomer(P1Models.Customer cm)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("RegisterNewCustomer");
                ViewBag.messagefail = "There was an issue.";
            }

            //s.RegisterCustomerAsync();

            // mapp the values unputted by thre user to teh custoemr model from EF/


            //1. create a method in your business layer that will do the below action
            //check


            // 2. get some type of confirmation back.. like T/F
            //check

            // 3. render the start page for creating an order.
            ViewBag.messagesucc = "You have successfully created a new account.";
            return View(c.saveCustomer(cm));
        }
        //GET: Customer/Login
        [HttpGet]
        public IActionResult LoginCustomer()//make sure controller input == business layer input
        {
            return View();
        }

        public IActionResult ErrLogin()//make sure controller input == business layer input
        {
            return View();
        }

        //POST: Customer/Login
        [HttpPost]
        public IActionResult LoginCustomer(P1Models.Customer cm)//make sure controller input == business layer input
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
        public IActionResult LogSucc(P1Models.Customer cm)//make sure controller input == business layer input
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
