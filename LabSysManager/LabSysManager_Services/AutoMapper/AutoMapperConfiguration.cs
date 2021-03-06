﻿using AutoMapper;

namespace LabSysManager_Services.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps => 
            {
                ps.AddProfile(new DomainToViewModelMappingProfile());
            });
        }
    }
}
