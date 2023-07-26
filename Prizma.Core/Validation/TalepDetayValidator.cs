using FluentValidation;
using Prizma.Core.Model;

namespace Prizma.Core
{
    public class TalepDetayValidator : AbstractValidator<TalepDetay>
    {
        public TalepDetayValidator()
        {
            RuleFor(x => x.Miktar).NotNull().WithMessage(x => "Miktar boş geçilemez");
            RuleFor(x => x.Miktar).GreaterThan(0).WithMessage(x => "Miktar 0 dan küçük olamaz");
        }
    }
}
