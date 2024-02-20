using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class TalepFisLog
{
    public int Recref { get; set; }

    public int Logref { get; set; }

    public string Fisno { get; set; }

    public DateTime? Tarih { get; set; }

    public DateTime? Saat { get; set; }

    public int? Turref { get; set; }

    public int? Projeref { get; set; }

    public string Talepeden { get; set; }

    public DateTime? Teslimtarihi { get; set; }

    public int? Teslimyeriref { get; set; }

    public int? Durumref { get; set; }

    public byte? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public byte? Dosyaeki { get; set; }

    public byte? Oncelik { get; set; }

    public string Aciklama { get; set; }

    public int? Lgfirmano { get; set; }
}
