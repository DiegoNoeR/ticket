using System.ComponentModel.DataAnnotations;

namespace ticket.API.Data.Entities
{
    public class Turn
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Servicio")]
        [MaxLength(5, ErrorMessage = "El campo{0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ServicesType { get; set; }

        [Display(Name = "Número de Turno")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ShiftNumber { get; set; }
        [Display(Name ="Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Date { get; set; }
        [Display(Name = "Hora")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Time { get; set; }

    }
}
