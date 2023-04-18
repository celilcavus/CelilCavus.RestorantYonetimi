namespace CelilCavus.RestorantYonetimi.Entites.Entites
{
    public class Menu
    {
        public int yemekId { get; set; }
        public string yemekAdi { get; set; }
        public decimal? yemekFiyati { get; set; }
        public string yemekTarifi { get; set; }
        public int? yemekKategoriId { get; set; }
    }
}
