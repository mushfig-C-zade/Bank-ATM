using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankATM.Models
{
    public class Card
    {
        public string Pan { get; set; }
        public string Pin { get; set; }
        public string Cvc { get; set; }
        public DateTimeOffset ExpireDate { get; init; } 
        public decimal Balans { get; set; } 

        public override string ToString()
        {
            return $"{Pan} {Pin} {Cvc} {ExpireDate} {Balans}";
        }
    }
}
