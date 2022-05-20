using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Shared.ModelDto
{
    public class TakvimRequestDto : BaseRequestDto
    {
        public TakvimDto Takvim { get; set; }
    }
}
