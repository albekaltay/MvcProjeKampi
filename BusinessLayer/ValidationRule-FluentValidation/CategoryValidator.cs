using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule_FluentValidation
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açılamasını Boş Geçemezsiniz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Ad en az 3 karakter olmalı.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Ad en fazla 20 karakter olmalı.");

        }
    }
}
