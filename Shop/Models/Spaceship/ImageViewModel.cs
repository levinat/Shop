using System;

namespace Shop.Models.Spaceship
{
    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public string ImageId { get; set; }
        public byte[] ImageData { get; set; } 
        public string Image { get; set; }
        public Guid SpaceshipId { get; set; }


    }
}
