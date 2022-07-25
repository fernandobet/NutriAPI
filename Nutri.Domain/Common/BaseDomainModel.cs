namespace Nutri.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
