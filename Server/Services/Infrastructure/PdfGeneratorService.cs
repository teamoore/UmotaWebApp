using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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

        public MemoryStream CreateTeklifDetayPdf(TeklifDto teklif, List<TeklifDetayDto> teklifDetays, SharedEnums.TeklifPdfType teklifPdfType, short FirmaId)
        {
            string strfooter = "Uno Endüstriyel - www.unoendustriyel.com";
            if (FirmaId == 101)
                strfooter = "Makpa Endüstriyel Mutfak - www.ankaramakpa.com";
            if (FirmaId == 200)
                strfooter = "Gastromore - www.gastromore.com";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Margins = new MarginSettings { Top = 18, Bottom = 18 },
                        },
                Objects = {
                        new ObjectSettings() {
                            PagesCount = true,
                            HtmlContent = CreateHtml(teklif,teklifDetays,teklifPdfType, FirmaId),
                            WebSettings = { 
                                DefaultEncoding = "utf-8"
                            },
                            
                            HeaderSettings = { FontSize = 11, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                            FooterSettings = { FontSize = 9, Spacing = 2.8, FontName = "Roboto", Center = strfooter }
                        }
                         }
            };

            byte[] pdf = converter.Convert(doc);

            return new MemoryStream(pdf);
        }

        private string CreateHtml(TeklifDto teklif, List<TeklifDetayDto> teklifDetays, SharedEnums.TeklifPdfType teklifPdfType, short FirmaId)
        {
            var css = Environment.CurrentDirectory +  @"\Media\css\bootstrap.min.css";
            var path = Environment.CurrentDirectory + "\\Media\\logo\\logo.jpeg";
            var path_opac = Environment.CurrentDirectory + "\\Media\\logo\\logo_opac3.png";
            if (FirmaId == 101)
            {
                path = Environment.CurrentDirectory + "\\Media\\logo\\logo_makpa.jpeg";
                path_opac = Environment.CurrentDirectory + "\\Media\\logo\\logo_makpa_opac.png";
            }
            //if (FirmaId == 200)
            //{
            //    path = Environment.CurrentDirectory + "\\Media\\logo\\logo_gastromore.jpeg";
            //    path_opac = Environment.CurrentDirectory + "\\Media\\logo\\logo_gastromore_opac.png";
            //}

            var str = "<html><head>" +
                "<link href='"+ css +"' rel='stylesheet' type='text/css' media='screen'/>"

                + "</head>" +
                "<body style='font-family:Roboto,Arial;' background='" + path_opac +"'>" +
                @"<table style='width:100%;background-color:#4700D8;text-align:center;color:white;font-weight:bold;font-family:Roboto,Arial;'><tr><td style='height:30px;'>TEKLİF</td></tr></table><div class='container'>";

            

            str += @" <table class='table table-striped'>
  <tr>
	<td>
        <p><b>Firma : " + teklif.Cariadi + @"</b><br>
        <b>Sayın : "+ teklif.IlgiliAdi + @"</b><br><br>
        <b>Teklif No  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " + teklif.Teklifno + @"</b><br>
        <b>Revize No    &nbsp;&nbsp;&nbsp;: " + teklif.Revzno + @"</b><br>
        <b>Teklif Tarihi&nbsp;&nbsp;: " + teklif.TarihFormatted + @"</b><br>
        <b>Teslim Tarihi: " + teklif.TeslimTarihiFormatted + @"</b><br>
        <b>Proje Adı  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " + teklif.Proje + @"</b><br>
        <b>İlgili Adı &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " + teklif.Temsilciadi + @"</b><br>
        </p>
		";
        str += @" 

	</td>
	<td style='width:200px;'><img style='height:150px;' src='"+ path + @"'></td>
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
                            str += Cell(item.Fiyatid,alignRight:true);
                            str += Cell(teklif.Dovizdokuid, alignRight: true);
                            str += Cell(item.Tutarid, alignRight: true);
                            toptutar += item.Tutarid.Value;
                            topisktutar += item.Isktut1id.Value + item.Isktut2id.Value + item.Isktut3id.Value + item.Isktut4id.Value;
                            break;
                        case SharedEnums.TeklifPdfType.Net:
                            str += Cell(item.NetFiyatid, alignRight: true);
                            str += Cell(teklif.Dovizdokuid, alignRight: true);
                            str += Cell(item.Kdvmatrahid, alignRight: true);
                            toptutar += item.Kdvmatrahid.Value;
                            break;
                        case SharedEnums.TeklifPdfType.NetKdv:
                            str += Cell(item.NetFiyatid, alignRight: true);
                            str += Cell(teklif.Dovizdokuid, alignRight: true);
                            str += Cell(item.Kdvmatrahid, alignRight: true);
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
                str += Cell("TOPLAM BEDEL",true);
                str += Cell("");
                str += Cell("");
                str += Cell("");
                str += Cell("");
                str += Cell("");
                str += Cell(teklif.Dovizdokuid,true,true);
                str += Cell(toptutar,true,true);
                str += "</tr>";

                if (teklifPdfType == SharedEnums.TeklifPdfType.Iskontolu)
                {
                    str += "<tr>";
                    str += Cell("");
                    str += Cell("İSKONTO TOPLAMI",true);
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell(teklif.Dovizdokuid,true,true);
                    str += Cell(topisktutar,true,true);
                    str += "</tr>";

                    str += "<tr>";
                    str += Cell("");
                    str += Cell("GENEL TOPLAM",true);
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell(teklif.Dovizdokuid,true,true);
                    str += Cell(toptutar-topisktutar,true,true);
                    str += "</tr>";
                }

                if (teklifPdfType == SharedEnums.TeklifPdfType.NetKdv)
                {
                    str += "<tr>";
                    str += Cell("");
                    str += Cell("KDV TOPLAMI",true);
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell(teklif.Dovizdokuid,true,true);
                    str += Cell(topkdvtutar,true,true);
                    str += "</tr>";

                    str += "<tr>";
                    str += Cell("");
                    str += Cell("GENEL TOPLAM",true);
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell("");
                    str += Cell(teklif.Dovizdokuid,true,true);
                    str += Cell(toptutar + topkdvtutar,true,true);
                    str += "</tr>";
                }


                str += "</table>";

            }

            if (string.IsNullOrEmpty(teklif.Notlar) == false)
            {
                string result = Regex.Replace(teklif.Notlar, @"\r\n?|\n", "<br>");

                str += "<STRONG>TEKLİF İLE İLGİLİ BİLGİLER</STRONG><p style='font-size:9pt;'>"+ result +"</p>";
            }
            str += "</div></body></html>";

            return str;
        }

        private string Cell(double? td,bool bold = false, bool alignRight = false)
        {
            var s = new StringBuilder();
            
            if (td.HasValue == false && alignRight)
                return "<td style='text-align:right;'>0.00</td>";

            if (td.HasValue == false)
                return "<td>0.00</td>";

            if (alignRight)
                s.Append("<td style='text-align:right;'>");
            else
                s.Append("<td>");

            if (bold)
                s.Append("<b>" + string.Format("{0:N2}", td.Value) + "</b>");
            else
                s.Append(string.Format("{0:N2}", td.Value));
            
            s.Append("</td>");

            return s.ToString();
        }

        private string Cell(string td, bool bold = false, bool alignRight = false)
        {
            if (string.IsNullOrEmpty(td))
                return "<td></td>";

            var s = new StringBuilder();
            if (alignRight)
                s.Append("<td style='text-align:right'>");
            else
                s.Append("<td>");

            if (bold)
                s.Append("<b>" + td + "</b>");
            else
                s.Append(td);

            s.Append("</td>");

            return s.ToString();
        }


        #region Servis

        private string CreateServisBilgilendirmeHtml(ServisDto servis, List<ServisMalzemeDto> malzemeler)
        {
            var css = Environment.CurrentDirectory + @"\Media\css\bootstrap.min.css";
            var path = Environment.CurrentDirectory + "\\Media\\logo\\logo.jpeg";
            var path_opac = Environment.CurrentDirectory + "\\Media\\logo\\logo_opac3.png";

            var str = "<html><head>" +
                "<link href='" + css + "' rel='stylesheet' type='text/css' media='screen'/>"

                + "</head>" +
                "<body style='font-family:Roboto,Arial;'>" +
                @"<table style='width:100%;background-color:#4700D8;text-align:center;color:white;font-weight:bold;font-family:Roboto,Arial;'><tr><td style='height:30px;'>SERVİS BİLGİLENDİRME FORMU</td></tr></table><div class='container'>";

            str += @" 
<table class='table table-striped'><tr><td></td>
	<td style='text-align:center;'><img style='height:150px;' src='" + path + @"'></td>
<td style='width:200px;'></br></br>
<b>TARİH</b> : "+ DateTime.Now.ToShortDateString() +@"
</br><b>Fiş No:</b>"+ servis.Fisno +@"
</td>
  </tr>
  </table>
<hr/>";

            str += "<p><b>SAYIN:</b></p>";
            str += "<p>"+ servis.Servisadi +"</br>"+ servis.ServisIlgiliKisi +"</p>";

            str += @"<p><b>Merhaba</b></p><p>Aşağıda detayları belirtilmiş olan talep siz değerli çözüm ortağımıza yönlendirilmiş olup, en geç 24
saat içerisinde müdahale edilmesini ve verilen servise müteakip konu ile ilgili tarafımızın bilgilendirilmesini rica ediyoruz. 
İlgili servis formunun eksiksiz ve zamanında gönderilmesi konusunda hassasiyetiniz için teşekkür ederiz.</p>";

            str += @"<p><b>MÜŞTERİ:</b></br>" + servis.Cariadi + "</br>" + servis.IlgiliKisi + "</br>" + servis.IslemAdresi;
            str += "</br>" + servis.IslemIlce + "</br>" + servis.IslemSehir;
            str += "</p>";

            str += "<p><b>CİHAZ:</b></br>";
            if (malzemeler != null && malzemeler.Count > 0 )
            {
                foreach (var item in malzemeler)
                {
                    str += item.LstokAdi + "</br>";
                }
            }
            str += "</p>";

            return str;
        }

        private string CreateMusteriBilgilendirmeHtml(ServisDto servis, List<ServisMalzemeDto> malzemeler)
        {
            var css = Environment.CurrentDirectory + @"\Media\css\bootstrap.min.css";
            var path = Environment.CurrentDirectory + "\\Media\\logo\\logo.jpeg";
            var path_opac = Environment.CurrentDirectory + "\\Media\\logo\\logo_opac3.png";

            var str = "<html><head>" +
                "<link href='" + css + "' rel='stylesheet' type='text/css' media='screen'/>"

                + "</head>" +
                "<body style='font-family:Roboto,Arial;'>" +
                @"<table style='width:100%;background-color:#4700D8;text-align:center;color:white;font-weight:bold;font-family:Roboto,Arial;'><tr><td style='height:30px;'>SERVİS BİLGİLENDİRME FORMU</td></tr></table><div class='container'>";

            str += @" 
<table class='table table-striped'><tr><td></td>
	<td style='text-align:center;'><img style='height:150px;' src='" + path + @"'></td>
<td style='width:200px;'></br></br>
<b>TARİH</b> : " + DateTime.Now.ToShortDateString() + @"
</td>
  </tr>
  </table>
<hr/>";

            str += "<p><b>SAYIN:</b></p>";
            str += "<p>" + servis.Cariadi + "</br>" + servis.IlgiliKisi + "</p>";

            str += @"<p><b>Merhaba</b></p><p>Talebiniz doğrultusunda aşağıda detayları bulunan cihazınız ile ilgili servis kaydı oluşturulmuştur.
Talebiniz servis ekibinin yarınki planlamasına dahil edilmiş olup , günlük iş programında uygun zamanın
oluşması halinde bugün içersinde müdahele edilecektir. Müdahale edecek servisin iletişim bilgileri aşağıdaki gibidir. 
Herhangi bir problemle karşılaşmanız durumunda servis@unoendustriyel.com adresinden bizimle irtibata geçebilirsiniz.</p>";

            str += @"<p><b>SERVİS:</b></br>" + servis.Servisadi + "</br>" + servis.ServisIlgiliKisi + "</br>" + servis.ServisIlgiliTel;
            
            str += "<p><b>CİHAZ:</b></br>";
            if (malzemeler != null && malzemeler.Count > 0)
            {
                foreach (var item in malzemeler)
                {
                    str += item.LstokAdi + "</br>";
                }
            }
            str += "</p>";

            return str;
        }

        public MemoryStream CreateServisBilgilendirmePdf(ServisDto servis, List<ServisMalzemeDto> malzemeler)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Margins = new MarginSettings { Top = 18, Bottom = 18 },
                        },
                Objects = {
                        new ObjectSettings() {
                            PagesCount = true,
                            HtmlContent = CreateServisBilgilendirmeHtml(servis,malzemeler),
                            WebSettings = {
                                DefaultEncoding = "utf-8"
                            },

                            HeaderSettings = { FontSize = 11, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                            FooterSettings = { FontSize = 9, Spacing = 2.8, FontName = "Roboto", Center = "Uno Endüstriyel - www.unoendustriyel.com" }
                        }
                         }
            };

            byte[] pdf = converter.Convert(doc);

            return new MemoryStream(pdf);
        }

        public MemoryStream CreateMusteriBilgilendirmePdf(ServisDto servis, List<ServisMalzemeDto> malzemeler)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Margins = new MarginSettings { Top = 18, Bottom = 18 },
                        },
                Objects = {
                        new ObjectSettings() {
                            PagesCount = true,
                            HtmlContent = CreateMusteriBilgilendirmeHtml(servis,malzemeler),
                            WebSettings = {
                                DefaultEncoding = "utf-8"
                            },

                            HeaderSettings = { FontSize = 11, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                            FooterSettings = { FontSize = 9, Spacing = 2.8, FontName = "Roboto", Center = "Uno Endüstriyel - www.unoendustriyel.com" }
                        }
                         }
            };

            byte[] pdf = converter.Convert(doc);

            return new MemoryStream(pdf);
        }

        #endregion

    }
}
