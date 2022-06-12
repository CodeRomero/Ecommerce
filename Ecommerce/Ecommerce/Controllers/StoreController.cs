using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.c
{
    public class StoreController : Controller
    {
        private readonly P1TestDbContext _context;
        private readonly IStore s;

        public StoreController(IStore store, P1TestDbContext context)
        {
            this.s = store;
            this._context = context;
        }

        // GET: StoreController
        public ActionResult Index()
        {
            return View();
        }

        //GET: StoreController/LoginStore
        public IActionResult Register2()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }




        //GET: StoreController/Login
        public ActionResult Login()
        {
            return View();
        }
        //POST: StoreController/Login
        public ActionResult Login(string usn, string pwd)
        {
            //if c is in the customers table, then return login succ view
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View("StoreList");
        }

        //GET: StoreController/StoreList()
        public IActionResult StoreList()
        {
            P1TestDbContext _context = new P1TestDbContext();
            List<P1FinalDbContext.Location> locs = _context.Locations.ToList<P1FinalDbContext.Location>();
            return View(locs);
        }


        [Route("StoreInven/1")]
        public IActionResult StoreInven1(List<StoreInvenModel> list,int locnum =1)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View(s.ListStoreInven(locnum));
        }

        [Route("StoreInven/2")]
        public IActionResult StoreInven2(List<StoreInvenModel> list,int locnum = 2)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View(s.ListStoreInven(locnum));
        }

        [Route("StoreInven/3")]
        public IActionResult StoreInven3(List<StoreInvenModel> list,int locnum = 3)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View(s.ListStoreInven(locnum));
        }

        [Route("StoreInven/4")]
        public IActionResult StoreInven4(List<StoreInvenModel> list,int locnum = 4)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View(s.ListStoreInven(locnum));
        }

        [Route("StoreInven/5")]
        public IActionResult StoreInven5(List<StoreInvenModel> list,int locnum = 5)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View(s.ListStoreInven(locnum));
        }

        [Route("StoreInven/6")]
        public IActionResult StoreInven6(List<StoreInvenModel> list,int locnum = 6)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View(s.ListStoreInven(locnum));
        }

        //GET: StoreController/StoreOrderHistory
        //public IActionResult StoreOrderHistory()
        //{
        //    List<P1DbFinalContext.Order> o = _context.Orders.Where(x => x.StoreId >= 0).ToList();//throwing exception because no orders exist
        //    return View(o);
        //}

            //POST: StoreController/Shop
            public IActionResult Shop(List<StoreInvenModel> list)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }

            /*s.ListStoreInven();
            I was going insane for an hr wondering why the View wasn't showing the output of the method...
            Because I had to put it in the view for it to read the output...
            */
            //HttpContext.Session.SetInt32("storechoice",JsonConvert.1);
            return View(s.ListStoreInven());
            
        }

        [HttpPost]
        public IActionResult AddToCart1(IEnumerable<StoreInvenModel> sim, int locnum)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View(s.ListStoreInven(locnum));
            //add to cart logic

            //EACH ACTION METHOD MUST TAKE IN & RETURN A VIEW OF DATATYPE THAT IS BEING UNSERIALIZED

            //take data from StoreInvenX and store into serial object
            //in addtocart unserialize object & map to cart/productinven type
            //serialize that new object and send into checkout
            //checkout will unserialize cart object and convert into FinalOrder. Final order has total price property
            //saveOrder function will take final order object and map to a DB Order, then add to context & save

            //view for cart info will require cart data type
        }
        [HttpPost]
        public IActionResult AddToCart2(IEnumerable<StoreInvenModel> sim, int locnum)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("ErrLogin");
            }
            return View(s.ListStoreInven(locnum));
            //add to cart logic

            //EACH ACTION METHOD MUST TAKE IN & RETURN A VIEW OF DATATYPE THAT IS BEING UNSERIALIZED

            //take data from StoreInvenX and store into serial object
            //in addtocart unserialize object & map to cart/productinven type
            //serialize that new object and send into checkout
            //checkout will unserialize cart object and convert into FinalOrder. Final order has total price property
            //saveOrder function will take final order object and map to a DB Order, then add to context & save

            //view for cart info will require cart data type
        }
        [Route("CreateCart/1/MMore")]
        public IActionResult CreateCart(int locnum = 1, string usn = "MMore")
        {
            Cart cart = s.CreateCart(locnum, usn);
            HttpContext.Session.SetString("cartsession", JsonConvert.SerializeObject(cart));
            return View(s.CreateCart(locnum,usn));
        }
        [Route("CreateCart/2/MMore")]
        public IActionResult CreateCart2(int locnum = 1, string usn = "MMore")
        {
            Cart cart = s.CreateCart(locnum, usn);
            HttpContext.Session.SetString("cartsession", JsonConvert.SerializeObject(cart));
            return View(s.CreateCart(locnum, usn));
        }
        [Route("CreateCart/3/MMore")]
        public IActionResult CreateCart3(int locnum = 1, string usn = "MMore")
        {
            Cart cart = s.CreateCart(locnum, usn);
            HttpContext.Session.SetString("cartsession", JsonConvert.SerializeObject(cart));
            return View(s.CreateCart(locnum, usn));
        }
        [Route("CreateCart/4/MMore")]
        public IActionResult CreateCart4(int locnum = 1, string usn = "MMore")
        {
            Cart cart = s.CreateCart(locnum, usn);
            HttpContext.Session.SetString("cartsession", JsonConvert.SerializeObject(cart));
            return View(s.CreateCart(locnum, usn));
        }
        [Route("CreateCart/5/MMore")]
        public IActionResult CreateCart5(int locnum = 1, string usn = "MMore")
        {
            Cart cart = s.CreateCart(locnum, usn);
            HttpContext.Session.SetString("cartsession", JsonConvert.SerializeObject(cart));
            return View(s.CreateCart(locnum, usn));
        }

        [Route("CreateCart/6/MMore")]
        public IActionResult CreateCart6(int locnum = 1, string usn = "MMore")
        {
            Cart cart = s.CreateCart(locnum, usn);
            HttpContext.Session.SetString("cartsession", JsonConvert.SerializeObject(cart));
            return View(s.CreateCart(locnum, usn));
        }
        [HttpGet]
        public IActionResult AddCart()
        {
            Cart ct = new Cart();
            
            Cart cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
            //add i to cart list
            //s.UpdateCart();
            HttpContext.Session.SetString("addsession", JsonConvert.SerializeObject(cart));
            return View();
        }

        [HttpPost]
        public IActionResult AddCart(Item i)
        {

            Cart cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
            //add i to cart list
            //Item var = i;
            //cart.Items.Add(var);
            HttpContext.Session.SetString("addsession", JsonConvert.SerializeObject(cart));
            return View(i);
        }

        [HttpPost]
        public IActionResult AddCart2(Item i)
        {

            Cart cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
            //add i to cart list
            //Item var = i;
            //cart.Items.Add(var);
            HttpContext.Session.SetString("addsession", JsonConvert.SerializeObject(cart));
            return View(i);
        }

        [HttpPost]
        public IActionResult AddCart3(Item i)
        {

            Cart cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
            //add i to cart list
            //Item var = i;
            //cart.Items.Add(var);
            HttpContext.Session.SetString("addsession", JsonConvert.SerializeObject(cart));
            return View(i);
        }


        [HttpPost]
        public IActionResult AddCart4(Item i)
        {

            Cart cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
            //add i to cart list
            //Item var = i;
            //cart.Items.Add(var);
            HttpContext.Session.SetString("addsession", JsonConvert.SerializeObject(cart));
            return View(i);
        }

        [HttpPost]
        public IActionResult AddCart5(Item i)
        {

            Cart cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
            //add i to cart list
            //Item var = i;
            //cart.Items.Add(var);
            HttpContext.Session.SetString("addsession", JsonConvert.SerializeObject(cart));
            return View(i);
        }

        [HttpPost]
        public IActionResult AddCart6(Item i)
        {

            Cart cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
            //add i to cart list
            //Item var = i;
            //cart.Items.Add(var);
            HttpContext.Session.SetString("addsession", JsonConvert.SerializeObject(cart));
            return View(i);
        }


        public IActionResult ViewOrder(Cart cart)
        {
            try
            {
                Cart ct = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
                ct.Items = cart.Items;
                return View(ct);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"An ArgumentNullException was thrown: '{e}'");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Exception was thrown: '{ex}'");
 
            }
            return View("Login");
        }

        public IActionResult StartShopping(int locnum)
        {
            s.ListStoreInven(locnum);
            return View();
        }

        public IActionResult Checkout(Cart cart)//takes in an object type of cart
        {
            Cart ct = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cartsession"));
            ct.Items = cart.Items;
            return View(ct);
        }




















        public IActionResult PrintAllStores()
        {
            //List<Location> l = _context.Locations.ToList();
            return View();
        }

        public IActionResult PrintAllStoresModel()
        {
            //List<Location> l = _context.Locations.ToList();
            return View();
        }

        // GET: StoreController/StoreList/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreInven(int location)
        {
            //List<P1FinalDbContext.Location> l = _context.Locations.ToList();
            return View();
        }

        //GET: StoreController/ViewCart
        public ActionResult test()
        {
            //List<P1FinalDbContext.Location> l = _context.Locations.ToList();
            return View();
        }

        /// <summary>
        /// This is an interface that implements a View of StoreList & allows users to view all stores
        /// </summary>
        /// <returns>Returns a view of all stores</returns>
        public IActionResult Details()
        {
            return View();
        }


        /// <summary>
        /// This is an action method to buy items and add to a cart.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /*public ActionResult Buy(string id)
        {
            ProductModel productModel = new ProductModel();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }
        */
    }
}
