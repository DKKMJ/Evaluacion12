using Evaluacion1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evaluacion1.Controladores
{
    public class UsuariosControladores : Controlador
    {
        private List<Usuario> dgUsuarios = new List<Usuario>(); // Declarar e inicializar la lista

        // Obtener la lista de usuarios
        public List<Usuario> ObtenerListaUsuarios()
        {
            return datos.Usuarios;
        }

        // Guardar un usuario en la lista
        public void GuardarUsuario(Usuario usuario)
        {
            datos.Usuarios.Add(usuario);
        }

        // Eliminar un usuario de la lista por índice
        public void EliminarUsuario(int index)
        {
            datos.Usuarios.RemoveAt(index);
        }

        // Obtener un usuario por su Rut
        public Usuario ObtenerUsuarioPorRut(string rut)
        {
            return datos.Usuarios.FirstOrDefault(usuario => usuario.Rut == rut);
        }

        // Guardar un usuario sin realizar validaciones adicionales
        public void GuardarUsuarioSinValidacion(Usuario usuario)
        {
            // Simplemente guardar el usuario sin realizar validaciones adicionales
            // Asegúrate de agregar el usuario a tu lista o base de datos aquí
            dgUsuarios.Add(usuario); // Agregar el usuario a la lista
        }

        // Verificar si existe un usuario con el mismo Rut
        public bool ExisteUsuarioConRut(string rut)
        {
            return datos.Usuarios.Any(usuario => usuario.Rut == rut);
        }

        // Verificar si existe un usuario con el mismo número de última factura
        public bool ExisteUsuarioConNumeroUltimaFactura(int numeroUltimaFactura)
        {
            return datos.Usuarios.Any(usuario => usuario.NumeroUltimaFactura == numeroUltimaFactura);
        }

        // Actualizar los datos de un usuario existente
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
