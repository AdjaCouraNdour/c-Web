

using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionBoutiqueC.Validator
{
    public class UniqueSurnomAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value ,ValidationContext validationContext)
        {
            var clientService = (IClientModel)validationContext.GetService(typeof(IClientModel));
            var surnom = (string)value;
            
            if (clientService.GetClients().Any(c => c.Surnom == surnom))
            {
                return new ValidationResult("Ce surnom est deja existant.");
            }
         
        return ValidationResult.Success;
        } 
    }
}