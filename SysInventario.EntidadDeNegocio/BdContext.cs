using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SysInventario.EntidadDeNegocio;

public partial class BdContext : DbContext
{
    public BdContext()
    {
    }

    public BdContext(DbContextOptions<BdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
        optionsBuilder.UseSqlServer("workstation id=DBInventario2024.mssql.somee.com;packet size=4096;user id=Ericklue65_SQLLogin_1;pwd=dkaofc33km;data source=DBInventario2024.mssql.somee.com;persist security info=False;initial catalog=DBInventario2024;TrustServerCertificate=True");
    }

}
