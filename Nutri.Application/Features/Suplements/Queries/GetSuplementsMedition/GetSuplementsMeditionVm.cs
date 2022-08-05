namespace Nutri.Application.Features.Suplements.Queries.GetSuplementsMedition
{
    public class GetSuplementsMeditionVm
    {
        public int IdSuplemento { get; set; }
        public int IdMedicion { get; set; }
        public string Suplemento { get; set; } = string.Empty;
        public string Medicion { get; set; } = String.Empty;
        /// <summary>
        /// Propiedades que capturaremos en la UI
        /// </summary>
        public string TextoAdicional { get; set; } = String.Empty;
        public short Medidas { get; set; }
    }
}
