using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain
{
    public class Car
    {
        public Guid? Id { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public IEnumerable<ExistingFilePath> ExistingFilePaths { get; set; }
    = new List<ExistingFilePath>();
    }
}