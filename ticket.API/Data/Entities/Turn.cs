using System;
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

        [Display(Name = "Ventanilla")]
        [MaxLength(5, ErrorMessage = "El campo{0} no puede tener mas de {1} caracteres")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Stand { get; set; }

        [Display(Name = "Fecha y hora")]
        //[Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ExpeditionDate { get; set; }

        [Display(Name = "Fecha y hora de atención")]
        //[Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime AttentionDate { get; set; }


    }
}
