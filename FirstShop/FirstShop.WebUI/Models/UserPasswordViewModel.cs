using System.ComponentModel.DataAnnotations;

namespace FirstShop.WebUI.Models
{
    public class UserPasswordViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " Eski şifre alanı boş bırakılamaz.")]
        public string CurrentPassword {  get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        public string Password { get; set; }

       
        [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakılamaz.")]
        [Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmiyor.")]
        public string PasswordConfirm { get; set; }
    }
}

