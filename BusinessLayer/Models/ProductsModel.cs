using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Products : ProductsBusinessModelLayers
    {

        public class ProductsMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.ProductsSingle Products { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwproducts VwProducts { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Order_Details Order_Details { get; set; }
            public IEnumerable<BusinessModelLayer.Order_DetailsSingle> Order_DetailsDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vworder_details> Order_DetailsVwDetl { get; set; }

        }
    }
}
