using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Exceptions
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(string message = "User not found") : base(message)
        {

        }
    }
}
