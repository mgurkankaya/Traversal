using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator:AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş geçilemez.");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("İçerik 20 karakterden az olamaz.");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("İçerik 500 karakterden fazla olamaz.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık 3 karakterden az olamaz.");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("İçerik 20 karakterden fazla olamaz.");
        }
    }
}
