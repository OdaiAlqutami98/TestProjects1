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
    public class Car
    {
        [Key]
        [Column(Order =0)]
        public int IdTest { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Required]
        [Column(Order =3)]
        public string Brand { get; set; }

        [Required]
        [Column(Order =2)]
        public string Model { get; set; }
         
         public SubCategory subCategory { get; set; }
          public int SubCategoryId { get; set;}
    }
}