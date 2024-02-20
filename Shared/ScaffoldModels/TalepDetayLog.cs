using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class TalepDetayLog
{
    public int Recref { get; set; }

    public int Logref { get; set; }

    public int? Parlogref { get; set; }

    public double? Sirano { get; set; }

    public int? Mahal1ref { get; set; }

    public int? Mahal2ref { get; set; }

    public int? Mahal3ref { get; set; }

    public int? Mahal4ref { get; set; }

    public int? Mahal5ref { get; set; }

    public int? Kaynakref { get; set; }

    public int? Aktivite1ref { get; set; }

    public int? Aktivite2ref { get; set; }

    public int? Aktivite3ref { get; set; }

    public int? Aktivite4ref { get; set; }

    public int? Aktivite5ref { get; set; }

    public double? Miktar { get; set; }

    public int? Birimref { get; set; }

    public string Aciklama { get; set; }

    public int? Teslimyeriref { get; set; }

    public DateTime? Teslimtarihi { get; set; }

    public int? Durumref { get; set; }

    public byte? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public double? Sipmiktar { get; set; }

    public double? Fismiktar { get; set; }

    public double? Kalanmiktar { get; set; }

    public double? Plfismiktar { get; set; }

    public double? Plsipmiktar { get; set; }

    public string Marka { get; set; }
}
