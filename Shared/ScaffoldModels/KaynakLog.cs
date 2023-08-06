using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class KaynakLog
{
    public int Recref { get; set; }

    public int Logref { get; set; }

    public int Parlogref { get; set; }

    public string Kodu { get; set; }

    public string Adi { get; set; }

    public byte? Seviye { get; set; }

    public string Uzunkodu { get; set; }

    public string Uzunadi { get; set; }

    public int Aktiviteref { get; set; }

    public byte? Active { get; set; }

    public int? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public double? Kdvyuz { get; set; }
}
