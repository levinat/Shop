﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Shop.Core.Dtos
{
    public class SpaceshipDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public int EnginePower { get; set; }
        public string Country { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifieAt { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<ExistingFilePathDto> ExistingFilePaths { get; set; }
            = new List<ExistingFilePathDto>();
    }
}