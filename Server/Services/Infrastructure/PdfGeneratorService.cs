using DinkToPdf;
using DinkToPdf.Contracts;
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
        private IConverter converter { get; set; }

        public PdfGeneratorService(IConverter converter)
        {
            this.converter = converter;
        }

        public MemoryStream CreateTeklifDetayPdf(TeklifDto teklif, List<TeklifDetayDto> teklifDetays)
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
                "<body><div class='container'>" +
                "<h2>Uno Pazar</h2>"+
                "<h4>Teklif No : "+ teklif.Teklifno +"</h4>";

            str += "<h4>Cari Adı : "+ teklif.Cariadi +"</h4>";
            str += "<h4>Teklif Tarihi : "+ teklif.TarihFormatted +"</h4>";
            str += "<h4>Teslim Tarihi : "+ teklif.TeslimTarihiFormatted +"</h4>";
            str += "<h4>Teklif Tutar : " + teklif.Tutarmatrah + " " + teklif.Dovizdokuid +"</h4>";
            str += "<hr/>";

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
                    str += string.Format("<tr><th scope='row'>{0}</th><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td></tr>",
                        i.ToString(),
                        item.Sipnosira.ToValueString(),
                        item.Malzkodu.ToValueString(),
                        item.Malzadi.ToValueString(),
                        item.Miktar?.ToString(),
                        item.Birimkodu.ToValueString(),     
                        string.Format("{0:N2}", item.NetFiyat.Value),
                        string.Format("{0:N2}", item.Kdvmatrahid.Value)
                        );
                    i++;
                }
                str += "</tbody></table>";

            }

            str += "</div></body></html>";

            return str;
        }
    }
}
