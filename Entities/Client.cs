using System;
using System.Collections.Generic;
using GestionBoutiqueC;

namespace GestionBoutiqueC.Entities
{
    public class Client:AbstractEntity
    {
        public int Id { get; set; } // Clé primaire

        public string Surnom { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }


    }
}
