using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC;

namespace GestionBoutiqueC.Entities
{
    public class Client:AbstractEntity
    {
        public int Id { get; set; } // Clé primaire
        public Client()
        {
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
       
        [Required(ErrorMessage = "Le surnom est obligatoire")]
        [StringLength(20, ErrorMessage = "Le surnom doit avoir au maximum 20 caractères")]
        public string Surnom { get; set; }

        [Required(ErrorMessage = "Le telephone est obligatoire")]
        [RegularExpression(@"^(77|78|76)[0-9]{7}$",ErrorMessage = "Le telephone doit etrre sous forme 77xxxxxxx ou 78xxxxxxx ou 76xxxxxxx")]
        public string Telephone { get; set; }
        
        public string Address { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Dette> Dettes { get;} = new List<Dette>();

    }
}
