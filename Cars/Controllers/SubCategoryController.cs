using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars.DataAccess;
using Cars.Models;
using Cars.ViewModels;
using Cars.ViewModels.SubCategory;
namespace Cars.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SubCategoryController : ControllerBase
    {
          private readonly DbConnection _context;
    public SubCategoryController (DbConnection context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IEnumerable<SubCategoryVM>> GetSubCategory(){
        var subCategory= await _context.subCategories.ToListAsync();
        return subCategory.Select(s => new SubCategoryVM
        {
            IdTest = s.IdTest,
            Name = s.Name,
           


        }).ToList();
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateSubCategoryVM vm)
    {
        var subCategories =new SubCategory{
            Name=vm.Name,
            CategoryId = vm.CategoryId
            
        
        };
        _context.subCategories.Add(subCategories);
        await _context.SaveChangesAsync();
        return Ok(subCategories);
    }
}
}