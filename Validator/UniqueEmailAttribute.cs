

using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionBoutiqueC.Validator
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value ,ValidationContext validationContext)
        {
            var userService = (IUserModel)validationContext.GetService(typeof(IUserModel));
            var email = (string)value;
            
            if (userService.GetUsers().Any(c => c.Email == email))
            {
                return new ValidationResult("Cet Email est deja existant.");
            }
            
        return ValidationResult.Success;
        } 
    }
}