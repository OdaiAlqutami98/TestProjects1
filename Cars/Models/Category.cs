using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cars.Models
{
    public class Category
    {
        [Key]
        [Column(Order =0)]
        public int IdTest { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        [Required]
        [Column(Order =1)]
        public string Name { get; set; }
    }
}