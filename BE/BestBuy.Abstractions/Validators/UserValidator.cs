using BestBuy.Abstractions.Models;
using BestBuy.Abstractions.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BestBuy.Abstractions.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(IStringLocalizer<BestBuyResources> localizer)
        {
            RuleFor(m => m.CreatedOn).NotEmpty().WithMessage(localizer[nameof(BestBuyResources.CreatedOnIsRequired)]);
            RuleFor(m => m.UpdatedOn).NotEmpty().WithMessage(localizer[nameof(BestBuyResources.UpdatedOnIsRequired)]);
            RuleFor(m => m.IsDeleted).NotNull().WithMessage(localizer[nameof(BestBuyResources.IsDeletedIsRequired)]);

            RuleFor(m => m.Password).NotEmpty().WithMessage(localizer[nameof(BestBuyResources.PasswordRequired)]);
            RuleFor(m => m.Password).MaximumLength(50).WithMessage(localizer[nameof(BestBuyResources.PasswordMaxLenght)]);

            RuleFor(m => m.Username).NotEmpty().WithMessage(localizer[nameof(BestBuyResources.UsernameRequired)]);
            RuleFor(m => m.Username).MaximumLength(35).WithMessage(localizer[nameof(BestBuyResources.UsernameMaxLenght)]);
        }
    }
}
