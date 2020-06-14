using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Customercustomerdemo : CustomercustomerdemoBusinessModelLayers
    {

        public class CustomercustomerdemoMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.CustomercustomerdemoSingle Customercustomerdemo { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwcustomercustomerdemo VwCustomercustomerdemo { get; set; }
            // DETAILS TABLES

        }
    }
}
