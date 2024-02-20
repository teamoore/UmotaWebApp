using FluentValidation;
using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core
{
    public class TalepFisValidator : AbstractValidator<TalepFis>
    {
        public TalepFisValidator()
        {
            RuleFor(x => x.Tarih).LessThanOrEqualTo(x => x.TeslimTarihi).WithMessage("Teslim tarihi, talep tarihinden önce olamaz");
            RuleFor(x => x.TeslimTarihi).GreaterThan(x => x.Tarih.AddDays(2)).WithMessage("Teslim tarihi, talep edilen tarihten en az 3 gün fazla olmalıdır");
        }
    }
}
