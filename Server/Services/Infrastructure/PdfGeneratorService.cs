﻿using DinkToPdf;
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
                            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet= Path.Combine(Directory.GetCurrentDirectory(),"Media","css","bootstrap.min.css") },
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
            <td>Teklif Tarihi:</td><td>" + teklif.TarihFormatted + @"</td>
          </tr>
	      <tr>
            <td>Teklif No:</td><td>" + teklif.Teklifno + @"</td>
          </tr>
	      <tr>
            <td>Revize No:</td><td>" + teklif.Revzno + @"</td>
          </tr>
          <tr>
            <td>Firma:</td><td>" + teklif.Cariadi + @"</td>
          </tr>
        <tr>
            <td>Sayın:</td><td>" + teklif.IlgiliAdi + @"</td>
        </tr>
        <tr>
            <td>Proje Adı:</td><td>" + teklif.Proje + @"</td>
        </tr>
        <tr>
        <td>İlgili:</td><td>" + teklif.Temsilciadi + @"</td>
        </tr>";

            //switch (teklifPdfType)
            //{
            //    case SharedEnums.TeklifPdfType.Iskontolu:
            //        str += "<tr><td>İskonto Tutarı:</td><td>0.00</td></tr>";
            //        break;
            //    case SharedEnums.TeklifPdfType.Net:
            //        str += @"<tr>
            //                <td>Teklif Tutar:</td><td>" + teklif.Tutarmatrah + " " + teklif.Dovizdokuid + @"</td>
            //                </tr>";
            //        break;
            //    case SharedEnums.TeklifPdfType.NetKdv:
            //        str += @"<tr>
            //                <td>Teklif Tutar + KDV:</td><td>" + teklif.Tutarmatrah + " " + teklif.Dovizdokuid + @"</td>
            //                </tr>";
            //        break;
            //    default:
            //        break;
            //}

            //str += @"<tr> <td>Genel Toplam:</td><td>" + teklif.Tutarmatrah + " " + teklif.Dovizdokuid + @"</td>
            //                </tr>";

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
 
    <tr>
            <th scope='col'>POZ</th>
            <th scope='col'>MALZEME LİSTESİ</th>
            <th scope='col'>EBAT</th>
            <th scope='col'>MARKA</th>
            <th scope='col'>MENŞEİ</th>
            <th scope='col'>ADET</th>
            <th scope='col'>BİRİM FİYAT</th>
            <th scope='col'>DÖVİZ</th>
            <th scope='col'>TOPLAM FİYAT</th>
    </tr>
 
";
                double toptutar = 0;
                double topisktutar = 0;
                double topkdvtutar = 0;
                foreach (var item in teklifDetays)
                {
                    str += "<tr>";
                    str += Cell(item.Sipnosira);
                    str += Cell(item.Malzadi);
                    str += Cell(item.Ebat);
                    str += Cell(item.Marka);
                    str += Cell(item.Mensei);
                    str += Cell(item.Miktar);

                    switch (teklifPdfType)
                    {
                        case SharedEnums.TeklifPdfType.Iskontolu:
                            str += Cell(item.Fiyatid);
                            str += Cell(teklif.Dovizdokuid);
                            str += Cell(item.Tutarid);
                            toptutar += item.Tutarid.Value;
                            topisktutar += item.Isktut1id.Value + item.Isktut2id.Value + item.Isktut3id.Value + item.Isktut4id.Value;
                            break;
                        case SharedEnums.TeklifPdfType.Net:
                            str += Cell(item.NetFiyatid);
                            str += Cell(teklif.Dovizdokuid);
                            str += Cell(item.Kdvmatrahid);
                            toptutar += item.Kdvmatrahid.Value;
                            break;
                        case SharedEnums.TeklifPdfType.NetKdv:
                            str += Cell(item.NetFiyatid);
                            str += Cell(teklif.Dovizdokuid);
                            str += Cell(item.Kdvmatrahid);
                            toptutar += item.Kdvmatrahid.Value;
                            topkdvtutar += item.Kdvtutid.Value;
                            break;
                        default:
                            break;
                    }

                    str += "</tr>";
                }

                str += "<tr>";
                str += Cell("");
                str += Cell("TOPLAM BEDEL");
                str += Cell("");
                str += Cell("");
                str += Cell("");
                str += Cell("");
                str += Cell("");
                str += Cell(teklif.Dovizdokuid);
                str += Cell(toptutar);
                str += "</tr>";

                if (teklifPdfType == SharedEnums.TeklifPdfType.Iskontolu)
                {
                    str += "<tr>";
                    str += Cell("");
                    str += Cell("İSKONTO TOPLAMI");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell(teklif.Dovizdokuid);
                    str += Cell(topisktutar);
                    str += "</tr>";

                    str += "<tr>";
                    str += Cell("");
                    str += Cell("GENEL TOPLAM");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell(teklif.Dovizdokuid);
                    str += Cell(toptutar-topisktutar);
                    str += "</tr>";
                }

                if (teklifPdfType == SharedEnums.TeklifPdfType.NetKdv)
                {
                    str += "<tr>";
                    str += Cell("");
                    str += Cell("KDV TOPLAMI");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell(teklif.Dovizdokuid);
                    str += Cell(topkdvtutar);
                    str += "</tr>";

                    str += "<tr>";
                    str += Cell("");
                    str += Cell("GENEL TOPLAM");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell(teklif.Dovizdokuid);
                    str += Cell(toptutar + topkdvtutar);
                    str += "</tr>";
                }


                str += "</table>";

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
                return "<td></td>";

            return "<td>"+ td +"</td>";
        }


    }
}
