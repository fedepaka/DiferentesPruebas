namespace Encriptar_TarjetaDebito
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrack = new System.Windows.Forms.TextBox();
            this.txtCodSeguridad = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtUltimos4Digitos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEncriptar = new System.Windows.Forms.Button();
            this.txtStringEncriptado = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdPuesto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtClaveEncriptacion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "String de lector tarjeta";
            // 
            // txtTrack
            // 
            this.txtTrack.Location = new System.Drawing.Point(158, 33);
            this.txtTrack.Multiline = true;
            this.txtTrack.Name = "txtTrack";
            this.txtTrack.Size = new System.Drawing.Size(630, 59);
            this.txtTrack.TabIndex = 1;
            // 
            // txtCodSeguridad
            // 
            this.txtCodSeguridad.Location = new System.Drawing.Point(158, 99);
            this.txtCodSeguridad.Name = "txtCodSeguridad";
            this.txtCodSeguridad.Size = new System.Drawing.Size(100, 20);
            this.txtCodSeguridad.TabIndex = 2;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(158, 125);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 3;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(158, 151);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(100, 20);
            this.txtImporte.TabIndex = 4;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(158, 177);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // txtUltimos4Digitos
            // 
            this.txtUltimos4Digitos.Location = new System.Drawing.Point(158, 203);
            this.txtUltimos4Digitos.Name = "txtUltimos4Digitos";
            this.txtUltimos4Digitos.Size = new System.Drawing.Size(100, 20);
            this.txtUltimos4Digitos.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cod. Seguridad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dni";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Importe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Teléfono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Últimos 4 dígitos";
            // 
            // btnEncriptar
            // 
            this.btnEncriptar.Location = new System.Drawing.Point(158, 326);
            this.btnEncriptar.Name = "btnEncriptar";
            this.btnEncriptar.Size = new System.Drawing.Size(75, 23);
            this.btnEncriptar.TabIndex = 12;
            this.btnEncriptar.Text = "Encriptar";
            this.btnEncriptar.UseVisualStyleBackColor = true;
            this.btnEncriptar.Click += new System.EventHandler(this.btnEncriptar_Click);
            // 
            // txtStringEncriptado
            // 
            this.txtStringEncriptado.Location = new System.Drawing.Point(158, 355);
            this.txtStringEncriptado.Multiline = true;
            this.txtStringEncriptado.Name = "txtStringEncriptado";
            this.txtStringEncriptado.Size = new System.Drawing.Size(630, 149);
            this.txtStringEncriptado.TabIndex = 13;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(278, 326);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "IdPuesto";
            // 
            // txtIdPuesto
            // 
            this.txtIdPuesto.Location = new System.Drawing.Point(158, 262);
            this.txtIdPuesto.Name = "txtIdPuesto";
            this.txtIdPuesto.Size = new System.Drawing.Size(100, 20);
            this.txtIdPuesto.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Clave Encriptación";
            // 
            // txtClaveEncriptacion
            // 
            this.txtClaveEncriptacion.Location = new System.Drawing.Point(158, 288);
            this.txtClaveEncriptacion.Name = "txtClaveEncriptacion";
            this.txtClaveEncriptacion.Size = new System.Drawing.Size(100, 20);
            this.txtClaveEncriptacion.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 516);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtClaveEncriptacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIdPuesto);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtStringEncriptado);
            this.Controls.Add(this.btnEncriptar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUltimos4Digitos);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtCodSeguridad);
            this.Controls.Add(this.txtTrack);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrack;
        private System.Windows.Forms.TextBox txtCodSeguridad;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtUltimos4Digitos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEncriptar;
        private System.Windows.Forms.TextBox txtStringEncriptado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdPuesto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtClaveEncriptacion;
    }
}

