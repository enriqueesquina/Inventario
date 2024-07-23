using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysInventario.AccesoADatos;
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
    }
}
