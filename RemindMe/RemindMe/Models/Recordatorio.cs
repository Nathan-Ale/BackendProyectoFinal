using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemindMe.Models
{
    [Table(name: "Recordatorio")]
    public class Recordatorio
    {
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Column(name: "titulo")]
        public string Titulo { get; set; }

        [Column(name: "descripcion")]
        public string Descripcion { get; set; }

        [Column(name: "fecha_hora")]
        public DateTime Fecha_Hora { get; set; }

        [Column(name: "created_at")]
        public DateTime Created_At { get; set; }
    }
}
