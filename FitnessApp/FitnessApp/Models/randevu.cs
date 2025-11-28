using System;

namespace FitnessApp.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public string UyeAdSoyad { get; set; }
        public string Telefon { get; set; }
        public DateTime TarihSaat { get; set; }
        public string Durum { get; set; } = "Bekliyor";

        // İlişki: Hangi Eğitmen?
        public int EgitmenId { get; set; }
        public Egitmen Egitmen { get; set; }

        // İlişki: Hangi Hizmet?
        public int HizmetId { get; set; }
        public Hizmet Hizmet { get; set; }
    }
}