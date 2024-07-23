using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysInventario.AccesoADatos;
using Microsoft.EntityFrameworkCore;
using SysInventario.EntidadDeNegocio;

namespace Inventario.WebAPI.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpGet(Name = "GetProductos")]

        public async Task<List<Producto>> Get()
        {
            var listaproducto = await ProductoDAL.ObtenerTodosAsync();
            if (listaproducto.Count >= 1)
            {
                return listaproducto;
            }
            else
            {
                return new List<Producto>();
            }
        }

        [HttpPost(Name = "PostProductos")]
        public async Task<int> Post(Producto pProducto)
        {
            if (pProducto.Id >= 0)
            {
                int resultado = await ProductoDAL.CrearAsync(pProducto);
                return resultado;
            }
            else
            {
                return 0;
            }
        }
        [HttpDelete(Name = "DeletProductos")]
        public async Task<int> Delete(int id)
        {
            using (var bdContext = new BdContext())
            {
                var producto = await bdContext.Producto.FirstOrDefaultAsync(s => s.Id == id);
                if (id >= 0)
                {
                    bdContext.Producto.Remove(producto!);
                    id = await bdContext.SaveChangesAsync();
                }
            }
            return id;
        }

        [HttpPut(Name = "Put/Productos")]
        public async Task<int> Put(int id, Producto pProducto)
        {
            using (var bdContext = new BdContext())
            {
                var producto = await bdContext.Producto.FirstOrDefaultAsync(c => c.Id == id);

                producto.Nombre = pProducto.Nombre;
                producto.Precio = pProducto.Precio;
                producto.Stock = pProducto.Stock;
                producto.Foto = pProducto.Foto;
                producto.IdUsuario = pProducto.IdUsuario;
                producto.IdCategoria = pProducto.IdCategoria;

                await bdContext.SaveChangesAsync();

                return 1;
                //lis
            }
        }

    }
}
