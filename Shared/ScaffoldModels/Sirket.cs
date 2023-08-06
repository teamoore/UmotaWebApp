using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class Sirket
{
    public int Logref { get; set; }

    public string Kodu { get; set; }

    public string Adi { get; set; }

    public byte? Active { get; set; }

    public int? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public int? Lgfirmano { get; set; }

    public int? Lgconfirmano { get; set; }
}
