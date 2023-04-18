using CelilCavus.RestorantYonetimi.Entites.Entites;
using CelilCavus.RestorantYonetimi.Entites.Enums;
using CelilCavus.RestorantYonetimi.Model.Repository;


namespace CelilCavus.RestorantYonetimi.UIForm
{
    public partial class Form1 : Form
    {
        public int MenuId { get; set; }

        public int KategoriId { get; set; }

        public int MusteriId { get; set; }

        public int PersonelPozisyonId { get; set; }

        private readonly MenuRepository repository;

        private readonly KategoriRepository kategoriRepository;

        private readonly MusteriRepository musteriRepository;

        private readonly PersonelPozisyonRepository pozisyonRepository;
        public Form1()
        {
            InitializeComponent();
            repository = new MenuRepository(TableName.Menu);
            kategoriRepository = new KategoriRepository(TableName.YemekKategori);
            musteriRepository = new MusteriRepository(TableName.Musteri);
            pozisyonRepository = new PersonelPozisyonRepository(TableName.Personelpozisyon);
        }
        private async Task<List<Menu>> GetListAsync()
        {
            var values = await repository.GetListAsync();
            var list = menuBindingSource.DataSource = values;
            dataGridView1.DataSource = list;
            return values;
        }
        private async Task<List<YemekKategori>> GetComboboxKategoriList()
        {
            var values = await kategoriRepository.GetListAsync();
            var list = txtYemekKategori.DataSource = values;

            if (values is null)
            {
                return (List<YemekKategori>)Enumerable.Empty<YemekKategori>();
            }
            else
                dataGridView2.DataSource = list;
            return values;
        }

        private bool ClearAll(bool status = true)
        {
            if (status)
            {
                txtYemekAdi.Clear();
                txtYemekFiyati.Clear();
                txtYemekTarif.Clear();
                txtYemekKategori.Text = string.Empty;
            }
            return status;
        }
        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Menu menu = new()
                {
                    yemekAdi = txtYemekAdi.Text ?? "null",
                    yemekFiyati = decimal.Parse(txtYemekFiyati.Text),
                    yemekTarifi = txtYemekTarif.Text,
                    yemekKategoriId = int.Parse(txtYemekKategori.SelectedValue.ToString()!)
                };
                await repository.AddAsync(menu);
                await GetListAsync();
                ClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik Bir Hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                await repository.DeleteAsync(MenuId);
                await GetListAsync();
                ClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik Bir Hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Menu menu = new()
                {
                    yemekAdi = txtYemekAdi.Text ?? "null",
                    yemekFiyati = decimal.Parse(txtYemekFiyati.Text),
                    yemekTarifi = txtYemekTarif.Text,
                    yemekKategoriId = int.Parse(txtYemekKategori.SelectedValue.ToString()!)
                };
                await repository.UpdateAsync(menu, MenuId);
                await GetListAsync();
                ClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik Bir Hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await GetListAsync();
            await GetComboboxKategoriList();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MenuId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()!);
            txtYemekAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtYemekFiyati.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtYemekTarif.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtYemekKategori.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        /// <summary>
        /// Kategori
        /// </summary>
        /// <param name="GetKategoriListAsync">Kategori Listesini GridView'a aktarýyor</param>
        /// <param name="KategoriClearAll">Ýlgili Textboxlarýn temizliyor</param>
        /// <param name="btnKategoriEkle_Click">Kategori Ekliyor</param>
        /// <param name="btnKategoriSil_Click">Kategori Siliyor</param>
        /// <param name="btnKategoriGuncelle_Click">Kategori Güncelliyor</param>
        /// <param name="btnKategoriYenile_Click">Kategori Listesini Güncelliyor</param>
        /// <param name="dataGridView2_CellMouseClick">Grid'de seçili hücrenin verilerini textboxa aktrýyor.</param>

        private async Task<List<YemekKategori>> GetKategoriListAsync()
        {
            var values = await kategoriRepository.GetListAsync();
            var list = yemekKategoriBindingSource.DataSource = values;

            if (values is null)
            {
                return (List<YemekKategori>)Enumerable.Empty<YemekKategori>();
            }
            else
                dataGridView2.DataSource = list;
            return values;
        }

        private bool KategoriClearAll(bool status = true)
        {
            if (status)
            {
                txtKategoriAdi.Clear();
            }
            return status;
        }
        private async void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                YemekKategori yemekKategori = new()
                {
                    KategoriAdi = txtKategoriAdi.Text

                };
                await kategoriRepository.AddAsync(yemekKategori);
                await GetKategoriListAsync();
                KategoriClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik Bir Hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }

        }

        private async void btnKategoriSil_Click(object sender, EventArgs e)
        {
            try
            {
                await kategoriRepository.DeleteAsync(KategoriId);
                await GetKategoriListAsync();
                KategoriClearAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Bir Hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }
        }

        private async void btnKategoriGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                YemekKategori yemekKategori = new()
                {
                    KategoriAdi = txtKategoriAdi.Text

                };
                await kategoriRepository.UpdateAsync(yemekKategori, KategoriId);
                await GetKategoriListAsync();
                KategoriClearAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Bir Hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }
        }

        private async void btnKategoriYenile_Click(object sender, EventArgs e)
        {
            await GetKategoriListAsync();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            KategoriId = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()!);
            txtKategoriAdi.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }


        /// <summary>
        /// Muþteri
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private async Task<List<Musteri>> GetMusterisAsync()
        {
            var values = await musteriRepository.GetListAsync();
            var list = musteriBindingSource.DataSource = values;
            dataGridView3.DataSource = list;
            if (values is null)
            {
                return (List<Musteri>)Enumerable.Empty<List<Musteri>>();
            }
            return values;
        }
        private bool MusteriClearAll(bool status = true)
        {
            if (status)
            {
                txtMusteriAdi.Clear();
                txtMusteriSoyadi.Clear();
                txtMusteriAdres.Clear();
                txtMusteriTel.Clear();
            }
            return status;
        }
        private async void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri musteri = new()
                {
                    MusteriAdi = txtMusteriAdi.Text,
                    MusteriSoyadi = txtMusteriSoyadi.Text,
                    MusteriAdres = txtMusteriAdres.Text,
                    MusteriTel = txtMusteriTel.Text
                };
                await musteriRepository.AddAsync(musteri);
                await GetMusterisAsync();
                MusteriClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik bir hata oluþtur lütfen tekrar denermisiniz??", "Bilgi");
            }
        }

        private async void btnMusteriSil_Click(object sender, EventArgs e)
        {
            try
            {
                await musteriRepository.DeleteAsync(MusteriId);
                await GetMusterisAsync();
                MusteriClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik bir hata oluþtur lütfen tekrar denermisiniz??", "Bilgi");
            }
        }

        private async void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                Musteri musteri = new()
                {
                    MusteriAdi = txtMusteriAdi.Text,
                    MusteriSoyadi = txtMusteriSoyadi.Text,
                    MusteriAdres = txtMusteriAdres.Text,
                    MusteriTel = txtMusteriTel.Text
                };
                await musteriRepository.UpdateAsync(musteri, MusteriId);
                await GetMusterisAsync();
                MusteriClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik bir hata oluþtur lütfen tekrar denermisiniz??", "Bilgi");
            }
        }

        private async void btnMusteriYenile_Click(object sender, EventArgs e)
        {
            await GetMusterisAsync();
            MusteriClearAll();
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MusteriId = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString()!);
            txtMusteriAdi.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            txtMusteriSoyadi.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            txtMusteriAdres.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            txtMusteriTel.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
        }

        /// <summary>
        /// Personel Pozisyon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async Task<List<PersonelPozisyon>> GetPersonelPozisyonsAsync()
        {
            var values = await pozisyonRepository.GetListAsync();
            var list = personelPozisyonBindingSource.DataSource = values;
            dataGridView5.DataSource = list;
            if (values is null)
            {
                return (List<PersonelPozisyon>)Enumerable.Empty<PersonelPozisyon>();
            }
            return values;
        }
        private bool PersonelPozClearAll(bool status = true)
        {
            if (status)
            {
                txtPersonelPozAdi.Clear();
            }
            return status;
        }

        private async void btnPersPoziEkle_Click(object sender, EventArgs e)
        {
            try
            {
                PersonelPozisyon pers = new()
                {
                    persPozisyonAdi = txtPersonelPozAdi.Text
                };
                await pozisyonRepository.AddAsync(pers);
                await GetPersonelPozisyonsAsync();
                PersonelPozClearAll();

            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik bir hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }
        }

        private async void btnPersPozSil_Click(object sender, EventArgs e)
        {
            try
            {

                await pozisyonRepository.DeleteAsync(PersonelPozisyonId);
                await GetPersonelPozisyonsAsync();
                PersonelPozClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik bir hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }
        }
        private async void btnPersPozGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                PersonelPozisyon pers = new()
                {
                    persPozisyonAdi = txtPersonelPozAdi.Text
                };
                await pozisyonRepository.UpdateAsync(pers, PersonelPozisyonId);
                await GetPersonelPozisyonsAsync();
                PersonelPozClearAll();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik bir hata oluþtu lütfen tekrar denermisiniz?", "Bilgi");
            }
        }
        private async void btnPersPozYenile_Click(object sender, EventArgs e)
        {
            await GetPersonelPozisyonsAsync();
            PersonelPozClearAll();
        }

        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PersonelPozisyonId = int.Parse(dataGridView5.CurrentRow.Cells[0].Value.ToString()!);
            txtPersonelPozAdi.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
        }
    }
}