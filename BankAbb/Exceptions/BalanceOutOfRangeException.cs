using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Exceptions
{
    internal class BalanceOutOfRangeException:ApplicationException
    {
        public BalanceOutOfRangeException(string message = "Balance out of range") : base(message)
        {

        }
    }
}
