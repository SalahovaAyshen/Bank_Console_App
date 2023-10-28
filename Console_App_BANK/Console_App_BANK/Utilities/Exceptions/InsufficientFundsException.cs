using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_BANK.Utilities.Exceptions
{
    internal class InsufficientFundsException:Exception 
    {
        public InsufficientFundsException(string message): base(message) { }
        
    }
}
