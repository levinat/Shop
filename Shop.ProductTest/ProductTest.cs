using Microsoft.AspNetCore.Mvc;
using Moq;
using Shop.Controllers;
using Shop.Core.ServiceInterface;
using Shop.ProductTest.Fixture;
using System;
using System.IO;
using Xunit;

namespace Shop.ProductTest
{
    public class ProductTest : IClassFixture<ControllerFixture>
    {

        private readonly ProductController _productController;

        public ProductTest(ControllerFixture fixture)
        {
            _productController = fixture._productController;
        }


        [Fact]
        public void Get_WithoutParam_Ok_Test()
        {
            string guid = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";
            var guidParse = Guid.Parse(guid);


            //var result = _productController.Edit(guidParse) as OkObjectResult;

            //Assert.Equal(400, result.StatusCode);
            //Assert.Equal("User not found!", result.Value);
        }
    }
}
