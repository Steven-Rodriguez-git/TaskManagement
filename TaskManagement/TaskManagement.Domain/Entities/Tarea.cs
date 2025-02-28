using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }


    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = "Tarea de prueba";

        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        public Estado Estado { get; set; } 

        [Required]
        [MaxLength(6)]
        public string Codigo { get; set; }
    }
}
