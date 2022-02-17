using System;
using System.Runtime.Serialization;

namespace UmotaWebApp.Server.Controllers
{
    [Serializable]
    internal class ApiExcetion : Exception
    {
        public ApiExcetion()
        {
        }

        public ApiExcetion(string message) : base(message)
        {
        }

        public ApiExcetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiExcetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}