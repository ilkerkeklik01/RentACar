﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDTO:IDTO
    {

        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }


        public override string ToString()
        {
            return CarName+" "+BrandName+" "+ColorName+" "+ DailyPrice;
        }
    }
    
}
