namespace CRUDCORE.Models
{
    public class ContactoModelo
    {
        //Llamo las clases con el mismo esquema de la tabla creada
        public int IdContacto { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
    }
}
