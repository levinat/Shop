using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Shop.Core.Dtos
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<ExistingFilePathDto> ExistingFilePaths { get; set; }
            = new List<ExistingFilePathDto>();
    }
}