using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysInventario.EntidadDeNegocio;

public partial class Producto
{
    [Key]
    // a richar le gusta q sela arimen 
    public int Id { get; set; }
    [Required(ErrorMessage = "condigo es obligatorio")]
    [StringLength(70)]
    public string Codigo { get; set; } = null!;
  
    [Required(ErrorMessage = "Nombre es obligatorio")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "precio es obligatorio")]
    [Column(TypeName = "decimal(30, 2)")]
    public decimal Precio { get; set; }
    [Required(ErrorMessage = "Stock es obligatorio")]
    public int Stock { get; set; }
    [Required(ErrorMessage = "Foto es obligatorio")]
    public string Foto { get; set; } = null!;
    [NotMapped]
    public int Top_Aux { get; set; }
    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }
    [ForeignKey("Categoria")]
    public int IdCategoria { get; set; }
    public Categoria? Categoria { get; set; }
    public Usuario? Usuario { get; set; }
}
