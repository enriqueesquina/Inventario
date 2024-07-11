using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysInventario.EntidadDeNegocio;

public partial class Categoria
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Nombre es obligatorio")]
    [StringLength(50)]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "Ubicacion es obligatorio")]
    [StringLength(400)]
    public string? Ubicacion { get; set; }
    [NotMapped]
    public int Top_Aux { get; set; }
    public List<Producto>? Productos { get; set; }
}
