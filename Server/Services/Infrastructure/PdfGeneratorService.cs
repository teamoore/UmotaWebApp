using DinkToPdf;
using System;
using System.Collections.Generic;
using System.IO;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Server.Services.Consts;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class PdfGeneratorService : IPdfGenerator
    {
        public PdfGeneratorService()
        {

        }

        public MemoryStream CreateTeklifDetayPdf(TeklifDto teklif, List<TeklifDetayDto> teklifDetays)
        {
            var converter = new SynchronizedConverter(new PdfTools());
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
                            HtmlContent = CreateHtml(teklif,teklifDetays),
                            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" },
                            HeaderSettings = { FontSize = 11, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                        }
                         }
            };

            byte[] pdf = converter.Convert(doc);

            return new MemoryStream(pdf);
        }

        private string CreateHtml(TeklifDto teklif, List<TeklifDetayDto> teklifDetays)
        {
            var str = "<html><head>" +
                "<link href='"+ Environment.CurrentDirectory + "/Media/css/bootstrap.min.css' rel='stylesheet' type='text/css' media='screen'/>"
                + "</head>" +
                "<body><div class='container'><h1>Teklif No : "+ teklif.Teklifno +"</h1>";

            str += "<h3>Cari Adı : "+ teklif.Cariadi +"</h3>";
            str += "<h4>Teklif Tarihi : "+ teklif.TarihFormatted +"</h4>";
            str += "<h4>Teslim Tarihi : "+ teklif.TeslimTarihiFormatted +"</h4>";
            str += "<h4></h4>";
            if (teklifDetays != null && teklifDetays.Count != 0)
            {
                str += "<table class='table table-striped'>";
                str += @"
  <thead>
    <tr>
        <th scope='col'>#</th>
      <th scope='col'>Çizim Kodu</th>
      <th scope='col'>Poz No</th>
      <th scope='col'>Stok Kodu</th>
      <th scope='col'>Stok Adı</th>
        <th scope='col'>Miktar</th>
        <th scope='col'>Birim</th>
    </tr>
  </thead>
<tbody>
";
                var i = 1;
                foreach (var item in teklifDetays)
                {
                    str += string.Format("<tr><th scope='row'>{0}</th><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{5}</td></tr>",
                        i.ToString(),
                        item.Cizimkodu.ToValueString(),
                        item.Sipnosira.ToValueString(),
                        item.Malzkodu.ToValueString(),
                        item.Malzadi.ToValueString(),
                        item.Miktar?.ToString(),
                        item.Birimkodu.ToValueString());
                    i++;
                }
                str += "</tbody></table>";

            }

            str += "</div></body></html>";

            return str;
        }
    }
}
