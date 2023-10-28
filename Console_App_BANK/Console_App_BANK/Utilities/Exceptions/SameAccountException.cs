using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_BANK.Utilities.Exceptions
{
    internal class SameAccountException:Exception
    {
        public SameAccountException(string messsage):base(messsage) 
        {
            
        }
    }
}
