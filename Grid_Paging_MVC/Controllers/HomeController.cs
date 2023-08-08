using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grid_Paging_MVC.Models;

namespace Grid_Paging_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(this.GetCustomers(1));
        }

        [HttpPost]
        public ActionResult Index(int currentPageIndex)
        {
            return View(this.GetCustomers(currentPageIndex));
        }

        private CustomerModel GetCustomers(int currentPage)
        {
            int maxRows = 10;
            using (NorthwindEntities1 entities = new NorthwindEntities1())
            {
                CustomerModel customerModel = new CustomerModel();

                customerModel.Customers = (from customer in entities.Customers
                                           select customer)
                            .OrderBy(customer => customer.CustomerID)
                            .Skip((currentPage - 1) * maxRows)
                            .Take(maxRows).ToList();

                double pageCount = (double)((decimal)entities.Customers.Count() / Convert.ToDecimal(maxRows));
                customerModel.PageCount = (int)Math.Ceiling(pageCount);

                customerModel.CurrentPageIndex = currentPage;

                return customerModel;
            }
        }
    }
}