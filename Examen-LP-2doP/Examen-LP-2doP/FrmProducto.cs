using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_LP_2doP
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }
        string operacion = string.Empty;

        ProductoDA productoDA = new ProductoDA();
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }
        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            ExistenciaTextBox.Enabled = true;
            GuardarButton.Enabled = true;
            ModificarButton.Enabled = true;
            NuevoButton.Enabled = false;

        }
        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;
            GuardarButton.Enabled = false;
            ModificarButton.Enabled = false;
            NuevoButton.Enabled = true;

        }
        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            ExistenciaTextBox.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese el código");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionTextBox, "Ingrese una descripción");
                    DescripcionTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(PrecioTextBox.Text))
                {
                    errorProvider1.SetError(PrecioTextBox, "Ingrese un precio");
                    PrecioTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(ExistenciaTextBox.Text))
                {
                    errorProvider1.SetError(ExistenciaTextBox, "Ingrese una existencia");
                    ExistenciaTextBox.Focus();
                    return;
                }

                Producto producto = new Producto();
                producto.Codigo = CodigoTextBox.Text;
                producto.Descripcion = DescripcionTextBox.Text;
                producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);

                if (operacion == "Nuevo")
                {
                    bool inserto = productoDA.InsertarProducto(producto);

                    if (inserto)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        ListarProductos();
                        MessageBox.Show("Producto insertado");
                    }
                }
                else if (operacion == "Modificar")
                {
                    bool modifico = productoDA.ModificarProducto(producto);
                    if (modifico)
                    {
                        LimpiarControles();
                        DesabilitarControles();
                        ListarProductos();
                        MessageBox.Show("Producto Modificado");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void ListarProductos()
        {
            ProductosdataGridView.DataSource = productoDA.ListarProductos();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (ProductosdataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = ProductosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripcionTextBox.Text = ProductosdataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                PrecioTextBox.Text = ProductosdataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                ExistenciaTextBox.Text = ProductosdataGridView.CurrentRow.Cells["Existencia"].Value.ToString();

                HabilitarControles();
                CodigoTextBox.Focus();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto");
            }
        }
    }
}
