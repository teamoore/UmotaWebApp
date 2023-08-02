using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class V011KullaniciDetayProje
{
    public int Logref { get; set; }

    public int Parlogref { get; set; }

    public string KullaniciKodu { get; set; }

    public int? Projeref { get; set; }

    public string Aciklama { get; set; }

    public byte? Active { get; set; }

    public int? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public int? Gorevref { get; set; }

    public string Projekodu { get; set; }

    public string Projeadi { get; set; }

    public string Sirketadi { get; set; }

    public string KullaniciAdi { get; set; }

    public string Gorevkodu { get; set; }

    public string Gorevadi { get; set; }

    public int? Gorevikodu { get; set; }
}
