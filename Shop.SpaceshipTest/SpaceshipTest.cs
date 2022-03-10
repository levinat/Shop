
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Shop.Core.Dtos;
using Shop.Core.ServiceInterface;

namespace Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task Should_AddNewSpaceship_WhenReturnResult()
        {
            string guid = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";
            //byte[] array1 = new byte[1000 * 1000 * 3];

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Company = "Space";
            spaceship.Country = "Estonia";
            spaceship.Model = "Cargo";
            spaceship.Name = "asd";
            spaceship.EnginePower = 123;
            spaceship.LaunchDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifieAt = DateTime.Now;

            var result = await Svc<ISpaceshipService>().Add(spaceship);

            Assert.Empty((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);

            var result = await Svc<ISpaceshipService>().GetAsync(insertGuid);

            Assert.NotEmpty((System.Collections.IEnumerable)result);
            Assert.Single((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);

            var result = await Svc<ISpaceshipService>().Delete(insertGuid);

            Assert.NotEmpty((System.Collections.IEnumerable)result);
            Assert.Single((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_UpdateByIdSpaceship_WhenUpdateSpaceship()
        {
            string guid = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";
            //byte[] array1 = new byte[1000 * 1000 * 3];

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Company = "Space";
            spaceship.Country = "Estonia";
            spaceship.Model = "Cargo";
            spaceship.Name = "asd";
            spaceship.EnginePower = 123;
            spaceship.LaunchDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifieAt = DateTime.Now;

            await Svc<ISpaceshipService>().Update(spaceship);

            Assert.NotEmpty((System.Collections.IEnumerable)spaceship);
        }
    }
}