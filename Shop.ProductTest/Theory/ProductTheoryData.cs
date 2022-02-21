using Shop.Core.Dto;
using Xunit;
using System;

namespace Shop.ProductTest.Theory
{
    public class ProductTheoryData : TheoryData<ProductDto>
    {
        public ProductTheoryData()
        {
            string guid = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";

            Add(new ProductDto()
            {
                Id = Guid.Parse(guid),
                Name = "Superman",
                Value = 123,
                Description = "Superman",
                Weight = 123,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            });
        }
    }
}
