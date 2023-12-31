﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoApp
{
    public partial class Form4Categorias : Form
    {
        ServicioCategoria servicioCategoria;
        public Form4Categorias()
        {
            InitializeComponent();
        }

        private void Form4Categorias_Load(object sender, EventArgs e)
        {
            servicioCategoria = new ServicioCategoria();
            List<Categoria> lista = servicioCategoria.ListarCategorias();

            dgvCategorias.DataSource = lista;
            dgvCategorias.Columns["Id"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormCategoriaAgregar formCategoriaAgregar = new FormCategoriaAgregar();
            formCategoriaAgregar.ShowDialog();
            Form4Categorias_Load(sender, e);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            FormCategoriaAgregar formCategoriaModificar = new FormCategoriaAgregar(seleccionado);
            formCategoriaModificar.ShowDialog();
            Form4Categorias_Load(sender, e);                             
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ServicioCategoria servicioCategoria = new ServicioCategoria();
            Categoria seleccionado;
            try
            {
                DialogResult resultado = MessageBox.Show(" ¿Seguro desea eliminar ? ", " Eliminado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    servicioCategoria.EliminarCategoria(seleccionado.Id);
                    Form4Categorias_Load(sender, e);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<Categoria> listaFiltrada;
            string filtro = textBox1.Text;

            servicioCategoria = new ServicioCategoria();
            List<Categoria> lista = servicioCategoria.ListarCategorias();

            if (filtro != "")
            {
                listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = lista;
            }

            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = listaFiltrada;
        }



        //BUTTON ANIMATIONS
        private void btnModificar_MouseEnter(object sender, EventArgs e)
        {
            btnModificar.Width += 5;
            btnModificar.Height += 5;
        }
        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            btnModificar.Width -= 5;
            btnModificar.Height -= 5;
        }
        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            btnAgregar.Width += 5;
            btnAgregar.Height += 5;
        }
        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.Width -= 5;
            btnAgregar.Height -= 5;
        }
        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            btnEliminar.Width += 5;
            btnEliminar.Height += 5;
        }
        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.Width -= 5;
            btnEliminar.Height -= 5;
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
