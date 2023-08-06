using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class TalepOnay
{
    public int Logref { get; set; }

    public int? Onaytipref { get; set; }

    public int? Onayref { get; set; }

    public string Aciklama { get; set; }

    public byte? Status { get; set; }

    public string Insuser { get; set; }

    public DateTime? Insdate { get; set; }

    public string Upduser { get; set; }

    public DateTime? Upddate { get; set; }

    public int? Talepref { get; set; }

    public int? Talepdetayref { get; set; }

    public string Onayuser { get; set; }

    public string Onaymail { get; set; }

    public int? Onaysira { get; set; }

    public byte? Active { get; set; }

    public string Onaylayan { get; set; }

    public bool? Topluonay { get; set; }

    public string Onayuseradi { get; set; }

    public string Deluser { get; set; }

    public DateTime? Deldate { get; set; }
}
