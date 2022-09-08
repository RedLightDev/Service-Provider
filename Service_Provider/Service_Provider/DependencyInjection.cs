using FluentValidation;
using Service_Provider.Controllers.Models.Requests;
using Service_Provider.Controllers.Validation;

namespace Service_Provider;

public class DependencyInjection
{
    public static void Inject(IServiceCollection services)
    {
        services.Scan(scan => scan
        .FromCallingAssembly()
        .AddClasses()
        .AsMatchingInterface());
        services.AddScoped<IValidator<ServiceRequest>, ServiceRequestValidator>();
    }
}

