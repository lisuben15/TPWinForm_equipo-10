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
    public partial class FormMarcaAgregar : Form
    {
        Marca marca = null;
        public FormMarcaAgregar()
        {
            InitializeComponent();
        }
        public FormMarcaAgregar(Marca marca)
        {
             InitializeComponent();
            this.marca = marca;
            Text = "Modificar Marca";

        }

        private void FormMarcarAgregar_Load(object sender, EventArgs e)
        {
            try
            {
                if(marca != null)
                {
                    txtElementoMarca.Text = marca.Descripcion; 
                }
                    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca obj = new Marca();
            ServicioMarca servicioMarca = new ServicioMarca();
            try
            {
               if(marca == null)
                {
                    obj.Descripcion = txtElementoMarca.Text;
                    servicioMarca.AgregarMarca(obj);
                    MessageBox.Show("Registro Exitoso!");
                    
                }
                else
                {
                   
                    marca.Descripcion= txtElementoMarca.Text;
                    servicioMarca.ModificarMarca(marca);
                    MessageBox.Show(" Modificacion exitosa");

                }
                this.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
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


    }

}
            

