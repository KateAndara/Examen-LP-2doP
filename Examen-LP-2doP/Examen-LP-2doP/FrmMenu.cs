using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen_LP_2doP
{
    public partial class FrmMenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        FrmProducto frmProductos = null;
        FrmPedido frmPedido = null;
        private void ProductostoolStripButton_Click(object sender, EventArgs e)
        {
            if(frmProductos == null)
            {
                frmProductos = new FrmProducto();
                frmProductos.MdiParent = this;
                frmProductos.Show();
            }
            else
            {
                frmProductos.Activate();
            }

        }

        private void PedidostoolStripButton_Click(object sender, EventArgs e)
        {
            if (frmPedido == null)
            {
                frmPedido = new FrmPedido();
                frmPedido.MdiParent = this;
                frmPedido.Show();
            }
            else
            {
                frmPedido.Activate();
            }
        }
    }
}
