using System.ComponentModel.DataAnnotations;

namespace BLM4581Mvc.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(50)]
        [Display(Name = "Kategori")]
        public string Ad { get; set; } = "";

        public List<Kitap> Kitaplar { get; set; } = new();
    }
}
