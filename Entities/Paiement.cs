using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC;

namespace GestionBoutiqueC.Entities
{
    public class Paiement:AbstractEntity
    {
        public int Id { get; set; } // Clé primaire
        public DateTime Date { get ; set ; }
        public int DetteId { get ; set; }  
        public Dette Dette { get ; set ; }

        [Required(ErrorMessage = "Le montant est obligatoire")]
        public double Montant { get ; set ; }

        public Paiement()
        {
            Date = DateTime.Now;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}