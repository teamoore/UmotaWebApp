using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class V006Malzeme
{
    public int Logref { get; set; }

    public string Kodu { get; set; }

    public string Adi { get; set; }

    public int? Kaynakref { get; set; }

    public int? Birimsetiref { get; set; }

    public string Birimsetikodu { get; set; }

    public double? Kdvyuz { get; set; }

    public byte? Active { get; set; }

    public int? Lgmalzemeref { get; set; }

    public int? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public int? Lgfirmano { get; set; }

    public byte? Tip { get; set; }

    public string Muhhesapno { get; set; }

    public int? Birimref { get; set; }

    public string Marka { get; set; }

    public string Model { get; set; }

    public string Ebat { get; set; }

    public string Ozellik { get; set; }

    public bool? FrMalzeme { get; set; }

    public bool? FrIscilik { get; set; }

    public bool? FrGengidkar { get; set; }

    public bool? FrBirimfiyat { get; set; }

    public string Kaynakkodu { get; set; }

    public string Kaynakadi { get; set; }

    public string Kaynakuzunadi { get; set; }

    public string Kaynakkoduadi { get; set; }

    public string Aktivitekodu2 { get; set; }

    public string Aktiviteadi2 { get; set; }

    public string Aktivitekoduadi2 { get; set; }

    public string Aktivitekodu { get; set; }

    public string Aktiviteadi { get; set; }

    public string Aktivitekoduadi { get; set; }

    public string Birimkodu { get; set; }

    public string Birimadi { get; set; }
}
