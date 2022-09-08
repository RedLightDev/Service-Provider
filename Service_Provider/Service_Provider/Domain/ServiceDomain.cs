using AutoMapper;
using Service_Provider.Domain.Contracts;
using Service_Provider.Domain.Models;
using Service_Provider.Infrastructure.Entity;
using Service_Provider.Infrastructure.Repository.Contracts;

namespace Service_Provider.Domain;

public class ServiceDomain : IServiceDomain
{
    IServiceRepository repositroy;
    IMapper mapper;
    public ServiceDomain(IServiceRepository serviceRepository, IMapper mapper)
    {
        this.repositroy = serviceRepository;
        this.mapper = mapper;
    }
    public ServiceDTO AddService(ServiceDTO serviceDTO)
    {
        var service = repositroy.InsertVal(new Service(serviceDTO.Name, serviceDTO.Price));
        return new ServiceDTO(service.Id,service.Name,service.Price);
    }

    public IEnumerable<ServiceDTO> GetAllServices()
    {
        var dbList = repositroy.GetAll();

        return mapper.Map<IEnumerable<ServiceDTO>>(dbList);
    }
}

