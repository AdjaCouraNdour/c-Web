using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC;
using GestionBoutiqueC.Enums;

namespace GestionBoutiqueC.Entities
{
    public class Article:AbstractEntity
    {
        public int Id { get; set; } // Clé primaire
        
         public Article()
        {
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
            Reference = $"A{Id:D5}";
        }

        [Required(ErrorMessage = "Le libelle est obligatoire")]
        public string Libelle { get ; set ; }
        public string Reference { get ; set ; }
        
        [Required(ErrorMessage = "Le prix est obligatoire")]
        public int Prix { get ; set ; }

        [Required(ErrorMessage = "Le libelle est obligatoire")]
        public double QteStock { get ; set ; }

        public EtatArticle EtatArticle { get ; set ; }
        public virtual ICollection<Detail> Details { get;} = new List<Detail>();

    }
}