
using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class Usuario:BaseDomainModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
    }
}
