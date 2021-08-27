using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarRent.Common.Application.Dto
{
    [ExcludeFromCodeCoverage]
    public class FuzzySearchTerm
    {
        [Required] public string Term { get; set; }
    }
}