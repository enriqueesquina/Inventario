using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysInventario.EntidadDeNegocio;

public partial class Usuario
{
    //[Key]
    //public int Id { get; set; }

    //public int IdRol { get; set; }

    //[StringLength(30)]
    //[Unicode(false)]
    //public string Nombre { get; set; } = null!;

    //[StringLength(30)]
    //[Unicode(false)]
    //public string Apellido { get; set; } = null!;

    //[StringLength(25)]
    //[Unicode(false)]
    //public string Login { get; set; } = null!;

    //[StringLength(32)]
    //[Unicode(false)]
    //public string Password { get; set; } = null!;

    //public byte Estatus { get; set; }

    //[Column(TypeName = "datetime")]
    //public DateTime FechaRegistro { get; set; }

    //[ForeignKey("IdRol")]
    //[InverseProperty("Usuario")]
    //public virtual Rol IdRolNavigation { get; set; } = null!;

    //[InverseProperty("IdUsuarioNavigation")]
    //public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
    [Key]
    public int Id { get; set; }
    [ForeignKey("Rol")]
    [Required(ErrorMessage = "Rol es obligatorio")]
    [Display(Name = "Rol")]
    public int IdRol { get; set; }
    [Required(ErrorMessage = "Nombre es obligatorio")]
    [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Apellido es obligatorio")]
    [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
    public string Apellido { get; set; }
    [Required(ErrorMessage = "Login es obligatorio")]
    [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Password es obligatorio")]
    [DataType(DataType.Password)]
    [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
    public string Password { get; set; }
    [Required(ErrorMessage = "Estatus es obligatorio")]
    public byte Estatus { get; set; }
    [Display(Name = "Fecha registro")]
    public DateTime FechaRegistro { get; set; }
    public Rol Rol { get; set; }
    [NotMapped]
    public int Top_Aux { get; set; }
    [NotMapped]
    [Required(ErrorMessage = "Confirmar el password")]
    [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password y confirmar password deben de ser iguales")]
    [Display(Name = "Confirmar password")]
    public string ConfirmPassword_aux { get; set; }

    public enum Estatus_Usuario
    {
    ACTIVO = 1,
    INACTIVO = 2
     }
}
