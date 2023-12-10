using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Exceptions
{
    public class PanNotFoundException : ApplicationException
    {
        public PanNotFoundException(string message="Pan isn't found") : base(message)
        {

        }
    }
}
