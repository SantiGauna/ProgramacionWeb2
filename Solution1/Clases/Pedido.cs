using System;

namespace Clases

{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int HamburguesaId { get; set; }
        public DateTime FechaPedido { get; set; }
        public int Cantidad { get; set; }


        public Pedido(int id, int usuarioId, int hamburguesaId, DateTime fechaPedido, int cantidad)
        {
            Id = id;
            UsuarioId = usuarioId;
            HamburguesaId = hamburguesaId;
            FechaPedido = fechaPedido;
            Cantidad = cantidad;
        }

    }

}
