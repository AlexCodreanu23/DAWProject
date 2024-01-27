using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace GameApplication.Models
{
    public class SystemRequirement
    {
        [Key]
        public int RequirementsId { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public string MinimumCPU { get; set; }

        public string RecommendedCPU { get; set; }

        public string MinimumRAM { get; set; }

        public string RecommendedRAM { get; set; }

        public string RecommendedGraphics { get; set; }

        public string StorageRequired { get; set; }



        public SystemRequirement()
        {

        }
    }
}