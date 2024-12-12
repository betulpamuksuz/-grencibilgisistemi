using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BilgiSistem
{
    public partial class btnGoster : Form
    {
        public btnGoster()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string numara = txtNo.Text;

            // SQL bağlantı dizesi
            string connectionString = "Server=localhost;Database=BilgiSistemDB;Integrated Security=True;";

            // Veritabanına veri ekleme SQL sorgusu
            string query = "INSERT INTO Ogrenciler (Ad, Soyad, Numara) VALUES (@Ad, @Soyad, @Numara)";

            try
            {
                // Bağlantıyı oluştur
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL komutunu oluştur
                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreler ile SQL sorgusunu güvenli hale getir
                    command.Parameters.AddWithValue("@Ad", ad);
                    command.Parameters.AddWithValue("@Soyad", soyad);
                    command.Parameters.AddWithValue("@Numara", numara);

                    // Bağlantıyı aç
                    connection.Open();

                    // Komutu çalıştır (veriyi ekle)
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
