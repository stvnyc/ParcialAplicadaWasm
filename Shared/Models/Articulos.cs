using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "El campo Descripción es obligatorio")]
    [RegularExpression(@"^[a-zA-ZñÑ\s0-9]+$", ErrorMessage = "La descripción no debe contener caracteres especiales")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El campo PctItbis es obligatorio")]
    [Range(0, 18, ErrorMessage = "Ingrese un número entre 0 y 18")]
    public decimal PctItbis { get; set; }

    [Required(ErrorMessage = "El campo Costo es obligatorio")]
    [Range(0.01, 20000000, ErrorMessage = "Ingrese un número mayor a 0")]
    public decimal Costo { get; set; }
    public decimal Itbis { get; set; }
}