using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Cars.Models;
using Cars.DataAccess;
using Cars.Controllers;
namespace Cars.ViewModels
{
    public class CarVM
    {
        public int IdTest { get; set; }
        public string Name { get; set; }
        public SubCategoryVM SubCategory{ get; set; }
    }
}