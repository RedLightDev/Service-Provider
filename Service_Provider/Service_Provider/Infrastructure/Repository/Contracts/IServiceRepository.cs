using Microsoft.EntityFrameworkCore.ChangeTracking;
using Service_Provider.Infrastructure.Entity;
using Service_Provider.Infrastructure.Repository.Common;

namespace Service_Provider.Infrastructure.Repository.Contracts;

public interface IServiceRepository
{
    public IEnumerable<Service> GetAll();
    public void Insert(Service entity);
    public Service InsertVal(Service entity);
}

