using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("E-Mail alanı boş geçilemez.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre doğrulama alanı boş geçilemez.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.Username).MaximumLength(12).WithMessage("Kullanıcı adı en fazla 12 karakterden oluşmalıdır.");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler birbiriyle uyuşmadı.");
        }
    }
}