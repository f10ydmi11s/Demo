using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Customerdemographics : CustomerdemographicsBusinessModelLayers
    {

        public class CustomerdemographicsMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.CustomerdemographicsSingle Customerdemographics { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwcustomerdemographics VwCustomerdemographics { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Customercustomerdemo Customercustomerdemo { get; set; }
            public IEnumerable<BusinessModelLayer.CustomercustomerdemoSingle> CustomercustomerdemoDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vwcustomercustomerdemo> CustomercustomerdemoVwDetl { get; set; }

        }
    }
}
