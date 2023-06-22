using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.ViewModels.Car
{
    public class CreateCarVM
    {
        public int IdTest { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }   
        public string Model { get; set; }
        public int SubCategoryId{ get;set; }
    }
}