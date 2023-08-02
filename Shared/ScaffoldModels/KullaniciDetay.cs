using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class KullaniciDetay
{
    public int Logref { get; set; }

    public string KullaniciKodu { get; set; }

    public string Aciklama { get; set; }

    public int? Gorevref { get; set; }

    public int? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public byte[] Imza { get; set; }
}
