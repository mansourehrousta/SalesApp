using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class HouseInfo
    {
        public String postalCode;
        public String address;
        public String area;
        public String buildYear;
        public String insuranceStartDate;
        public String houseType;
        public String currency;
        public String billingPeriod;
        public PriceInfo price;

        public HouseInfo()
        {
            // price = new PriceInfo();
        }

        public string toString()
        {
            String priceStr = "Price is " + price.price + " " + price.currency + "/charged every" + price.billingPeriod;
            return priceStr;
        }

    }
}
