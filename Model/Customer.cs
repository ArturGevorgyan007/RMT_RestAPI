using System.ComponentModel.DataAnnotations;
namespace Model;

public class Customer
{
    [Required(ErrorMessage = "First Name is required")]
    public string? firstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    public string? lastName { get; set; }

    [Range(18, Int32.MaxValue,ErrorMessage = "Age must be greater than 18")]
    [Required(ErrorMessage = "Age is required")]
    public int age { get; set; }

    [Required(ErrorMessage = "Id is required")]
    public int id { get; set; }
}
