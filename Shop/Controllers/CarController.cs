using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Dtos;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.Models.Car;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CarController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly ICarService _carService;
        private readonly IFileServices _fileServices;

        public CarController
            (
            ShopDbContext context,
            ICarService carService,
            IFileServices fileServices
            )
        {
            _context = context;
            _carService = carService;
            _fileServices = fileServices;
        }

        //ListItem
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Car
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarListItem
                {
                    Id = x.Id,
                    VIN = x.VIN,
                    Color = x.Color,
                    Year = x.Year,
                    Fuel = x.Fuel,
                    Transmission = x.Transmission
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarViewModel model = new CarViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                VIN = model.VIN,
                Color = model.Color,
                Year = model.Year,
                Fuel = model.Fuel,
                Transmission = model.Transmission,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths.Select(x => new ExistingFilePathDto
                {
                    Id = x.PhotoId,
                    ExistingFilePath = x.FilePath,
                    CarId = x.CarId
                }).ToArray()
            };

            var result = await _carService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carService.Delete(id);
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carService.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.ExistingFilePath
                .Where(x => x.CarId == id)
                .Select(y => new ExistingFilePathViewModel
                {
                    CarId = y.CarId,
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();

            var model = new CarViewModel();

            model.Id = car.Id;
            model.VIN = car.VIN;
            model.Color = car.Color;
            model.Year = car.Year;
            model.Fuel = car.Fuel;
            model.Fuel = car.Fuel;
            model.Transmission = car.Transmission;
            model.CreatedAt = car.CreatedAt;
            model.ExistingFilePaths.AddRange(photos);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                VIN = model.VIN,
                Color = model.Color,
                Year = model.Year,
                Fuel = model.Fuel,
                Transmission = model.Transmission,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                    .Select(x => new ExistingFilePathDto
                    {
                        Id = x.PhotoId,
                        ExistingFilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
            };

            var result = await _carService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathViewModel model)
        {
            var dto = new ExistingFilePathDto()
            {
                Id = model.PhotoId
            };

            var photo = await _fileServices.RemoveImage(dto);
            if (photo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction(nameof(Index));
        }
        
    }

}