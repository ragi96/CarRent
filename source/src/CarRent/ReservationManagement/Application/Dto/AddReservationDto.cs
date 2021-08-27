using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MongoDB.Entities;

namespace CarRent.ReservationManagement.Application.Dto
{
    [ExcludeFromCodeCoverage]
    public class AddReservationDto
    {
        [Required] public string Customer { get; set; }
        [Required] public string WishCar { get; set; }
        [Required] public string CarClass { get; set; }
        [Required] public Date StartDate { get; set; }
        [Required] public Date EndDate { get; set; }
    }
}