using Shop.Core.Domain;
using Shop.Core.Dtos;
using Shop.Data;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Core.ServiceInterface;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace Shop.ApplicationServices.Services
{
    public class CarServices : ICarService
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileServices _fileServices;

        public CarServices
            (
            ShopDbContext context,
            IWebHostEnvironment env,
            IFileServices fileServices
            )
        {
            _context = context;
            _env = env;
            _fileServices = fileServices;
        }

        public async Task<Car> Add(CarDto dto2)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.VIN = dto2.VIN;
            car.Color = dto2.Color;
            car.Year = dto2.Year;
            car.Fuel = dto2.Fuel;
            car.Transmission = dto2.Transmission;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            _fileServices.ProcessUploadFile2(dto2, car);

            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }


        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Car
                .Include(x => x.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _context.ExistingFilePath
                .Where(x => x.CarId == id)
                .Select(y => new ExistingFilePathDto
                {
                    CarId = y.CarId,
                    ExistingFilePath = y.FilePath,
                    Id = y.Id
                })
                .ToArrayAsync();


            await _fileServices.RemoveImages(photos);
            _context.Car.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }


        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.VIN = dto.VIN;
            car.Color = dto.Color;
            car.Year = dto.Year;
            car.Fuel = dto.Fuel;
            car.Transmission = dto.Transmission;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = DateTime.Now;
            _fileServices.ProcessUploadFile(dto, car);

            _context.Car.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }


    }
}