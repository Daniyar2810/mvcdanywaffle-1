using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace danywaffle.Domain;

public class Category
{
 
    public Guid Id { get; set; }
    [Display(Name="Kategori Adı")]
    [Required(ErrorMessage ="{0}Boş bırakılamaz")]
    public string Name { get; set; } = null!;
    [Display(Name = "Görsel")]
    public string? Image { get; set; }
    [NotMapped]
    [Display(Name = "Görsel")]
    public IFormFile? ImageFile { get; set; }

    public virtual ICollection<Product> Products { get; set; }= new HashSet<Product>();



}
