using System.Diagnostics.CodeAnalysis;

namespace CarRent.CarManagement.Application.Dto.CarClassDto
{
    [ExcludeFromCodeCoverage]
    public class GetCarClassDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int DailyPrice { get; set; }
    }
}