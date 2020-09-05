using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_1
{
    class SpecialCookieOrder : CookieOrder
    {
        private readonly string _description;
        public const int HANDLING_FEE = 5;
        public SpecialCookieOrder(
            string description,
            string customerName,
            int orderNumber,
            int quantity, 
            string typeOfCookie) : base (customerName, orderNumber, quantity, typeOfCookie) 
        {
            _description = description;
        }

        public override void CalculatePrice()
        {
            // VALIDATION FOR QUANTITY
            if (_quantity < 0)
            {
                Console.WriteLine("Error: This quantity is less than 0");
                return;
            }
            if (_quantity < TWO_DOZEN)
            {
                _totalPrice = (PRICE_LESS_THAN_24_COOKIES * _quantity) + HANDLING_FEE;
                Console.WriteLine("This is Special Order with {0}: ",_description);
                Console.WriteLine("Total Price for less than two dozen: {0}", _totalPrice);

            }
            else
            {
                _totalPrice = (PRICE_MORE_THAN_24_COOKIES * _quantity) + HANDLING_FEE;
                Console.WriteLine("This is Special Order with {0}: ", _description);
                Console.WriteLine("Total Price for more than two dozen: {0}", _totalPrice);
            }
            
        }


    }
}
