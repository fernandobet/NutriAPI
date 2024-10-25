﻿using MediatR;

namespace Nutri.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommand:IRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public short Edad { get; set; } = 0;
        public short Estatura { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
    }
}
