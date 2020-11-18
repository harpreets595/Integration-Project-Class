using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_integration.Models
{
    public class RecaptchaVerification
    {
        public string Secret { get; set; }
        public string Response { get; set; }
    }
}
