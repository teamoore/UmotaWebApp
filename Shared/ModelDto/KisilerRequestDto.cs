﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class KisilerRequestDto
    {
        public KisilerDto Kisiler { get; set; }
        public short FirmaId { get; set; }
        public string SearchText { get; set; }

    }
}
