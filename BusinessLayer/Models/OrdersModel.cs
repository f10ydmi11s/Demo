using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Orders : OrdersBusinessModelLayers
    {

        public class OrdersMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.OrdersSingle Orders { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vworders VwOrders { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Order_Details Order_Details { get; set; }
            public IEnumerable<BusinessModelLayer.Order_DetailsSingle> Order_DetailsDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vworder_details> Order_DetailsVwDetl { get; set; }

        }
    }
}
