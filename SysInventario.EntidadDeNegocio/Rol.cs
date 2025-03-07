﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysInventario.EntidadDeNegocio;

public partial class Rol
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Nombre es obligatorio")]
    [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
    public string? Nombre { get; set; }
    [NotMapped]
    public int Top_Aux { get; set; }
    //prueba 2243444
    //Via lactea 
    public List<Usuario>? Usuario { get; set; }

}
