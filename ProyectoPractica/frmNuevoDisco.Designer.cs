namespace ProyectoPractica
{
    partial class frmNuevoDisco
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFechaLanzamiento = new System.Windows.Forms.Label();
            this.lblCantidadCanciones = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblFormato = new System.Windows.Forms.Label();
            this.tbxTitulo = new System.Windows.Forms.TextBox();
            this.dtpFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.nudCantidadCanciones = new System.Windows.Forms.NumericUpDown();
            this.tbxUrlImagen = new System.Windows.Forms.TextBox();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.cboFormato = new System.Windows.Forms.ComboBox();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadCanciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(114, 52);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(36, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo:";
            // 
            // lblFechaLanzamiento
            // 
            this.lblFechaLanzamiento.AutoSize = true;
            this.lblFechaLanzamiento.Location = new System.Drawing.Point(32, 78);
            this.lblFechaLanzamiento.Name = "lblFechaLanzamiento";
            this.lblFechaLanzamiento.Size = new System.Drawing.Size(118, 13);
            this.lblFechaLanzamiento.TabIndex = 1;
            this.lblFechaLanzamiento.Text = "Fecha de Lanzamiento:";
            // 
            // lblCantidadCanciones
            // 
            this.lblCantidadCanciones.AutoSize = true;
            this.lblCantidadCanciones.Location = new System.Drawing.Point(30, 106);
            this.lblCantidadCanciones.Name = "lblCantidadCanciones";
            this.lblCantidadCanciones.Size = new System.Drawing.Size(120, 13);
            this.lblCantidadCanciones.TabIndex = 2;
            this.lblCantidadCanciones.Text = "Cantidad de Canciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Url Imagen:";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(105, 161);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(45, 13);
            this.lblGenero.TabIndex = 4;
            this.lblGenero.Text = "Genero:";
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(102, 189);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(48, 13);
            this.lblFormato.TabIndex = 5;
            this.lblFormato.Text = "Formato:";
            // 
            // tbxTitulo
            // 
            this.tbxTitulo.Location = new System.Drawing.Point(156, 49);
            this.tbxTitulo.Name = "tbxTitulo";
            this.tbxTitulo.Size = new System.Drawing.Size(200, 20);
            this.tbxTitulo.TabIndex = 6;
            // 
            // dtpFechaLanzamiento
            // 
            this.dtpFechaLanzamiento.Location = new System.Drawing.Point(156, 75);
            this.dtpFechaLanzamiento.Name = "dtpFechaLanzamiento";
            this.dtpFechaLanzamiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaLanzamiento.TabIndex = 7;
            // 
            // nudCantidadCanciones
            // 
            this.nudCantidadCanciones.Location = new System.Drawing.Point(156, 103);
            this.nudCantidadCanciones.Name = "nudCantidadCanciones";
            this.nudCantidadCanciones.Size = new System.Drawing.Size(200, 20);
            this.nudCantidadCanciones.TabIndex = 8;
            // 
            // tbxUrlImagen
            // 
            this.tbxUrlImagen.Location = new System.Drawing.Point(156, 130);
            this.tbxUrlImagen.Name = "tbxUrlImagen";
            this.tbxUrlImagen.Size = new System.Drawing.Size(200, 20);
            this.tbxUrlImagen.TabIndex = 9;
            this.tbxUrlImagen.Leave += new System.EventHandler(this.tbxUrlImagen_Leave);
            // 
            // cboGenero
            // 
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(156, 157);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(200, 21);
            this.cboGenero.TabIndex = 10;
            // 
            // cboFormato
            // 
            this.cboFormato.FormattingEnabled = true;
            this.cboFormato.Location = new System.Drawing.Point(156, 185);
            this.cboFormato.Name = "cboFormato";
            this.cboFormato.Size = new System.Drawing.Size(200, 21);
            this.cboFormato.TabIndex = 11;
            // 
            // pbxImagen
            // 
            this.pbxImagen.Location = new System.Drawing.Point(362, 49);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(231, 231);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabIndex = 12;
            this.pbxImagen.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(174, 234);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(264, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmNuevoDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 301);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pbxImagen);
            this.Controls.Add(this.cboFormato);
            this.Controls.Add(this.cboGenero);
            this.Controls.Add(this.tbxUrlImagen);
            this.Controls.Add(this.nudCantidadCanciones);
            this.Controls.Add(this.dtpFechaLanzamiento);
            this.Controls.Add(this.tbxTitulo);
            this.Controls.Add(this.lblFormato);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCantidadCanciones);
            this.Controls.Add(this.lblFechaLanzamiento);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmNuevoDisco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevoDisco";
            this.Load += new System.EventHandler(this.frmNuevoDisco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadCanciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaLanzamiento;
        private System.Windows.Forms.Label lblCantidadCanciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.TextBox tbxTitulo;
        private System.Windows.Forms.DateTimePicker dtpFechaLanzamiento;
        private System.Windows.Forms.NumericUpDown nudCantidadCanciones;
        private System.Windows.Forms.TextBox tbxUrlImagen;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.ComboBox cboFormato;
        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}