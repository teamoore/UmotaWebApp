using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class Proje
{
    public int Logref { get; set; }

    public string Kodu { get; set; }

    public string Adi { get; set; }

    public int? Sirketref { get; set; }

    public byte? Active { get; set; }

    public byte? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public int? Lgisyerino { get; set; }

    public int? Lgambarno { get; set; }

    public int? Lgbolumno { get; set; }

    public int? Lgfabrikano { get; set; }

    public string Kredikartihesapno { get; set; }

    public string Kasano { get; set; }

    public decimal? KonutSatilabilirAlanM2 { get; set; }

    public decimal? RezidansSatilabilirAlanM2 { get; set; }

    public decimal? TicariSatilabilirAlanM2 { get; set; }

    public decimal? OfisSatilabilirAlanM2 { get; set; }

    public decimal? SosyalTesisM2 { get; set; }

    public decimal? OtoparklarKonutTicaretOfisM2 { get; set; }

    public decimal? CamiInsaatiM2 { get; set; }

    public decimal? IlkokulInsaatM2 { get; set; }

    public decimal? ParkInsaatM2 { get; set; }

    public decimal? ToplamInsaatAlaniM2 { get; set; }

    public decimal? ToplamSatilabilirAlanM2 { get; set; }

    public int? ToplamDaireSayisiAdet { get; set; }

    public int? ToplamTicariSayisiAdet { get; set; }
}
