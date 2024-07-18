using Microsoft.EntityFrameworkCore;
using SysInventario.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysInventario.AccesoADatos
{
    public class CategoriaDAL
    {
        public static async Task<int> CrearAsync(Categoria categoria)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                bdContexto.Add(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Categoria categoria)
        {
            int result = 0;
            using (var bdContext = new BdContext())
            {
                var cCategoria = await bdContext.Categoria.FirstOrDefaultAsync(s => s.Id == categoria.Id);
                categoria.Nombre = categoria.Nombre;
                bdContext.Update(categoria);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Categoria cCategoria)
        {
            int result = 0;
            using (var bdContext = new BdContext())
            {
                var categoria = await bdContext.Categoria.FirstOrDefaultAsync(s => s.Id == cCategoria.Id);
                bdContext.Categoria.Remove(categoria);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Categoria> ObtenerPorIdAsync(Categoria cCategoria)
        {
            var categoria = new Categoria();
            using (var bdContext = new BdContext())
            {
                categoria = await bdContext.Categoria.FirstOrDefaultAsync(s => s.Id == cCategoria.Id);
            }
            return categoria;
        }
        public static async Task<List<Categoria>> ObtenerTodosAsync()
        {
            var categorias = new List<Categoria>();
            using (var bdContext = new BdContext())
            {
                categorias = await bdContext.Categoria.ToListAsync();
            }
            return categorias;
        }
        internal static IQueryable<Categoria> QuerySelect(IQueryable<Categoria> cQuery, Categoria cCategoria)
        {
            if (cCategoria.Id > 0)
                cQuery = cQuery.Where(s => s.Id == cCategoria.Id);
            if (!string.IsNullOrWhiteSpace(cCategoria.Nombre))
                cQuery =cQuery.Where(s => s.Nombre.Contains(cCategoria.Nombre));
            cQuery = cQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (cCategoria.Top_Aux > 0)
                cQuery = cQuery.Take(cCategoria.Top_Aux).AsQueryable();
            return cQuery;
        }
        public static async Task<List<Categoria>> BuscarAsync(Categoria cCategoria)
        {
            var categorias = new List<Categoria>();
            using (var bdContext = new BdContext())
            {
                var select = bdContext.Categoria.AsQueryable();
                select = QuerySelect(select, cCategoria);
                categorias = await select.ToListAsync();
            }
            return categorias;
        }
    }
}

