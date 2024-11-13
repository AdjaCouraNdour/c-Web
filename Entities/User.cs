using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GestionBoutiqueC;
using GestionBoutiqueC.Enums;

namespace GestionBoutiqueC.Entities
{
    public class User:AbstractEntity
    {
       public User()
        {
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Le login est obligatoire")]
        [StringLength(20, ErrorMessage = "Le  login doit avoir au maximum 20 caractères")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est obligatoire")]
        [StringLength(50, ErrorMessage = "L'email doit avoir au maximum 20 caractères")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le password est obligatoire")]
        public string Password { get; set; } = string.Empty;
        // public UserRole UserRole { get; set; }
        public bool Actif { get; set; } = true;

        // Propriété de navigation vers Client (relation 1-1)
        public UserRole UserRole { get; set; }

        public int? ClientId { get; set; }
        public Client? Client { get; set; }
       

    }
}
