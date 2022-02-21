using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ProductTest.Mock.Entities
{
    public partial class TestDbContextMock : ShopDbContext
    {

        public TestDbContextMock(DbContextOptions<ShopDbContext> options)
             : base(options) { }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /**
             * At this stage, a copy of the actual database is created as a memory database.
             * You do not need to create a separate test database.
             */
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
        }
    }
}
