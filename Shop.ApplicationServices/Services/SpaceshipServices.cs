﻿using Shop.Core.Domain;
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
    public class SpaceshipServices : ISpaceshipService
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileServices _fileServices;

        public SpaceshipServices
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

        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Model = dto.Model;
            spaceship.Company = dto.Company;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Country = dto.Country;
            spaceship.LaunchDate = dto.LaunchDate;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifieAt = DateTime.Now;
            _fileServices.ProcessUploadFile(dto, spaceship);

            await _context.Spaceship.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }


        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceship
               // .Include(x => x.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _context.ExistingFilePath
                .Where(x => x.SpaceshipId == id)
               /* .Select(y => new ExistingFilePathDto
                {
                    SpaceshipId = y.SpaceshipId,
                    ExistingFilePath = y.FilePath,
                    Id = y.Id
                })*/
                .ToArrayAsync();


           // await _fileServices.RemoveImages(photos);
            _context.Spaceship.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }


        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();

            spaceship.Id = dto.Id;
            spaceship.Name = dto.Name;
            spaceship.Model = dto.Model;
            spaceship.Company = dto.Company;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Country = dto.Country;
            spaceship.LaunchDate = dto.LaunchDate;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifieAt = DateTime.Now;
            //_fileServices.ProcessUploadFile(dto, spaceship);

            _context.Spaceship.Update(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }

        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceship
              //  .Include(y => y.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }


    }
}