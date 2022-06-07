using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Ecommerce.Data.Models;

namespace Ecommerce.BL
{
   public class StoreOld //: IStore
    {
        private readonly P1TestDbContext _context;//all stores access DBcontext
        public Customer currentcustomer { get; set; }//any given store has a customer shopping at it
		public P1FinalDbContext.Location storechoice;//to store the current store
		public ArrayList arr;

		//constructors
		public StoreOld() { }
        public StoreOld(P1TestDbContext context)//Store takes in context as a parameter
        {
            this._context = context;
        }

		//public Store(P1FinalDbContext.Customer currentcustomer)
  //      {
		//	this.currentcustomer = currentcustomer;
  //      }

		//public Store(P1TestDbContext context, P1FinalDbContext.Customer customer)
		//{
		//	this._context = context;
		//	this.currentcustomer = customer;
		//}


		///<summary>
		///This method will persist changes to the database
		/// </summary>
		/// 
		public bool AddCustomer(P1Models.Customer cm)
        {
			bool b = false;
			_context.Add(cm);
			_context.SaveChanges();
            if(_context.SaveChanges()==0)
			{
				return b;
            }
            else { b = true; }
			return b;
		}


		///<summary>
		///This is the register method
		/// </summary>
		///
		public async Task<bool> RegisterAsync(string fname, string lname, string usn, string pwd, string email)
		{
				P1FinalDbContext.Customer c = new P1FinalDbContext.Customer();

				c.Fname = fname;
				c.Lname = lname;
				c.Username= usn;
				c.Password=pwd;
				c.Email = email;

			await _context.Customers.AddAsync(c);

			if (_context.SaveChanges() == 1)
			{ return true; }
            else { return false; }
		}






		///<summary>
		///This is a method to view all store locations (from the Db)
		///</summary>
		
		public ArrayList ShowStores()
		{
			//retrieve favorite choice value

			var locs = _context.Locations.Where(x => x.StoreId >= 0).ToList();
			foreach (var l in locs)
            {
				StoreModel sm = new StoreModel();
				sm.StoreId = l.StoreId;
				sm.State = l.State;
				sm.City = l.City;
				sm.Address = l.Address;
				sm.Phone = l.Phone;

				arr.Add(sm);
			}
			return arr;
		}

			///<summary>
			///This is a method to output all the inventory for a specific store location, using the inventory data for that location.
			///</summary>
			///<param name="favoritechoice"> This parameter is chosen from a view where the customer selects a favorite store</param>



		///<summary>
		///This method adds an arraylist to viewbag so that it can be called from a view
		/// </summary>


		///<summary>
		/// A method to view all stores from DB 
		/// </summary>
		///<parameter>
		///
		///</parameter>
		///
		//public List<Location> GetLocationsList()
		//{
		//	List<Location> locList = _context.Locations.ToList();
		//	return locList;
		//	//user clicks button corresponding to a location 
		//}


		/// <summary>
		/// This is the method that runs when a users chooses a location to shop at.
		/// </summary>
		/// <returns></returns>
		///         
		//public P1Models.Location GetLocation(int choice)
  //      {
  //          storechoice = _context.Locations.Where(x => x.StoreId == choice).FirstOrDefault();
  //          return storechoice;
  //      }

	//This is the original method that was created but limitation was that the scope prohibited from storing the info into a view
	//I ended up using an arraylist of <Location> type to store the entities representing the stores so that a view could output that object
		//public List<P1Models.Location> StoreView()
		//{
		//	var choices = _context.Locations.Where(x => x.StoreId >= 0).ToList();
		//	return choices;
		//}
		/*using (var context = new P1TestDbContext())
		{

			List<P1FinalDbContext.Location> storelist = context.Locations.Where(x => x.StoreId >= 0).ToList();

			//forreach loop to print out the values (if you just write consolewriteline you get memory address)
			foreach (var store in storelist)
			{
				Console.WriteLine($"{store.StoreId}. {store.City}, {store.State}");
			}

		}
		*/




	///<summary>
	///This is a method to create an order 
	/// </summary>
	///



	///<summary>
	///This is a method to display order details
	/// </summary>
	/// 

	///<summary>
	///This method shows the inventory for a specific store
	/// </summary>
	/// 

	///<summary>
	///This method decrements the inventory for a specific store based off the order
	/// </summary>
	/// 


		///<summary>
		///contains special deals logic
		/// </summary>
		/// 
		public void SpecialDeals()//requires a parameter of a a cart/order
        {
			string[] dealsDays = { "1/1/2021", "2/14/2021", "06/30/2021", "6/30/2021", "7/4/2021", "12/24/2021" };
			DateTime thisday = DateTime.Today;
			var today= thisday.ToString("d");


			if(dealsDays.Contains(today))
            {
				//reduces prices by 15% to the cart order
            }
			else
            {
				//complete checkout function
            }
        }

        public Task<bool> NewCustomerAsync(CustomerModel p)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerModel>> PlayerListAsync()
        {
            throw new NotImplementedException();
        }

        public List<P1FinalDbContext.Location> GetLocationsList()
        {
            throw new NotImplementedException();
        }
    }//eoc
}//eon
