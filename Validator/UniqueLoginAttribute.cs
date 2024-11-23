

using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionBoutiqueC.Validator
{
    public class UniqueLoginAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value ,ValidationContext validationContext)
        {
            var userService = (IUserModel)validationContext.GetService(typeof(IUserModel));
            var login = (string)value;
            
            if (userService.GetUsers().Any(c => c.Login == login))
            {
                return new ValidationResult("Cet Login est deja existant.");
            }
            
        return ValidationResult.Success;
        } 
    }
}