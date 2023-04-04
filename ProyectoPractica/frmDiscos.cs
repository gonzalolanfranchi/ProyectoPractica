using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using services;

namespace ProyectoPractica
{
    public partial class frmDiscos : Form
    {
        private List<Disco> listaDisco;
        public frmDiscos()
        {
            InitializeComponent();
        }



        private void frmDiscos_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void ocultarColumnas()
        {
            dgvDiscos.Columns["IdDisco"].Visible = false;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDiscos.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagenTapa);  
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDisco.Load(imagen);

            }
            catch (Exception ex)
            {

                pbxDisco.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoDisco alta = new frmNuevoDisco();
            alta.ShowDialog();
            cargar();

        }

        private void cargar()
        {
        DiscoService service = new DiscoService();
            try
            {
                listaDisco = service.listar();
                dgvDiscos.DataSource = listaDisco;
                ocultarColumnas();
                cargarImagen(listaDisco[0].UrlImagenTapa);           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

            frmNuevoDisco modificar = new frmNuevoDisco(seleccionado);
            modificar.ShowDialog();
            cargar();

        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool logico = false)
        {
            DiscoService service = new DiscoService();
            Disco seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("Esta seguro que desea eliminar el disco?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

                    if (logico)
                        service.eliminarLogico(seleccionado.IdDisco);
                    else
                        service.eliminar(seleccionado.IdDisco);

                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar(txtFiltro.Text);
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            filtrar("");
        }

        private void filtrar(string filtro)
        {
            List<Disco> listaFiltrada;
            

            if(filtro != "")
            {
                listaFiltrada = listaDisco.FindAll(x => x.Titulo.ToLower().Contains(filtro.ToLower()) || x.Genero.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaDisco;
            }

            dgvDiscos.DataSource = null;
            dgvDiscos.DataSource = listaFiltrada;
            ocultarColumnas();

        }
    }
}
