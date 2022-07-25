﻿using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class Paciente:BaseDomainModel
    {
        public string Nombre { get; set; }=string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public short Edad { get; set; } = 0;
        public short Estatura { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;

    }
}