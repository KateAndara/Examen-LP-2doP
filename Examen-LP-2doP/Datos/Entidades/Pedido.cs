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
        public DateTime Fecha { get; set; }
        public int Edad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Total { get; set; }

        public Pedido()
        {
        }

        public Pedido(int idPedido, string nombre, DateTime fecha, int edad, decimal precio, decimal total)
        {
            IdPedido = idPedido;
            Nombre = nombre;
            Fecha = fecha;
            Edad = edad;
            Precio = precio;
            Total = total;
        }
    }
}
