using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class KaynakBirim
{
    public int Logref { get; set; }

    public int Parlogref { get; set; }

    public int Birimref { get; set; }

    public bool? Ondeger { get; set; }
}
