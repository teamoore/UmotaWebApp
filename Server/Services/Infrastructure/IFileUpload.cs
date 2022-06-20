using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IFileUpload
    {
        public Task<FileUploadDto> Upload(IBrowserFile file,CancellationToken cancellationToken);

        public Task<FileUploadDto> Upload(FileDataDto file);
        public Task<bool> Save(FileUploadRequestDto request);
    }
}
