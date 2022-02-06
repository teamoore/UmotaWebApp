using System;
namespace UmotaWebApp.Shared.ServiceResponses
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }
    }
}
