﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoApp
{
    public partial class FormCategoriaAgregar : Form
    {
        Categoria categoria = null;
        public FormCategoriaAgregar()
        {
            InitializeComponent();
        }
        public FormCategoriaAgregar(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            Text = "Modificar Categoria";
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria obj = new Categoria();
            List<Categoria> listaC = new List<Categoria>();
            ServicioCategoria servicioCategoria = new ServicioCategoria();
            try
            {

                listaC = servicioCategoria.ListarCategorias();
                if (txtElementoCategoria.Text == "")
                {
                    MessageBox.Show("Agregar una Categoria por favor!!");
                    return;
                }


                if (categoria == null)
                {
                    obj.Descripcion = txtElementoCategoria.Text;
                    if (!listaC.Any(m => m.Descripcion.Equals(obj.Descripcion, StringComparison.OrdinalIgnoreCase)))
                    {
                        servicioCategoria.AgregarCategoria(obj);
                        MessageBox.Show("Registro Exitoso!");

                        Close();
                    }
                    else {
                        MessageBox.Show("Esa Categoria ya existe");
                    }

                }
                else
                {
                    categoria.Descripcion=txtElementoCategoria.Text;
                    servicioCategoria.ModificarCategoria(categoria);
                    MessageBox.Show("Modificación exitosa");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            this.Close();
        }

        private void txtRegArticulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtElementoCategoria_TextChanged(object sender, EventArgs e)
        {

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

        private void FormCategoriaAgregar_Load(object sender, EventArgs e)
        {
            try
            {
                if (categoria != null)
                {
                    txtElementoCategoria.Text = categoria.Descripcion;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
