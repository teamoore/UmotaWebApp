using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class MalzemeLog
{
    public int Recref { get; set; }

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
}
