using System;
using System.ComponentModel.DataAnnotations;

namespace StockChat.Entities
{
    public class UserRegisterAuthenticate: UserAuthenticate
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

    }
}
