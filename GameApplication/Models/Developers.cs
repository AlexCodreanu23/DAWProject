using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication.Models
{
    public class Developers
    {
        [Key]
        public int DeveloperId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(0, int.MaxValue)]
        public int Salary { get; set; }

        public Developers()
        {

        }
    }
}