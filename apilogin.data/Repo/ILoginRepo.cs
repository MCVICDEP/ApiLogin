using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apilogin.modelo;

namespace apilogin.data.Repo
{
    public interface ILoginRepo
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetDetalles(int id);
        Task<bool> InsertarUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> EliminarUsuario(Usuario usuario);
    }
}
