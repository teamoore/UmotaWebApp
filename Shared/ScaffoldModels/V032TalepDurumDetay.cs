using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class V032TalepDurumDetay
{
    public int Refid { get; set; }

    public int? Talepref { get; set; }

    public DateTime? Tarih { get; set; }

    public int? Durumref { get; set; }

    public byte? Sira { get; set; }

    public string Aciklama { get; set; }

    public string KullaniciKodu { get; set; }

    public string Durumkodu { get; set; }

    public int? Durumikodu { get; set; }

    public string Durumadi { get; set; }

    public string DurumOzelKod1 { get; set; }

    public short DurumSiralama { get; set; }
}
