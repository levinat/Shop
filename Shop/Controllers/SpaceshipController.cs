
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Dtos;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.Models.Product;
using Shop.Models.Spaceship;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly ISpaceshipService _spaceshipService;
        private readonly IFileServices _fileServices;

        public SpaceshipController
            (
            ShopDbContext context,
            ISpaceshipService spaceshipService,
            IFileServices fileServices
            )
        {
            _context = context;
            _spaceshipService = spaceshipService;
            _fileServices = fileServices;
        }

        //ListItem
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Spaceship
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipListItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    Model = x.Model,
                    Company = x.Company,
                    EnginePower = x.EnginePower,
                    Country = x.Country,
                    LaunchDate = x.LaunchDate
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SpaceshipViewModel model = new SpaceshipViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Model = vm.Model,
                Company = vm.Company,
                EnginePower = vm.EnginePower,
                Country = vm.Country,
                LaunchDate = vm.LaunchDate,
                CreatedAt = vm.CreatedAt,
                ModifieAt = vm.ModifieAt,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId
                   
                }).ToArray()

            };

            var result = await _spaceshipService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipService.Delete(id);
            if (spaceship == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipService.GetAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabase
                .Where(x => x.SpaceshipId == id)
                .Select(y => new ImageViewModel
                { 
                    ImageData = y.ImageData,
                    Id = y.Id,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
                    ImageTitle = y.ImageTitle,
                    SpaceshipId = y.Id
                }).ToArrayAsync();

            var model = new SpaceshipViewModel();

            model.Id = spaceship.Id;
            model.Name = spaceship.Name;
            model.Model = spaceship.Model;
            model.Company = spaceship.Company;
            model.EnginePower = spaceship.EnginePower;
            model.Country = spaceship.Country;
            model.LaunchDate = spaceship.LaunchDate;
            model.CreatedAt = spaceship.CreatedAt;
            model.ModifieAt = spaceship.ModifieAt;
            model.Image.AddRange(photos);


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SpaceshipViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Model = vm.Model,
                Company = vm.Company,
                EnginePower = vm.EnginePower,
                Country = vm.Country,
                LaunchDate = vm.LaunchDate,
                CreatedAt = vm.CreatedAt,
                ModifieAt = vm.ModifieAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId

                })


            };

            var result = await _spaceshipService.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
    }
}