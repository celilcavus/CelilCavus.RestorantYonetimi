namespace CelilCavus.RestorantYonetimi.Entites.Entites
{
    public class PersonelIsBilgileri
    {
        public int Id { get; set; }
        public string personelId { get; set; }
        public string personelTc { get; set; }
        public bool? personelCinsiyet { get; set; }
        public string personelTel1 { get; set; }
        public decimal? personelMaas { get; set; }
        public string PersonelAdres { get; set; }
    }
}
