
using AutoMapper;
using Nutri.Application.Features.Patients.Commands.DeletePatient;
using Nutri.Application.Features.Patients.Commands.ModifyPatient;
using Nutri.Application.Features.Patients.Commands.SavePatient;
using Nutri.Application.Features.Users.Commands.AddUser;
using Nutri.Application.Features.Users.Queries.Login;
using Nutri.Domain.Models;

namespace Nutri.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginQuery, Usuario>();
            CreateMap<AddUserCommand, Usuario>();
            CreateMap<DeletePatientCommand, Paciente>();
            CreateMap<ModifyPatientCommand, Paciente>();
            CreateMap<SavePatientCommand, Paciente>();
        }
    }
}
