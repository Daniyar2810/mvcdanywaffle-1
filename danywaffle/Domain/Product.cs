using Stripe;
using System.ComponentModel.DataAnnotations;

namespace danywaffle.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "{0}Boş bırakılamaz")]
        public string Name { get; set; } = null!;
     
        public string? Image { get; set; }

        public decimal Price { get; set; }
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; } 
             
    }
}
