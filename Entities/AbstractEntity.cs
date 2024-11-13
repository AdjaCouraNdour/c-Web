
namespace GestionBoutiqueC.Entities
{
    public class AbstractEntity
    {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}