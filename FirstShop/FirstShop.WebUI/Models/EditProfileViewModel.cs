using System.ComponentModel.DataAnnotations;

namespace FirstShop.WebUI.Models
{
    public class EditProfileViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        [MaxLength(25)]
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [MaxLength(25)]
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        public string LastName { get; set; }

        [Display(Name = "Eposta")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Eposta alanı boş bırakılamaz.")]
        public string Email { get; set; }

    }
}
