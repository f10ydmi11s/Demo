using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Shippers : ShippersBusinessModelLayers
    {

        public class ShippersMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.ShippersSingle Shippers { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwshippers VwShippers { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Orders Orders { get; set; }
            public IEnumerable<BusinessModelLayer.OrdersSingle> OrdersDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vworders> OrdersVwDetl { get; set; }

        }
    }
}
