using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_1
{
    class CookieOrder
    {
        public string _customerName { get; set; }
        public int _orderNumber { get; set; }
        public int _quantity { get; set; }
        public string _typeOfCookie { get; set; }
        public decimal _totalPrice { get; set; }

        public CookieOrder(string customerName, int orderNumber, int quantity, string typeOfCookie)
        {
            _customerName = customerName;
            _orderNumber = orderNumber;
            _quantity = quantity;
            _typeOfCookie = typeOfCookie;
            
        }

        public decimal CalculatePrice(CookieOrder cookie)
        {
            
            if (cookie._quantity < 24)
            {
                cookie._totalPrice = (decimal)(2.25 * cookie._quantity);
            }
            else
            {
                cookie._totalPrice = (decimal)(1.50 * cookie._quantity);
            }
            return cookie._totalPrice;
        }
    }
}
