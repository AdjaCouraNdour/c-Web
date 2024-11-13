using System;
using System.Collections.Generic;

namespace GestionBoutiqueC.Entities
{
    public class Dette : AbstractEntity
    {

        // private DateTime date;
        // private double montant;
        // private double montantVerse;
        // private double montantRestant;
        // // private TypeDette typeDette;
        // // private EtatDette etatDette;
        // private bool archiver;
        // private Client client;
        // private static int nbr;

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
        
        // public TypeDette TypeDette { get => typeDette; set => typeDette = value; }
        // public EtatDette EtatDette { get => etatDette; set => etatDette = value; }
      

        // public void AddDetails(Details details)
        // {
        //     details.Dette = this;
        //     ListeDetails.Add(details);
        // }

        // public void AddPaiement(Paiement paiement)
        // {
        //     this.montantRestant = this.montantRestant - this.montantVerse;
        //     if (this.montantVerse == this.montant)
        //     {
        //         this.montantRestant = 0;
        //         this.typeDette = TypeDette.Solde;
        //     }
        //     else
        //     {
        //         this.typeDette = TypeDette.nonSolde;
        //     }
        //     ListePaiements.Add(paiement);
        // }


    }
}