using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Cars.ViewModels
{
    public class SubCategoryVM
    {
        public int IdTest { get; set; }
        public string Name { get; set; }
        public CategoryVM Category { get; set; }
    }
}