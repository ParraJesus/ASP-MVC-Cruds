using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class ContactoModelo
    {
        //Llamo las clases con el mismo esquema de la tabla creada
        public int IdContacto { get; set; }
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }
    }
}
