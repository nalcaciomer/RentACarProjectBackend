using System;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class CarImageDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}
