using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Categories : CategoriesBusinessModelLayers
    {

        public class CategoriesMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.CategoriesSingle Categories { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwcategories VwCategories { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Products Products { get; set; }
            public IEnumerable<BusinessModelLayer.ProductsSingle> ProductsDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vwproducts> ProductsVwDetl { get; set; }

        }
    }
}
