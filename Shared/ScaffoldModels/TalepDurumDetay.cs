using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class TalepDurumDetay
{
    public int Refid { get; set; }

    public int? Talepref { get; set; }

    public DateTime? Tarih { get; set; }

    public int? Durumref { get; set; }

    public byte? Sira { get; set; }

    public string Aciklama { get; set; }

    public string KullaniciKodu { get; set; }
}
