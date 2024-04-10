using Clases;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {


        private static readonly List<Usuario> usuarios = new()
        {
            new Usuario(34, DateTime.Parse("1990-01-01"), 31, "Roberto", "Perez"),
            new Usuario(12, DateTime.Parse("1985-05-05"), 36, "Daniel", "Gomez"),
            new Usuario(4, DateTime.Parse("1980-10-10"), 41, "Jose", "Ramallo"),
        };

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return usuarios;
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return usuarios.Find(u => u.Id == id);
        }

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool EliminarUsuario(int id)
        {
            Usuario usuario = usuarios.Find(u => u.Id == id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
                return true;
            }
            return false;
        }


    }

}