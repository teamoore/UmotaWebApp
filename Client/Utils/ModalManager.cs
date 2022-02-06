using System;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using UmotaWebApp.Client.Components.ModalComponents;

namespace UmotaWebApp.Client.Utils
{
    public class ModalManager
    {
        public ModalManager(IModalService modalService)
        {
            ModalService = modalService;
        }

        public IModalService ModalService { get; }


        public async Task ShowMessageAsync(string Title, string Message, int duration = 0)
        {
            ModalParameters parameters = new ModalParameters();
            parameters.Add("message", Message);


            var modalRef = ModalService.Show<ShowMessagePopupComponent>(Title, parameters);

            if (duration > 0)
            {
                await Task.Delay(duration);
                modalRef.Close();
            }

        }

        public async Task<bool> ShowConfirmationAsync(string Title, string Message)
        {
            ModalParameters parameters = new ModalParameters();
            parameters.Add("message", Message);

            var modalRef = ModalService.Show<ConfirmationPopupComponent>(Title, parameters);
            var mResult = await modalRef.Result;

            return !mResult.Cancelled;
        }
    }
}
