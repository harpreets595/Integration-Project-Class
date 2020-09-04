using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_1
{
    class CertifiedLetter : Letter
    {
        public int _TrackingNumber { get; set; }

        public CertifiedLetter()
        {

        }

        public CertifiedLetter(int trackingNumber)
        {
            _TrackingNumber = trackingNumber;
        }   

        public override string ToString()
        {
            return string.Format("date {0}, reciepient {1}, trackingNumber : {2}", _date, _recipient, _TrackingNumber);
        }
    }


}
