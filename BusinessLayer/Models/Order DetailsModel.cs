using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Order_Details : Order_DetailsBusinessModelLayers
    {

        public class Order_DetailsMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.Order_DetailsSingle Order_Details { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vworder_details VwOrder_Details { get; set; }
            // DETAILS TABLES

        }
    }
}
