using AdvertisementManagement.Web.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementManagement.Web.Infrastructure.Validators
{
    public class CreateAdvertisementValidator : AbstractValidator<CreateAdvertisementRequest>
    {
        public CreateAdvertisementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title con not be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Attach image.");
            RuleFor(x => x.PhoneNumber).Length(9).WithMessage("Phone number must contain 9 digits.")
                .Must(x => x.StartsWith("5")).WithMessage("Phone number must start with the digit \"5\".");
        }
    }
}
