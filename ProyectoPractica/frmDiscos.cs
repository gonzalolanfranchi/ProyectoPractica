﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenTapa);  
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
    }
}