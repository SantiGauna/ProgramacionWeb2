using System;
using System.Collections.Generic;
using Clases;

namespace BLL
{
    public class PedidoBLL
    {


        private static readonly List<Pedido> pedidos = new()
        {
           new Pedido(1, 1, 1, DateTime.Now, 2),
           new Pedido(2, 2, 2, DateTime.Now, 1),
           new Pedido(3, 3, 3, DateTime.Now, 3),
        };

        public List<Pedido> ObtenerTodosLosPedidos()
        {
            return pedidos;
        }

        public List<Pedido> ObtenerPedidoPorId(int id)
        {
            return pedidos.FindAll(p => p.Id == id);
        }

        public void AgregarPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
        }

        public void ActualizarCantidad(int id, int nuevaCantidad)
        {
            Pedido pedido = pedidos.Find(p => p.Id == id);
            if (pedido != null)
            {
                pedido.Cantidad = nuevaCantidad;
            }
        }

        public bool EliminarPedido(int id)
        {
            Pedido pedido = pedidos.Find(p => p.Id == id);
            if (pedido != null)
            {
                pedidos.Remove(pedido);
                return true;
            }
            return false;
        }



    }


}