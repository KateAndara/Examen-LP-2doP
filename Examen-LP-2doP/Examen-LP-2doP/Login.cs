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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            UsuarioDA usuarioDA = new UsuarioDA();
            Usuario usuario = new Usuario();
            usuario = usuarioDA.Login(UsuariotextBox.Text, ClavetextBox.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos erroneos");
                return;
            }
            else if (!usuario.EstaActivo)
            {
                MessageBox.Show("Usuario Inactivo");
                return;
            }
            FrmProducto frmproducto = new FrmProducto();
            frmproducto.Show();
        }
    }
}
