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
        }
    }
}
