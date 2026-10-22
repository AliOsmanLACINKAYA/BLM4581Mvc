using System.ComponentModel.DataAnnotations;

namespace BLM4581Mvc.Models
{
    public class Kitap
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter.")]
        [Display(Name = "Kitap Adı")]
        public string Ad { get; set; } = "";

        [Required(ErrorMessage = "Yazar zorunludur.")]
        [Display(Name = "Yazar")]
        public string Yazar { get; set; } = "";
        [Required(ErrorMessage = "Basım yılı zorunludur.")]
        [Range(1450, 2100, ErrorMessage = "Basım yılı 1450-2100 olmalı.")]
        [Display(Name = "Basım Yılı")]
        public int? BasimYili { get; set; }

        [Required(ErrorMessage = "Sayfa sayısı zorunludur.")]
        [Range(1, 10000, ErrorMessage = "Sayfa sayısı 1-10000 olmalı.")]
        [Display(Name = "Sayfa Sayısı")]
        public int? SayfaSayisi { get; set; }

        [Required(ErrorMessage = "Kategori seçiniz.")]
        [Display(Name = "Kategori")]
        public int? KategoriId { get; set; }

        public Kategori? Kategori { get; set; }
    }
}
