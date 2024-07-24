using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysInventario.AccesoADatos;
using Microsoft.EntityFrameworkCore;
using SysInventario.EntidadDeNegocio;

namespace Inventario.WebAPI.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]

        public async Task<List<Usuario>> Get()
        {
            var listausuario = await UsuarioDAL.ObtenerTodosAsync();
            if (listausuario.Count >= 1)
            {
                return listausuario;
            }
            else
            {
                return new List<Usuario>();
            }
        }

        [HttpPost(Name = "PostUsuarios")]
        public async Task<int> Post(Usuario pUsuario)
        {
            if (pUsuario.Id >= 0)
            {
                int resultado = await UsuarioDAL.CrearAsync(pUsuario);
                return resultado;
            }
            else
            {
                return 0;
            }
        }

        [HttpDelete(Name = "DeleteUsuario")]
        public async Task<int> Delete(int id)
        {
            using (var bdContext = new BdContext())
            {
                var usuario = await bdContext.Usuario.FirstOrDefaultAsync(s => s.Id == id);
                if (id >= 0)
                {
                    bdContext.Usuario.Remove(usuario!);
                    id = await bdContext.SaveChangesAsync();
                }
            }
            return id;
        }

        [HttpPut(Name = "Put/Usuarios")]
        public async Task<int> Put(int id, Usuario pUsuario)
        {
            using (var bdContext = new BdContext())
            {
                var usuario = await bdContext.Usuario.FirstOrDefaultAsync(c => c.Id == id);

                usuario!.IdRol = pUsuario.IdRol;
                usuario.Nombre = pUsuario.Nombre;
                usuario.Apellido = pUsuario.Apellido;
                usuario.Login = pUsuario.Login;
                usuario.Password = pUsuario.Password;
                usuario.Estatus = pUsuario.Estatus;
                usuario.FechaRegistro = pUsuario.FechaRegistro;

                await bdContext.SaveChangesAsync();

                return 1;
                //lis
            }
        }

    }
}
