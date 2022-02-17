using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı Kısmı Boş Geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adres Kısmı Boş Geçilemez.");
            RuleFor(x=>x.WriterPassword).NotEmpty().WithMessage("Şifre Kısmı Boş Geçilemez.");
            RuleFor(x => x.WriterPassword).Equal(x => x.WriterConfirmPassword).WithMessage("Şifreler Uyuşmuyor");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
        }

    }
}
