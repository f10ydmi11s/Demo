using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Customers : CustomersBusinessModelLayers
    {

        public class CustomersMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.CustomersSingle Customers { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwcustomers VwCustomers { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Orders Orders { get; set; }
            public IEnumerable<BusinessModelLayer.OrdersSingle> OrdersDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vworders> OrdersVwDetl { get; set; }

        }
    }
}
