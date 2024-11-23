

using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionBoutiqueC.Validator
{
    public class UniqueLibelleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value ,ValidationContext validationContext)
        {
            var articleService = (IArticleModel)validationContext.GetService(typeof(IArticleModel));
            var libelle = (string)value;
            
            if (articleService.GetArticles().Any(a => a.Libelle == libelle))
            {
                return new ValidationResult("Ce libelle est deja existant.");
            }
         
        return ValidationResult.Success;
        } 
    }
}