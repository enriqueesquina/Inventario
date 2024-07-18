using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysInventario.AccesoADatos;
using SysInventario.EntidadDeNegocio;

namespace Inventario.WebAPI.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {


        [HttpGet(Name ="GetCategorias")]

    public async Task<List<Categoria>> Get()
        {
            var listacategoria =await CategoriaDAL.ObtenerTodosAsync();
            if (listacategoria.Count >= 1)
            {
                return listacategoria;
            }
            else
            {
                return new List<Categoria>();
            }

        }

        [HttpPost(Name = "PostCategorias")]
        public async Task<int> Post(Categoria pCategoria)
        {
            if (pCategoria.Id >= 0)
            {
                int resultado = await CategoriaDAL.CrearAsync(pCategoria);
                return resultado;
            }
            else
            {
                return 0;
            }
        }
    }
}
