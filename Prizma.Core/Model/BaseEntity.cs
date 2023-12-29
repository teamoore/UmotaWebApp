using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core.Model
{
    public class BaseEntity
    {
        public int logref { get; set; }
        public byte status { get; set; }

        public string? insuser { get; set; }
        public DateTime? insdate { get; set; }
        public string? upduser { get; set; }
        public DateTime? upddate { get; set; }
    }
}
