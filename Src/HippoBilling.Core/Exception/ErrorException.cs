using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Exception
{
    public class ErrorException : ApplicationException
    {
        public ErrorException(string message)
            : base(message)
        {
        }
    }
}
