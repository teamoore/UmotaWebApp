using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class TalepOnayAkisi
{
    public int Logref { get; set; }

    public int? Talepturref { get; set; }

    public int Sira { get; set; }

    public int? Onaytipref { get; set; }

    public string KullaniciKodu { get; set; }

    public string Mail { get; set; }

    public int? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public int? Gorevref { get; set; }

    public int? Projeref { get; set; }
}
