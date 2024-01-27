using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameApplication.Models
{
    public class GameDeveloper
    {
        [Key]
        public int GameDeveloperId { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int DeveloperId { get; set; }
        public Developers Developers { get; set; }

    }
}
