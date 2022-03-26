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
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }
        PedidoDA pedidoDA = new PedidoDA();
        string operacion = string.Empty;
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido.Nombre = NombretextBox.Text;
            pedido.Descripcion = DescripciontextBox.Text;
            pedido.CantidadPedido = Convert.ToInt32(CantidadtextBox.Text);
            pedido.Precio = Convert.ToDecimal(PreciotextBox.Text);
            pedido.Total = Convert.ToDecimal(TotaltextBox.Text);
            pedido.Fecha = FechadateTimePicker.Value;

            int IdPedido = 0;
            IdPedido = pedidoDA.InsertarPedido(pedido);

         
        }
        private void ListarProductos()
        {
            PedidodataGridView.DataSource = pedidoDA.ListarProductos();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void TotaltextBox_TextChanged(object sender, EventArgs e)
        {
         

            

        }
    }
}
