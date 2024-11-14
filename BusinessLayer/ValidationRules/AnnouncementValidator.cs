using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karakter içermelidir.");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Başlık 20 karakteri geçemez.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş geçilemez.");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("En az 20 karakter içermelidir.");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("500 karakteri geçemezsiniz.");
        }
    }
}