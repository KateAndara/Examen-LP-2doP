using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadPedido { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public Pedido()
        {
        }

        public Pedido(int idPedido, string nombre, string descripcion, int cantidadPedido, decimal precio, decimal total, DateTime fecha)
        {
            IdPedido = idPedido;
            Nombre = nombre;
            Descripcion = descripcion;
            CantidadPedido = cantidadPedido;
            Precio = precio;
            Total = total;
            Fecha = fecha;
        }
    }
}
