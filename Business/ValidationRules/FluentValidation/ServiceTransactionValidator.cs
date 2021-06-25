using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ServiceTransactionValidator : AbstractValidator<ServiceTransaction>
    {
        public ServiceTransactionValidator()
        {
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}
