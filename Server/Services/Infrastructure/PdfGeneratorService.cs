using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Server.Services.Consts;
using UmotaWebApp.Shared.Enum;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class PdfGeneratorService : IPdfGenerator
    {
        private IConverter converter { get; set; }
        public PdfGeneratorService(IConverter converter)
        {
            this.converter = converter;
        }

        public MemoryStream CreateTeklifDetayPdf(TeklifDto teklif, List<TeklifDetayDto> teklifDetays, SharedEnums.TeklifPdfType teklifPdfType)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        },
                Objects = {
                        new ObjectSettings() {
                            PagesCount = true,
                            HtmlContent = CreateHtml(teklif,teklifDetays,teklifPdfType),
                            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" },
                            HeaderSettings = { FontSize = 11, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                        }
                         }
            };

            byte[] pdf = converter.Convert(doc);

            return new MemoryStream(pdf);
        }

        private string CreateHtml(TeklifDto teklif, List<TeklifDetayDto> teklifDetays, SharedEnums.TeklifPdfType teklifPdfType)
        {
            var str = "<html><head>" +
                "<link href='" + Environment.CurrentDirectory + "\\Media\\css\\bootstrap.min.css' rel='stylesheet' type='text/css' media='screen'/>"

                + "</head>" +
                "<body><table style='width:100%;background-color:grey;text-align:center;color:white;font-weight:bold;'><tr><td>TEKLİF</td></tr></table><div class='container'>";

            var path = Environment.CurrentDirectory + "\\Media\\logo\\uno_logo.PNG";

            str += @" <table style='width:100%;border:none !important;'>
  <tr>
	<td>
		<table style='width:400px;'>
			<tr>
        <td>Teklif No:</td><td>" + teklif.Teklifno + @"</td>
      </tr>
      <tr>
        <td>Cari Adı:</td><td>" + teklif.Cariadi + @"</td>
      </tr>
<tr>
    <td>Proje Adı:</td><td>" + teklif.Proje + @"</td>
</tr>
<tr>
    <td>İlgili Kişi:</td><td>" + teklif.IlgiliAdi + @"</td>
</tr>
      <tr>
        <td>Teklif Tarihi:</td><td>" + teklif.TarihFormatted + @"</td>
      </tr>
      <tr>
        <td>Teslim Tarihi:</td><td>" + teklif.TeslimTarihiFormatted + @"</td>
      </tr>";

            switch (teklifPdfType)
            {
                case SharedEnums.TeklifPdfType.Iskontolu:
                    str += "<tr><td>İskonto Tutarı:</td><td>0.00</td></tr>";
                    break;
                case SharedEnums.TeklifPdfType.Net:
                    str += @"<tr>
                            <td>Teklif Tutar:</td><td>" + teklif.Tutarmatrah + " " + teklif.Dovizdokuid + @"</td>
                            </tr>";
                    break;
                case SharedEnums.TeklifPdfType.NetKdv:
                    str += @"<tr>
                            <td>Teklif Tutar + KDV:</td><td>" + teklif.Tutarmatrah + " " + teklif.Dovizdokuid + @"</td>
                            </tr>";
                    break;
                default:
                    break;
            }

            str += @"<tr> <td>Genel Toplam:</td><td>" + teklif.Tutarmatrah + " " + teklif.Dovizdokuid + @"</td>
                            </tr>";

            str += @"</table>

	</td>
	<td><img style='height:150px;' src='"+ path + @"'></td>
  </tr>
  </table>
<hr/>";

            if (teklifDetays != null && teklifDetays.Count != 0)
            {
                str += "<table class='table table-striped'>";
                str += @"
  <thead>
    <tr>
            <th scope='col'>#</th>
      
            <th scope='col'>Poz No</th>
            <th scope='col'>Stok Kodu</th>
            <th scope='col'>Stok Adı</th>
            <th scope='col'>Miktar</th>
            <th scope='col'>Birim</th>
            <th scope='col'>Birim Fiyat</th>
            <th scope='col'>Tutar</th>
    </tr>
  </thead>
<tbody>
";
                var i = 1;
                foreach (var item in teklifDetays)
                {
           
                    str += "<tr>";
                    str += "<th scope='row'>"+ i +"</th>";

                    str += Cell(item.Sipnosira);
                    str += Cell(item.Malzkodu);
                    str += Cell(item.Malzadi);
                    str += Cell(item.Miktar);
                    str += Cell(item.Birimkodu);
                    str += Cell(item.NetFiyat);
                    str += Cell(item.Kdvmatrahid);

                    str += "</tr>";
                    i++;
                }
                str += "</tbody></table>";

            }

            str += "</div></body></html>";

            return str;
        }

        private string Cell(double? td)
        {
            if (td.HasValue == false)
                return "<td>0.00</td>";

            return "<td>" + string.Format("{0:N2}", td.Value) + "</td>";
        }

        private string Cell(string td)
        {
            if (string.IsNullOrEmpty(td))
                return "<td>--</td>";

            return "<td>"+ td +"</td>";
        }


    }
}
