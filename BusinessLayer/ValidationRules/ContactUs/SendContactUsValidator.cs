using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz.");
            RuleFor(x => x.Mail).MinimumLength(6).WithMessage("Mail alanı 6 karakterden az olamaz.");
        
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş bırakılamaz.");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu başlığı 5 karakterden az olamaz.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu başlığı 50 karakterden fazla olamaz.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz.");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.");
        }
    }
}
