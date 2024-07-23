using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysInventario.AccesoADatos;
using SysInventario.EntidadDeNegocio;

namespace Inventario.WebAPI.Controllers
{
    [Route("api/rol")]
    [ApiController]
    public class RolController : ControllerBase
    {
        [HttpGet(Name = "GetRol")]
        public async Task<List<Rol>> Get()
        {
            var listarol = await RolDAL.ObtenerTodosAsync();
            if (listarol.Count >= 1)
            {
                return listarol;
            }
            else
            {
                return new List<Rol>();
            }

        }
        [HttpPost(Name = "PostRol")]

        public async Task<int> Post(Rol pRol)
        {
            if (pRol.Id >= 0)
            {
                int resultado = await RolDAL.CrearAsync(pRol);
                return resultado;
            }
            else
            {
                return 0;
            }
        }
        [HttpDelete(Name = "DeleteRol")]
        public async Task<int> Delete(int id)
        {
            using (var bdContext = new BdContext())
            {
                var rol = await bdContext.Rol.FirstOrDefaultAsync(s => s.Id == id);
                if (id >= 0)
                {
                    bdContext.Rol.Remove(rol!);
                    id = await bdContext.SaveChangesAsync();
                }
            }
            return id;
        }
        [HttpPut(Name = "Put/Rol")]
        public async Task<int> Put(int id, Rol rol)
        {
            using (var bdContext = new BdContext())
            {
                var Rol = await bdContext.Rol.FirstOrDefaultAsync(c => c.Id == id);

                Rol!.Nombre = rol.Nombre;

                await bdContext.SaveChangesAsync();

                return 1;
            }
        }



    }
}
