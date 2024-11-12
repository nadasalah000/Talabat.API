using System.ComponentModel.DataAnnotations;
using Talabat.Core.Entites.identity;

namespace Talabat.API.DTOs
{
    public class OrderDto
    {
        [Required]
        public string BasketId { get; set; }
        [Required]
        public int DeliveryMethodId { get; set; }
        [Required]
        public AddressDto ShippingAddress { get; set; }
    }
}
