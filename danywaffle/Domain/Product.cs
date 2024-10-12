using Stripe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace danywaffle.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "{0}Boş bırakılamaz")]
        public string Name { get; set; } = null!;
        [Display(Name = "Görsel")]
        public string? Image { get; set; }
        [NotMapped]
        [Display(Name = "Görsel")]
        public IFormFile? ImageFile { get; set; }


        [Display(Name = "Fiyat")]
       
        public decimal Price { get; set; }
        [Display(Name = "Açiklama")]
     
        public string? Description { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "{0}Boş bırakılamaz")]
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; } 
             
    }
}
