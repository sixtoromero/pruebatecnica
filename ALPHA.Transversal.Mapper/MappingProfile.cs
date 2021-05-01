using AutoMapper;
using ALPHA.Application.DTO;
using ALPHA.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALPHA.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuditLog, AuditLogDTO>().ReverseMap();
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Correspondence, CorrespondenceDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Rol, RolDTO>().ReverseMap();
        }
    }
}
