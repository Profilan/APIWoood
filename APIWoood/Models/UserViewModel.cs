using APIWoood.Logic.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIWoood.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ApiKey { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string AllowedIP { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }
        public Role UserRole { get; set; }

        [Display(Name = "Debtors")]
        public IList<string> SelectedDebtors { get; set; }
    }
}