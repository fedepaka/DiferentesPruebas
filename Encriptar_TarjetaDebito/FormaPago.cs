namespace Encriptar_TarjetaDebito
{
    public class FormaPago
    {
        public int CodFormaPago { get; set; }
        public string Descripcion { get; set; }
        public string Datos { get; set; }
        public string NombreTitular { get; set; }
        public string DniTitular { get; set; }
        public string TelefonoTitular { get; set; }
        public string UltimosCuatroDigitos { get; set; }
        public string CodigoSeguridad { get; set; }
        public string TrackTarjeta { get; set; }


        // 'rapipago
        public string CodFP { get; set; }
        public string DescFP { get; set; }
        public string Importe { get; set; }
    }
}
