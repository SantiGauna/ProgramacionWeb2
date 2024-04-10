namespace Clases
{
    public class Hamburguesa
    {
        public int IdHamburguesa { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Hamburguesa(int idHamburguesa, string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
            IdHamburguesa = idHamburguesa;
        }
    }
}
