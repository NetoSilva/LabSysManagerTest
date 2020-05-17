using AutoMapper;
using LabSysManager_Domain.Models;
using LabSysManager_Services.ViewModels;

namespace LabSysManager_Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
