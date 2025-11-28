namespace FitnessApp.Models
{
    public class Egitmen
    {
        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public string? UzmanlikAlani { get; set; }
        public string? FotoUrl { get; set; }

        // İlişki: Hangi Salon?
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
    }
}