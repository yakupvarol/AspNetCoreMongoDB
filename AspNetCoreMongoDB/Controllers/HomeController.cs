using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreMongoDB.Models;
using AspNetCoreMongoDB.Entities;
using AspNetCoreMongoDB.Business;
using System.Threading.Tasks;
using AspNetCoreMongoDB.DTO.Car;
using System.Collections.Generic;
using AspNetCoreMongoDB.Helper;

namespace AspNetCoreMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;
       
        public HomeController(ICarService carService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _carService = carService;
        }

        public async Task<IActionResult> IndexAsync()
        {

            _carService.MongoTest();
            //------------
            
            
            var FindId = _carService.FindId(new CarListRequestDTO { Id= "5e7f493e6c3c681894f07d8e" });

            var ElemMatchFindBy = _carService.ElemMatchFindBy(new CarListRequestDTO { CommentName="Zümra", Skip = 1, Limit = 10 });
            var CarBrandRelationship = await _carService.CarBrandRelationship(new CarListRequestDTO { Brand = 3 });
            var CarBrandJoin = await _carService.CarBrandJoin(new CarListRequestDTO { CarID = 2832021135529549 });
            //-----

            int[] BrandArray = { 3, 10, 20 };
            var InExpressions = await _carService.InExpressions(new CarListRequestDTO { BrandArray = BrandArray });
            //-----

            var LinqFindFluentBy = _carService.LinqFindFluentBy(new CarListRequestDTO { Brand = 3, Skip=1, Limit=10 });
            var EqFindByList =  _carService.EqFindByList(new CarListRequestDTO { Brand = 3 });
            var AllCountAsync = await _carService.AllCountAsync();
            var FindCountAsync = await _carService.FindCountAsync(new CarListRequestDTO { Brand=3 } );
            var IEnumerableFindByAsync = await _carService.IEnumerableFindByAsync(new CarListRequestDTO { CarID = 25320201815224 });
            var GetId = _carService.GetId("5e7abe0f6d3387085c46a97e");
            var GetIdAsync = await _carService.GetIdAsync("5e7abe0f6d3387085c46a97e");
            var IEnumerableAsync = await _carService.IEnumerableAsync();
            var IListGetAllAsync = await _carService.IListGetAllAsync();
            var IQueryableGetAll =  _carService.IQueryableGetAll();

            var QueryableAsFindBy = _carService.QueryableAsFindBy(new CarListRequestDTO { Brand = 3, Skip = 1, Limit = 10 });
            var TextFindBy =  _carService.TextFindBy(new CarListRequestDTO { TextData="Eyüp"});
            //-----
            
          

            return View();
        }

        public async Task<IActionResult> InsertAsync()
        {
            var result = await _carService.AddOneAsync(new Cars { CarID = new HelperMongo().Random(), Brand = 4, Model = "2011", Price = 14, Year = 2021, ImageUrl = "deneme.jpg" });
            return View();
        }

        public async Task<IActionResult> InsertMultipleAsync()
        {
            var DataInsert = new List<Cars>
            {
                new Cars { CarID= new HelperMongo().Random(), Brand=4, Model="2011", Price=14, Year=2021, ImageUrl="deneme.jpg"},
                new Cars { CarID=new HelperMongo().Random(), Brand=4, Model="2017", Price=13, Year=2025, ImageUrl="5deneme.jpg"}
            };
            var AddManyAsync = await _carService.AddManyAsync(DataInsert);
            return View();
        }

        public async Task<IActionResult> InsertInRelationshipAsync()
        {
            var CarID = new HelperMongo().Random();
            var dt = new Cars
            { 
                CarID = CarID, Brand = 3, Model = "2012", Price = 12, Year = 2021, ImageUrl = "deneme.jpg",
                Comment = new List<Comment>
                {
                    new Comment { CommentID= new HelperMongo().Random(), CarID=CarID, Name ="Eyüp 2", Message="Test Mesajı 1" },
                    new Comment { CommentID= new HelperMongo().Random(), CarID=CarID,Name="Ensar 2", Message="Test Mesajı 2" }
                }
            };
            var result = await _carService.AddOneAsync(dt);

            return View();
        }

        public async Task<IActionResult> InsertOutRelationshipAsync() 
        {
            var CarID = new HelperMongo().Random();

            var dtCars = new Cars
            {  
                CarID = CarID, Brand = 3, Model = "2012", Price = 12, Year = 2021, ImageUrl = "deneme.jpg",
                Comment = new List<Comment>
                {
                    new Comment { CommentID= new HelperMongo().Random(), CarID=CarID, Name ="Eyüp 2", Message="Test Mesajı 1" },
                    new Comment { CommentID= new HelperMongo().Random(), CarID=CarID,Name="Ensar 22", Message="Test Mesajı 2" }
                }
            };

            var dtMarkalar = new List<Markalar>
            {
                new Markalar { brandid= new HelperMongo().Random(), CarID=CarID, name ="Eyüp 2"},
                new Markalar { brandid= new HelperMongo().Random(), CarID=CarID, name ="Eyüp 4"}
            };

            dtCars.Markalar = dtMarkalar;

            var result = await _carService.InsertRelationshipAsync(dtCars);

            return View();
        }

        public async Task<IActionResult> UpdateReplaceOneAsync()
        {
            var dt = new Cars { Id = "5e7f493e6c3c681894f07d8e", CarID = new HelperMongo().Random(), Brand = 223, Model = "1121012", Price = 412, Year = 2020, ImageUrl = "deneme.jpg" };
            var result = await _carService.UpdateReplaceOneAsync(dt);

            return View();
        }

        public async Task<IActionResult> UpdateOneAsync()
        {
            var dt = new Cars { Id = "5e7f493e6c3c681894f07d8e", CarID = new HelperMongo().Random(), Brand = 261, Model = "1121012", Price = 412, Year = 20270, ImageUrl = "veri.jpg" };
            var result = await _carService.UpdateOneAsync(dt);

            return View();
        }

        public async Task<IActionResult> UpdateManyAsync()
        {
            var dt = new Cars { Id = "5e7f493e6c3c681894f07d8e", CarID = new HelperMongo().Random(), Brand = 3, Model = "400", Price = 412, Year = 20270, ImageUrl = "veri.jpg" };
            var result = await _carService.UpdateManyAsync(dt);

            return View();
        }

        public async Task<IActionResult> UpdateAddToSetAsync()
        {
            var dt = new Comment { CarID = 22222, Name = "Eyüp", Message = "Test Mesajı" };
           var src = new CarListRequestDTO { Id = "5e7f493e6c3c681894f07d8e"};
           var result = await _carService.UpdateAddToSetAsync(src,dt);

            return View();
        }

        public async Task<IActionResult> UpdateManyAddToSetAsync()
        {
            var dt = new List<Comment>
            {
                new Comment { CarID = 22222, Name = "Eyüp 111", Message = "Test Mesajı 33" },
                new Comment { CarID = 22222, Name = "Eyüp 222", Message = "Test Mesajı 44" }
            };
            var src = new CarListRequestDTO { Id = "5e7f493e6c3c681894f07d8e" };
            var result = await _carService.UpdateManyAddToSetAsync(src, dt);

            return View();
        }

        public async Task<IActionResult> UpdateElemMatchAsync()
        {
            var src = new CarListRequestDTO { Id = "5e7f493e6c3c681894f07d8e", CommentName= "Zümra" };
            var result = await _carService.UpdateElemMatchAsync(src, "Nehir");
            return View();
        }

        public async Task<IActionResult> DeleteOneAsync()
        {
            var DeleteManyAsync = await _carService.DeleteOneAsync(new CarListRequestDTO { Id = "5e7f493e6c3c681894f07d8e" });
            return View();
        }

        public async Task<IActionResult> DeleteManyAsync()
        {
            var DeleteManyAsync = await _carService.DeleteManyAsync(new CarListRequestDTO { Brand = 4 });
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
