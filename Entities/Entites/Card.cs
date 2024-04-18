namespace Entities.Entites
{
    public class Card
    {
        public int Id { get; set; }
        public int IdPhoto { get; set; }
        public virtual Photo? Photo { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}
