using AutoMapper;
using Shop.ApplicationServices.Services;
using Shop.Controllers;
using Shop.ProductTest.Mock.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ProductTest.Fixture
{
    public class ControllerFixture : IDisposable
    {
        public TestDbContextMock _testDbContextMock { get; set; }
        public ProductServices _productServices { get; set; }
        public ProductController _productController { get; private set; }
        private IMapper mapper { get; set; }


        //public ControllerFixture()
        //{
        //    _testDbContextMock = new TestDbContextMock();

        //    string guid = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";

        //    _testDbContextMock.Product.AddRange(new Core.Domain.Product[]
        //        {
        //            new Core.Domain.Product()
        //            {
        //                Id = Guid.Parse(guid),
        //                Name = "Superman",
        //                Value = 123,
        //                Description = "Superman",
        //                Weight = 123,
        //                CreatedAt = DateTime.Now,
        //                ModifiedAt = DateTime.Now
        //            }
        //        });
        //    _testDbContextMock.SaveChanges();

            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    //teha automapperi class
            //    mc.AddProfile(new MappingProfile());
            //});

            //mapper = mappingConfig.CreateMapper();

        //    _productServices = new ProductServices(_testDbContextMock, null, mapper);

        //    _productController = new ProductController(null, _productServices, null);
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (true)
                {
                    _testDbContextMock.Dispose();
                    _testDbContextMock = null;

                    _productServices = null;

                    _productController = null;
                }
            }
        }
    }
}
