using System.ComponentModel.DataAnnotations;

namespace Store.Endpoints.ShopUI.Models;

public class CheckoutViewModel
{
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string City { get; set; } = "";
    [Required]
    public string Address { get; set; } = "";
}
