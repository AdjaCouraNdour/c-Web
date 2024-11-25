using GestionBoutiqueC.Entities;


namespace GestionBoutiqueC.Entities
{
    public class ArticleDette
    {
        public int Id { get; set; } 
        public int Quantity { get; set; }  
        public int PrixUnitaire { get; set; }  
        public int ArticleId { get; set; }  
        public Article Article { get; set; } 
        public int DetteId { get; set; }  
        public Dette Dette { get; set; } 

    }
}