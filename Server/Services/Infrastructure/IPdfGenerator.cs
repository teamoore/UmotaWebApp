using System.Collections.Generic;
using System.IO;
using UmotaWebApp.Shared.Enum;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IPdfGenerator
    {
        public MemoryStream CreateTeklifDetayPdf(TeklifDto teklif, List<TeklifDetayDto> teklifDetays, SharedEnums.TeklifPdfType teklifPdfType);

        public MemoryStream CreateServisBilgilendirmePdf(ServisDto servis, List<ServisMalzemeDto> malzemeler);

        public MemoryStream CreateMusteriBilgilendirmePdf(ServisDto servis, List<ServisMalzemeDto> malzemeler);
    }
}
