using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiferentesPruebas
{
    public partial class Form1 : Form
    {
        string filename;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    lblFilename.Text = filename;
                    pictureBox1.Image = Image.FromFile(filename);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            using (Entities db = new Entities())
            {
                //USERS user = new USERS();
                //user.ADDRESS = "address " + DateTime.Now.Ticks;
                //user.CREATED_USER_ID 
                //db.USERS.Add

                var userLogued = from u in db.USER where u.USER_NAME == "admin" && u.ID == 1 select u;
                var user = userLogued.FirstOrDefault();

                user.PHOTO_FILENAME = Path.GetFileName(filename);
                user.PHOTO_IMAGE = ConvertImageToImage(pictureBox1.Image);
                await db.SaveChangesAsync();

                MessageBox.Show("la imagen se guardó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private byte[] ConvertImageToImage(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {
                //var prueba = new PRUEBA();
                //prueba.NOMBRE = "prueba";
                //db.PRUEBA.Add(prueba);
                //db.SaveChanges();

                var ROL = new ROL();
                ROL.NAME = "ADMIN";
                db.ROL.Add(ROL);
                db.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using (Entities db = new Entities())
            //{
            //    //var prueba = new PRUEBA();
            //    //prueba.NOMBRE = "prueba";
            //    //db.PRUEBA.Add(prueba);
            //    //db.SaveChanges();

            //    var rol = (from u in db.ROL where u.NAME == "ADMIN" select u).FirstOrDefault();
            //    rol.DELETED = 1;
            //    db.SaveChanges();
            //}

            try
            {
                var numero = "1445,41";

                CultureInfo esCulture = new CultureInfo("es-AR");
                NumberFormatInfo dbNumberFormat = esCulture.NumberFormat;
                dbNumberFormat.CurrencyDecimalSeparator = ".";
                var style = NumberStyles.AllowDecimalPoint;

                var resultado = decimal.Parse(numero, style, dbNumberFormat);
                MessageBox.Show(resultado.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            
        }
    }
}
