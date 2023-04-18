namespace CelilCavus.RestorantYonetimi.Entites.Entites
{
    public class Personel
    {
        public int persId { get; set; }
        public string persAdi { get; set; }
        public string persSoyadi { get; set; }
        public int? persPozisyonId { get; set; }
        public Guid persIsBilgileriId { get; set; }
    }
}
