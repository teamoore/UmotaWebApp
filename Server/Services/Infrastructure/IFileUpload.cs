using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
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
        public Task<ImageDataDto> Save(FileUploadRequestDto request);
        public Task<List<ImageDataDto>> GetList(FileUploadRequestDto request);
        public Task<bool> DeleteFile(FileUploadRequestDto request);
    }
}
