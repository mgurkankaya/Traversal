using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.Description1).NotEmpty().WithMessage("Açıklama alanını boş bırakamazsınız..!");
            RuleFor(x=>x.Description1).MinimumLength(30).WithMessage("En az 30 karakter açıklama olmalıdır!");
            RuleFor(x=>x.Description1).MaximumLength(1500).WithMessage("En fazla 1500 karakter açıklama olmalıdır!");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
        }
    }
}
