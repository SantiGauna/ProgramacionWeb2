using Clases;

namespace BLL
{
    public class HamburguesaBLL
    {



        private static readonly List<Hamburguesa> hamburguesas = new()
        {
            new Hamburguesa(3, "Cheddar", 3599),
            new Hamburguesa(4, "Vegetariana", 4699),
            new Hamburguesa(1, "Doble bacon", 5399),
        };

        public List<Hamburguesa> ObtenerTodasLasHamburguesas()
        {
            return hamburguesas;
        }

        public Hamburguesa ObtenerHamburguesaPorId(int id)
        {
            return hamburguesas.Find(h => h.IdHamburguesa == id);
        }

        public void AgregarHamburguesa(Hamburguesa hamburguesa)
        {
            hamburguesas.Add(hamburguesa);
        }

        public void ActualizarHamburguesa(Hamburguesa hamburguesa)
        {
            int index = hamburguesas.FindIndex(h => h.IdHamburguesa == hamburguesa.IdHamburguesa);
            if (index != -1)
            {
                hamburguesas[index] = hamburguesa;
            }
        }

        public bool EliminarHamburguesa(int id)
        {
            Hamburguesa hamburguesa = hamburguesas.Find(h => h.IdHamburguesa == id);
            if (hamburguesa != null)
            {
                hamburguesas.Remove(hamburguesa);
                return true;
            }
            return false;
        }


    }

}