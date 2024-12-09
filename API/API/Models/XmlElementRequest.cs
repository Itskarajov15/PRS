using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class XmlElementRequest
{
    [Required]
    public string ElementName { get; set; } = String.Empty;

    [Required]
    public string ElementValue { get; set; } = String.Empty;
}