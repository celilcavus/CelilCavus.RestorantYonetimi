namespace CelilCavus.RestorantYonetimi.Entites.Views
{
    public class ViewMenu
    {
        public int yemekId { get; set; }
        public string yemekAdi { get; set; }
        public decimal? yemekFiyati { get; set; }
        public string yemekTarifi { get; set; }
        public int? yemekKategoriId { get; set; }
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
    }
}
