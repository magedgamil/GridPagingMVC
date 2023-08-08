using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grid_Paging_MVC.Models
{
    public class CustomerModel
    {
        /// <summary>
        /// Gets or sets Customers.
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets CurrentPageIndex.
        /// </summary>
        public int CurrentPageIndex { get; set; }

        /// <summary>
        /// Gets or sets PageCount.
        /// </summary>
        public int PageCount { get; set; }
    }
}