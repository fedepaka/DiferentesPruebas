using Newtonsoft.Json;
using System;
using System.Text;
using System.Windows.Forms;

namespace Encriptar_TarjetaDebito
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            var fp = new FormaPago();

            fp.CodigoSeguridad = txtCodSeguridad.Text.Trim();
            fp.DniTitular = txtDni.Text.Trim();
            fp.Importe = txtImporte.Text.Trim();
            fp.TelefonoTitular = txtTelefono.Text.Trim();
            fp.UltimosCuatroDigitos = txtUltimos4Digitos.Text.Trim();
            fp.TrackTarjeta = txtTrack.Text.Trim();
            fp.CodFormaPago = 2;

            var keyValue = string.Format("{0}{1}", txtIdPuesto.Text.Trim(), txtClaveEncriptacion.Text.Trim());


            txtStringEncriptado.Text = Encriptar(JsonConvert.SerializeObject(fp), keyValue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public string Encriptar(string _cadenaAEncriptar, string key = "")
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(string.Format("{0}{1}", _cadenaAEncriptar, key));
            result = Convert.ToBase64String(encryted);
            return result;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodSeguridad.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtImporte.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtUltimos4Digitos.Text = string.Empty;
            txtTrack.Text = string.Empty;
            txtStringEncriptado.Text = string.Empty;
            txtClaveEncriptacion.Text = string.Empty;
            txtIdPuesto.Text = string.Empty;
        }
    }
}
