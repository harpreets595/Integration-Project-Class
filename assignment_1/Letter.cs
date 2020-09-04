using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_1
{
    class Letter
    {
        public DateTime _date { get; set; }
        public string _recipient { get; set; }

        public Letter()
        {

        }
        public Letter (DateTime date, string recipient)
        {
            _date = date;
            _recipient = recipient;
        }



    }
}
