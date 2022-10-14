
using AutoMapper;
using Nutri.Application.Features.Food.Commands.ModifyFood;
using Nutri.Application.Features.Food.Commands.SaveFood;
using Nutri.Application.Features.Patients.Commands.DeletePatient;
using Nutri.Application.Features.Patients.Commands.ModifyPatient;
using Nutri.Application.Features.Patients.Commands.SavePatient;
using Nutri.Application.Features.Suplements.Commands.AddCustomList;
using Nutri.Application.Features.Suplements.Commands.AddSuplement;
using Nutri.Application.Features.Suplements.Commands.EditCustomSuplementList;
using Nutri.Application.Features.Suplements.Commands.EditSuplement;
using Nutri.Application.Features.Users.Commands.AddUser;
using Nutri.Application.Features.Users.Queries.Login;
using Nutri.Domain.DTOS;
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
            CreateMap<AddCustomListCommand, AddCustomListDTO>();
            CreateMap<EditCustomSuplementListCommand, AddCustomListDTO>();
            CreateMap<SaveFoodCommand, Alimento>();
            CreateMap<ModifyFoodCommand, Alimento>();
            CreateMap<AddSuplementCommand, Suplemento>();
            CreateMap<EditSuplementCommand, Suplemento>();


        }
    }
}
