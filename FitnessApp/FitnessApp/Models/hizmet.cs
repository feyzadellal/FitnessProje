namespace FitnessApp.Models
{
    public class Hizmet
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public int SureDk { get; set; }
        public decimal Ucret { get; set; }

        // İlişki: Hangi Salon?
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
    }
}