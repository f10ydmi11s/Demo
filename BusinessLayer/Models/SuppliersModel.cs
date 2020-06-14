using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Suppliers : SuppliersBusinessModelLayers
    {

        public class SuppliersMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.SuppliersSingle Suppliers { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwsuppliers VwSuppliers { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Products Products { get; set; }
            public IEnumerable<BusinessModelLayer.ProductsSingle> ProductsDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vwproducts> ProductsVwDetl { get; set; }

        }
    }
}
