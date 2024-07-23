using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysInventario.AccesoADatos;
using SysInventario.EntidadDeNegocio;
using SysInventario.LogicaDeNegocio;


namespace Inventario.WebAPI.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {


        [HttpGet(Name = "GetCategorias")]

        public async Task<List<Categoria>> Get()
        {
            var listacategoria = await CategoriaDAL.ObtenerTodosAsync();
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
        [HttpDelete(Name = "DeleteCategorias")]
        public async Task<int> Delete(int id)
        {
            using (var bdContext = new BdContext())
            {
                var categoria = await bdContext.Categoria.FirstOrDefaultAsync(s => s.Id == id);
                if (id >= 0)
                {
                    bdContext.Categoria.Remove(categoria!);
                    id = await bdContext.SaveChangesAsync();
                }
            }
            return id;
        }

        [HttpPut(Name = "Put/Categorias")]
        public async Task<int> Put(int id, Categoria categoria)
        {
            using (var bdContext = new BdContext())
            {
                var Categoria = await bdContext.Categoria.FirstOrDefaultAsync(c => c.Id == id);

                Categoria!.Nombre = categoria.Nombre;
                Categoria.Ubicacion = categoria.Ubicacion;

                await bdContext.SaveChangesAsync(); 

                return 1 ; 
            }
        }

    }
}