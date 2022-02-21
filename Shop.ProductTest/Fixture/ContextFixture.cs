using Shop.ProductTest.Mock.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ProductTest.Fixture
{
    public class ContextFixture : IDisposable
    {
        public TestDbContextMock _testDbContextMock;


       // public ContextFixture()
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
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ContextFixture()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (true)
                {
                    _testDbContextMock.Dispose();
                    _testDbContextMock = null;
                }
            }
        }
    }
}
