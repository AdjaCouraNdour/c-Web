using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC;

namespace GestionBoutiqueC.Entities
{
    public class Detail:AbstractEntity
    {
        public int Id { get; set; } // Clé primaire
        
         public Detail()
        {
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    

        // public int Id { get => Id; set => Id = value; }
        public double QteDette { get ; set; }
        public int DetteId { get ; set; }  
        public Dette Dette { get ; set ; }
        public int ArticleId { get ; set; }  
        public Article Article { get ; set; }
        public static int Nbr { get ; set ; }

    }
}