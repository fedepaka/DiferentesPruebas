using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormPruebaServidorLicencias
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opedo.Licensing.Client.Example.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Opedo.Licensing.Client.Ejemplo2.Prueba2();
;
        }

        private async void button3_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var licencia = await Opedo.Licensing.Client.Ejemplo2.Prueba3(txtEmail.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtTelefono.Text.Trim());

                string datosLicencia = string.Format("Acceso a todos los módulos: {0}, Fecha Expiración: {1}, Nº de módulos: {2}"
                    , licencia.AllowAnyModule ? "SI" : "NO", licencia.ExpiryDate, licencia.Modules.Count);

                MessageBox.Show(datosLicencia);
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
