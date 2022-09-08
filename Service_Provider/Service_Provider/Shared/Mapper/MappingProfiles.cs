using AutoMapper;
using Service_Provider.Domain.Models;
using Service_Provider.Infrastructure.Entity;

namespace Service_Provider.Infrastructure.Mapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ServiceDTO, Service>().ReverseMap();
            
        }
    }
}
