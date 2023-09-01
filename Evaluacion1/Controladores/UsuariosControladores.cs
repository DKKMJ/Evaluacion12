using Evaluacion1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evaluacion1.Controladores
{
    public class UsuariosControladores : Controlador
    {
        private List<Usuario> dgUsuarios = new List<Usuario>(); // Declarar e inicializar la lista

        public List<Usuario> ObtenerListaUsuarios()
        {
            return datos.Usuarios;
        }

        public void GuardarUsuario(Usuario usuario)
        {
            datos.Usuarios.Add(usuario);
        }

        public void EliminarUsuario(int index)
        {
            datos.Usuarios.RemoveAt(index);
        }
        public Usuario ObtenerUsuarioPorRut(string rut)
        {
            return datos.Usuarios.FirstOrDefault(usuario => usuario.Rut == rut);
        }

        public void GuardarUsuarioSinValidacion(Usuario usuario)
        {
            // Simplemente guardar el usuario sin realizar validaciones adicionales
            // Asegúrate de agregar el usuario a tu lista o base de datos aquí
            dgUsuarios.Add(usuario); // Agregar el usuario a la lista
        }

        public bool ExisteUsuarioConRut(string rut)
        {
            // Verificar si existe un usuario con el mismo Rut
            return datos.Usuarios.Any(usuario => usuario.Rut == rut);
        }
        public bool ExisteUsuarioConNumeroUltimaFactura(int numeroUltimaFactura)
        {
            // Verificar si existe un usuario con el mismo número de última factura
            return datos.Usuarios.Any(usuario => usuario.NumeroUltimaFactura == numeroUltimaFactura);
        }
        public void ActualizarUsuario(Usuario usuario)
        {
            // Encuentra el usuario en tu lista y actualiza sus datos
            Usuario usuarioExistente = datos.Usuarios.FirstOrDefault(u => u.Rut == usuario.Rut);

            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.Telefono = usuario.Telefono;
                usuarioExistente.Direccion = usuario.Direccion;
                usuarioExistente.FechaRegistro = usuario.FechaRegistro;
                usuarioExistente.Empresa = usuario.Empresa;
                usuarioExistente.CantidadFacturas = usuario.CantidadFacturas;
                usuarioExistente.NumeroUltimaFactura = usuario.NumeroUltimaFactura;
                usuarioExistente.MontoUltimaFactura = usuario.MontoUltimaFactura;
            }
        }

    }
}
