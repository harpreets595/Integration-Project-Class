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

        public const int TWO_DOZEN = 24;
        public const decimal PRICE_LESS_THAN_24_COOKIES = 2.25m;
        public const decimal PRICE_MORE_THAN_24_COOKIES = 1.50m;



        public CookieOrder(string customerName, int orderNumber, int quantity, string typeOfCookie)
        {
            _customerName = customerName;
            _orderNumber = orderNumber;
            _quantity = quantity;
            _typeOfCookie = typeOfCookie;
            
        }

        public virtual void CalculatePrice()
        {        
            if (_quantity < TWO_DOZEN)
            {
                _totalPrice = (PRICE_LESS_THAN_24_COOKIES * _quantity);
                Console.WriteLine("Total Price for less than two dozen: {0}", _totalPrice);
            }
            else
            {
                _totalPrice = (PRICE_MORE_THAN_24_COOKIES * _quantity);
                Console.WriteLine("Total Price for more than two dozen: {0}", _totalPrice);
            }
        }
    }
}
