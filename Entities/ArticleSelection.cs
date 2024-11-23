using GestionBoutiqueC.Entities;


namespace GestionBoutiqueC.Entities
{
    public class ArticleSelection
    {
        public int ArticleId { get; set; }  // Référence à l'ID de l'article
        public int Quantity { get; set; }   // Quantité sélectionnée
        public Article Article { get; set; } // L'objet Article lui-même pour accéder aux autres détails

        // Parfois, vous pouvez calculer des informations supplémentaires comme le prix total
    }
}