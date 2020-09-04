using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_1
{
    class SpecialCookieOrder : CookieOrder
    {
        private readonly string _cookieSpecialty;

        public SpecialCookieOrder(string cookieSpeciality)
        {
            _cookieSpecialty = cookieSpeciality;
        }

        public decimal overide CalculatePrice(SpecialCookieOrder cookie)
        {

            if (cookie._quantity < 24)
            {
                cookie._totalPrice = (decimal)(2.25 * cookie._quantity);
            }
            else
            {
                cookie._totalPrice = (decimal)(1.50 * cookie._quantity);
            }
            return cookie._totalPrice + 5;
        }

    }
}
