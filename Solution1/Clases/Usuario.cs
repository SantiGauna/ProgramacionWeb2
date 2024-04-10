using System;

namespace Clases
{
    public class Usuario
    {
        public int Id { get; set; }
        public DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }



        public Usuario(int id, DateTime nacimiento, int edad, string nombre, string apellido)
        {

            Nacimiento = nacimiento;
            Edad = edad;
            Nombre = nombre;
            Apellido = apellido;
            Id = id;

        }

    }


}
