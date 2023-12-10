using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public History[] Histories { get; set; } = Array.Empty<History>();
        public Card Card { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
