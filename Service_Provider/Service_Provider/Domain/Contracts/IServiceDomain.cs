using Service_Provider.Domain.Models;

namespace Service_Provider.Domain.Contracts;
public interface IServiceDomain
{
    public IEnumerable<ServiceDTO> GetAllServices();

    public ServiceDTO AddService(ServiceDTO serviceDTO);
}

