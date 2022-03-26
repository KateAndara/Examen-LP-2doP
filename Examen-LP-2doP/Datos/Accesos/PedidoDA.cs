using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Accesos
{
    public class PedidoDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=examen; Uid=root; Pwd=LenguajeDeProgra3;";

        MySqlConnection conn;
        MySqlCommand cmd;
        public int InsertarPedido(Pedido pedido)
        {
           
            int IdPedido = 0;
            try
            {
                string sql = "INSERT INTO pedido (NombreCliente, Descripcion, Cantidad, Precio, Total, Fecha) VALUES (@NombreCliente, @Descripcion, @SubTotal, @Cantidad, @Precio, @Total, @Fecha); select last_insert_id();";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NombreCliente", pedido.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", pedido.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", pedido.CantidadPedido);
                cmd.Parameters.AddWithValue("@Precio", pedido.Precio);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                IdPedido = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
            }
            return IdPedido;
        }
        public bool InsertarDetalle(Pedido pedido)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO pedido (IdPedido, NombreCliente, Descripcion, Cantidad, Precio, Total, Fecha) VALUES (@IdPedido, @NombreCliente, @Descripcion, @Cantidad, @Precio, @Total, @Fecha);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdPedido", pedido.IdPedido);
                cmd.Parameters.AddWithValue("@NombreCliente", pedido.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", pedido.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", pedido.CantidadPedido);
                cmd.Parameters.AddWithValue("@Precio", pedido.Precio);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                cmd.ExecuteNonQuery();

                inserto = true;
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return inserto;
        }
        public DataTable ListarProductos()
        {
            DataTable lista = new DataTable();

            try
            {
                string sql = "SELECT * FROM pedido;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                lista.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return lista;
        }
    }
}
