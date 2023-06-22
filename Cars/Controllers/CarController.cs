using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars.DataAccess;
using Cars.Models;
using Cars.ViewModels;
using Cars.ViewModels.Car;
namespace Cars.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CarController : ControllerBase
    {
        private readonly DbConnection _context;
    public CarController (DbConnection context)
    {
        _context = context;
    }
        [HttpGet]
        public async Task<IEnumerable<CarVM>> GetALL()
        {
            var car = await _context.cars.Include(c=>c.subCategory).ToListAsync ();
            return  car.Select(c => new CarVM
            {
               
                Name = c.Name,
                IdTest=c.IdTest,
                
              
                SubCategory =new  SubCategoryVM
                {
                    Name = c.subCategory.Name,
                    IdTest=c.IdTest,
                }

            }).ToList();
        }
        [HttpGet]
        public async Task<IEnumerable<CarVM>> GetCarsBySubCategory(int SubCategoryId)
        {
            var car = await _context.cars.Include(c=>c.subCategory).Where(c => c.SubCategoryId==SubCategoryId).ToListAsync();
            return  car.Select(c => new CarVM
            {
                Name = c.Name,
                IdTest=c.IdTest,
                SubCategory =new SubCategoryVM
                {
                    Name = c.subCategory.Name,
                    IdTest=c.IdTest,
                }
            }).ToList();

       
    }
    [HttpGet]
   public async Task <IEnumerable<CarVM>> GetCarsByCategory(int CategoryId)
    {
         var car = await _context.cars.Include(c=>c.subCategory).ThenInclude(s=>s.Category).Where(c => c.subCategory.CategoryId==CategoryId).ToListAsync();
        return  car.Select(c => new CarVM
        {
            Name = c.Name,
            IdTest=c.IdTest,
            SubCategory =new SubCategoryVM
            {
                Name = c.subCategory.Name,
                IdTest=c.IdTest,
        
    }
}).ToList();


        var test= _context.cars.
        Join(_context.subCategories,c=>c.SubCategoryId,s=>s.IdTest,(c,s)=> new{c,s})
        .Join(_context.categories,c=>c.s.CategoryId,ca=>ca.IdTest,(c,ca)=> new{c,ca})
        .Where(c=>c.ca.IdTest==CategoryId);
        var result =await test.ToListAsync();
}
[HttpPost]
    public async Task<IActionResult> Post(CreateCarVM vM)
    {
        var car = new Car {
            Name = vM.Name,
            IdTest = vM.IdTest,
            SubCategoryId = vM.SubCategoryId
            
            };
            _context.cars.Add(car);
            await _context.SaveChangesAsync();
            return Ok(car);
            
        }
    }
}