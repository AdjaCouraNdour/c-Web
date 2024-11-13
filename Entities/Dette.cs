using System;
using System.Collections.Generic;
using GestionBoutiqueC.Enums;

namespace GestionBoutiqueC.Entities
{
    public class Dette : AbstractEntity
    {

        // Liste de détails et paiements
        // public virtual ICollection<Details> ListeDetails { get; set; } = new List<Details>();
        // public virtual ICollection<Paiement> ListePaiements { get; set; } = new List<Paiement>();
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Montant { get; set; }
        public double MontantVerse { get; set; }
        public double MontantRestant { get; set; }
        public Client Client { get; set; }
        public static int Nbr { get; set; }
        public int ClientId { get; set; }
        public Dette()
        {
            Date = DateTime.Now;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
        
        public TypeDette TypeDette { get; set ; }
        public EtatDette EtatDette { get; set ; }
    
        public virtual ICollection<Detail> Details { get;} = new List<Detail>();
        public virtual ICollection<Paiement> Paiements { get;} = new List<Paiement>();

    }
}