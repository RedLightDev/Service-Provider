using Service_Provider.Infrastructure.Entity;
using Service_Provider.Infrastructure.Repository.Common;
using Service_Provider.Infrastructure.Repository.Contracts;

namespace Service_Provider.Infrastructure.Repository;

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(ServiceDBContext context) : base(context)
    {
    }
}

