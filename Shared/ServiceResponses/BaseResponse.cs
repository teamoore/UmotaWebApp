using System;
namespace UmotaWebApp.Shared.ServiceResponses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public void SetException(Exception ex)
        {
            Success = false;
            Message = ex.Message;
        }
    }
}
