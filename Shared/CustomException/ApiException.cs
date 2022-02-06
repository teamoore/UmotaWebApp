using System;
namespace UmotaWebApp.Shared.CustomException
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {

        }

        public ApiException(Exception exception, string message) : base(message, exception)
        {

        }
    }
}
