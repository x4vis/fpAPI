using System;
using AutoMapper;
using fpAPI.Access.DbCtx;
using fpAPI.DTO;

namespace fpAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Provider, IdProvider>();
            CreateMap<BaseProvider, Provider>();
        }
    }
}
