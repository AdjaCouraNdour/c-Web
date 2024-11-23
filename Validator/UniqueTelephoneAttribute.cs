

using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionBoutiqueC.Validator
{
    public class UniqueTelephoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value ,ValidationContext validationContext)
        {
            var clientService = (IClientModel)validationContext.GetService(typeof(IClientModel));
            var telephone = (string)value;
            
            if (clientService.GetClients().Any(c => c.Telephone == telephone))
            {
                return new ValidationResult("Ce Telephone est deja existant.");
            }
         
        return ValidationResult.Success;
        } 
    }
}