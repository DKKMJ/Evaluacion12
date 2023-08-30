using Evaluacion1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1.Controladores
{
    public class UsuariosControladores : Controlador
    {

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

        public void ActualizarUsuario(int index, Usuario usuario)
        {
            Usuario usuarioExistente = datos.Usuarios[index];

            usuarioExistente.Rut = usuario.Rut;
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Empresa = usuario.Empresa;
            usuarioExistente.Telefono = usuario.Telefono;
            usuarioExistente.Direccion = usuario.Direccion;
            usuarioExistente.FechaRegistro = usuario.FechaRegistro;
            usuarioExistente.CantidadFacturas = usuario.CantidadFacturas;
            usuarioExistente.NumeroUltimaFactura = usuario.NumeroUltimaFactura;
            usuarioExistente.MontoUltimaFactura = usuario.MontoUltimaFactura;
        }

    }
}
