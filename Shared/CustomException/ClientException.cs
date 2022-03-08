using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.CustomException
{
    public class ClientException : Exception
    {
        public IEnumerable<string> ErrorList { get; set; }
        public ClientException(string message) : base(message)
        {

        }
    }
}
