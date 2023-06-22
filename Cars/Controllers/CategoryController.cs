using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars.DataAccess;
using Cars.Models;
using Cars.ViewModels;
using Cars.ViewModels.Category;
namespace Cars.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
          private readonly DbConnection _context;
    public CategoryController (DbConnection context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task <IEnumerable<CategoryVM>> GetCategory(){
        var categories=await _context.categories.ToListAsync();
        return categories.Select(c => new CategoryVM
        {
            IdTest = c.IdTest,
            Name = c.Name,
            
        }).ToList();
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryVM vM)
    {
        var category = new Category{
            Name= vM.Name,
            


        };
        _context.categories.Add(category);
        await _context.SaveChangesAsync();
        return Ok();

    }
}
}