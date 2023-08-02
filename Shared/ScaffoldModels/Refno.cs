using System;
using System.Collections.Generic;

namespace UmotaWebApp.Shared.ScaffoldModels;

public partial class Refno
{
    public string Tablename { get; set; }

    public int Increment { get; set; }

    public int Lastrefno { get; set; }
}
