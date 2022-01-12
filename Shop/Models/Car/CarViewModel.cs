using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Car
{
    public class CarViewModel
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
        public List<ExistingFilePathViewModel> ExistingFilePaths { get; set; } = new List<ExistingFilePathViewModel>();
    }
    public class ExistingFilePathViewModel
    {
        public Guid PhotoId { get; set; }
        public string FilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}