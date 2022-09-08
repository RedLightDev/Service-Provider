using FluentValidation;
using Service_Provider.Controllers.Models.Requests;

namespace Service_Provider.Controllers.Validation
{
    public class ServiceRequestValidator: AbstractValidator<ServiceRequest>
    {
        public ServiceRequestValidator()
        {
            RuleFor(x => x.name).NotEmpty().Length(3, 25);
            RuleFor(x => x.price).NotNull().GreaterThan(0);
        }
    }
}
