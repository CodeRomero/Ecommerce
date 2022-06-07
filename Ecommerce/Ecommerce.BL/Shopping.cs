using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.BL.Interfaces;

namespace Ecommerce.BL
{
    public class Shopping : IShopping
    {
        private readonly P1TestDbContext _context = new P1TestDbContext();//all stores access DBcontext
        public Customer currentcustomer { get; set; }//any given store has a customer shopping at it
        public P1FinalDbContext.Location storechoice;//to store the current store
        public int locnum;
        public List<StoreInvenModel> prodinv;
        public List<P1FinalDbContext.Order> storeorders;
        public Cart storecart;

        /// <summary>
        /// This is a method that saves a Customer type to the DB
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public bool saveCustomer(P1Models.Customer cm)
        {
            bool b = false;

            P1FinalDbContext.Customer c = new P1FinalDbContext.Customer()
            {
                //CustomerId = cm.CustomerId,
                Fname = cm.Fname,
                Lname = cm.Lname,
                Username = cm.Username,
                Password = cm.Password,
                Email = cm.Email,

                //finish mapping
            };
            _context.Add(c);
            _context.SaveChanges();
            if (_context.SaveChanges() == 0)
            {
                return b;
            }
            else { b = true; }
            return b;
        }

        public P1FinalDbContext.Location GetLocation(int storeId)
        {
            storechoice = _context.Locations.Where(x => x.StoreId == storeId).FirstOrDefault();
            return storechoice;
        }

        public int GetLocationNumber(int storeId)
        {
            locnum = storeId;
            return locnum;
        }

        public List<P1FinalDbContext.Order> AllLocationOrders(int storeId)
        {
            storeorders =_context.Orders.Where(x => x.StoreId == storeId).ToList();
            return storeorders;
        }
        /// <summary>
        /// This is the default no args
        /// </summary>
        /// <param name="locnum"></param>
        /// <returns></returns>
        public List<StoreInvenModel> ListStoreInven()
        {
            List<StoreInvenModel> list = new List<StoreInvenModel>();
            //use join query to join on the storeId (column shared between Products & Store)
            var join = _context.Inventories.Join(_context.Products,
                inv => inv.ProductId,//this determines on what column we are joining the tables
                prod => prod.ProductId,
                (inv, prod) => new StoreInvenModel(//this is the custom type to pass into view 
                    prod.ProductId,
                    prod.Make,
                    prod.Text,
                    prod.Price,
                    inv.StoreId,
                    inv.QuanStore)
            ).AsEnumerable();

            list = join.ToList();//we will just use storeid == 1 to test it out

            return prodinv = list;
        }
        /// <summary>
        /// This lists the entire inventory for a store based on the storeid.
        /// </summary>
        /// <param name="storeid"></param>
        /// <returns>Returns a list of a custom model type StoreInvenModel that is passed into the Shop action method.</returns>
        public List<StoreInvenModel> ListStoreInven(int locnum)
        {
              List<StoreInvenModel> list = new List<StoreInvenModel>();
        //use join query to join on the storeId (column shared between Products & Store)
            var join = _context.Inventories.Join(_context.Products,
                inv => inv.ProductId,//this determines on what column we are joining the tables
                prod => prod.ProductId,
                (inv, prod) => new StoreInvenModel(//this is the custom type to pass into view 
                    prod.ProductId,
                    prod.Make,
                    prod.Text,
                    prod.Price,
                    inv.StoreId,
                    inv.QuanStore)
            ).AsEnumerable();

            list = join.Where( x => x.StoreId==locnum).ToList();//we will just use storeid == 1 to test it out

            return prodinv = list;
        }

            //using (_context) DOESN'T WORK HOW I WANT
            //{
            //    var joined =
            //        from p in _context.Products
            //        join i in _context.Inventories on p.ProductId equals i.ProductId
            //        select new
            //        {
            //            ProductId = p.ProductId,
            //            Make = p.Make,
            //            Text = p.Text,
            //            Price = p.Price,
            //            StoreId = i.StoreId,
            //            QuanStore = i.QuanStore,
            //        };

            //}
        
        //    //var prodList = context.Products.ToList();


        //    var joinResults = context.Inventories.Join(
        //        context.Products,
        //        invent => invent.ProductId,
        //        prod => prod.ProductId,
        //        (invent, prod) => new InventoryProduct(
        //            prod.ProductId,
        //            prod.ProductName,
        //            prod.Price,
        //            prod.Description,
        //            prod.Category,
        //            invent.LocationId,
        //            invent.NumberProducts)
        //    ).AsEnumerable();

        //    List<InventoryProduct> productList = joinResults.Where(x => x.LocationId == locationId).ToList();

        //    return productList;
        //}

        /// <summary>
        /// Creates new order cart
        /// </summary>
        /// <param name="cusn"></param>
        /// <param name="storechoice"></param>
        /// <returns></returns>
        public Cart CreateCart(int locnum, string usn)
        {
            //adds new order to DB
            P1FinalDbContext.Customer dbcustomer = new P1FinalDbContext.Customer();
            P1FinalDbContext.Location dbloc = new P1FinalDbContext.Location();
            P1FinalDbContext.Order newor= new P1FinalDbContext.Order();

            dbcustomer = _context.Customers.Where(x => x.Username == usn).FirstOrDefault();
            dbloc = _context.Locations.Where(x => x.StoreId == locnum).FirstOrDefault();
            newor.CustomerId = dbcustomer.CustomerId;
            newor.StoreId = dbloc.StoreId;
            newor.DateOrder = DateTime.Now;

            //_context.Orders.Add(newor);
            //_context.SaveChanges();

            //creates the cart
            Cart cart = new Cart();
            storecart=cart;
            storecart.DateOrder = newor.DateOrder;
            storecart.CustomerId = dbcustomer.CustomerId;
            //2nd part
            return storecart;
        }

        //public Cart AddCart(Item i)
        //{
        //    Cart cart;

        //    return cart;
        //}

       //public Cart AddToCart(Item i)
       //{

       //    if (QuanBuy == 0) return cart;

       //    if (cart.ContainsKey(productId))
       //    {
       //        cart[productId] += QuanBuy;
       //    }
       //    else
       //    {
       //        cart.Add(productId, QuanBuy);
       //    }


       //    return cart;

       //}

        public P1FinalDbContext.Order AddOrder()
        {
            //map cm to dbcustomer
            P1FinalDbContext.Order order = new P1FinalDbContext.Order();
            {
                order.ProductId = 1000;
                order.StoreId = 1;
                order.DateOrder = DateTime.Now;
                order.CustomerId = 2;
                order.QuanOrder = 5;
            };
            _context.Add(order);
            _context.SaveChanges();
            return order;
        }


    }
}
