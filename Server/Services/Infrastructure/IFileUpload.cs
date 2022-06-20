using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IFileUpload
    {
        public Task<FileUploadDto> Upload(FileUploadRequestDto request,CancellationToken cancellationToken);
    }
}
