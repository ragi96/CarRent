using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MongoDB.Entities;

namespace CarRent.InvoiceManagement.Application.Dto
{
    [ExcludeFromCodeCoverage]
    public class AddInvoiceDto
    {
        [Required] public string CarId { get; set; }
    }
}