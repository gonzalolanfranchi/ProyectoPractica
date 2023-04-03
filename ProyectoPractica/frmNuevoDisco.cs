using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using services;

namespace ProyectoPractica
{
    public partial class frmNuevoDisco : Form
    {
        private Disco disco = null;

        public frmNuevoDisco()
        {
            InitializeComponent();
        }

        public frmNuevoDisco(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
            Text = "Modificar Disco";
        }






        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DiscoService negocio = new DiscoService();
            try
            {
                if(disco == null)
                    disco = new Disco();

                disco.Titulo = tbxTitulo.Text;
                disco.FechaLanzamiento = dtpFechaLanzamiento.Value;
                disco.CantidadCanciones = (int)nudCantidadCanciones.Value;
                disco.UrlImagenTapa = tbxUrlImagen.Text;
                disco.Genero = (Estilo)cboGenero.SelectedItem;
                disco.Formato = (TipoEdicion)cboFormato.SelectedItem;

                if (disco.IdDisco != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente!");
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente!");
                }

                

                Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmNuevoDisco_Load(object sender, EventArgs e)
        {
            GeneroService generoService = new GeneroService();
            FormatoService formatoService = new FormatoService();
            try
            {
                cboGenero.DataSource = generoService.listar();
                cboGenero.ValueMember = "IdEstilo";
                cboGenero.DisplayMember = "Descripcion";
                cboFormato.DataSource = formatoService.listar();
                cboFormato.ValueMember = "IdTipoEdicion";
                cboFormato.DisplayMember = "Descripcion";

                if (disco != null)
                {
                    tbxTitulo.Text = disco.Titulo;
                    dtpFechaLanzamiento.Value = disco.FechaLanzamiento;
                    nudCantidadCanciones.Value = (int)disco.CantidadCanciones;
                    tbxUrlImagen.Text = disco.UrlImagenTapa;
                    cargarImagen(disco.UrlImagenTapa);
                    cboGenero.SelectedValue = disco.Genero.IdEstilo;
                    cboFormato.SelectedValue = disco.Formato.IdTipoEdicion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagen.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }

        private void tbxUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(tbxUrlImagen.Text);
        }
    }
}
