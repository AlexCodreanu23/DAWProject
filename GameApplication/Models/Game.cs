using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<GameDeveloper> GameDevelopers { get; set; }

        public Game()
        {

        }

    }
}