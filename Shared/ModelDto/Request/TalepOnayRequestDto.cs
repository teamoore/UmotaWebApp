﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto.Request
{
    public class TalepOnayRequestDto
    {
        public short FirmaId { get; set; }
        public string kullanicikodu { get; set; }
        public int TalepRef { get; set; }
        public int OnayLineRef { get; set; }
        public int OnayDurumu { get; set; }
        public string Aciklama { get; set; }

    }
}
