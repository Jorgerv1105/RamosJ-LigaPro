using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RamosJ_LigaPro.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Nombre del equipo")]
        public string Nombre { get; set; }
        [Range(0, 100)]
        public int PartidosJugados { get; set; }
        [Range(0, 100)]
        public int PartidosGanados { get; set; }
        [Range(0, 100)]
        public int PartidosEmpatados { get; set; }
        [Range(0, 100)]
        public int PartidosPerdidos { get; set; }
        [Range(0, 100)]
        public int Puntos    //Creacion del parametro puntos para su posterior modificacion que
                             //retorne el valor de partidos ganados por 3 y sume los partidos
                             //empatados en este caso tomandolo como un punto
        {
            get
            {
                return (PartidosGanados * 3) + PartidosEmpatados;
            }
            set { }
        }


    }
}
