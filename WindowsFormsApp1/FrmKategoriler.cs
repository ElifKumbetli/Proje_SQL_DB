using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete From TBLKATEGORI where KATEGORIID=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1",TxtKategoriId.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Silme İşlemi Gerçekleşti");
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ELIF;Initial Catalog=SatisVT;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select *From TBLKATEGORI", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBLKATEGORI(KATEGORIAD) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtKategoriAd.Text);
            komut2.ExecuteNonQuery();//Sorgudaki değişiklikleri v.tabanına yansıt
            baglanti.Close();//bağlantıyı kapat
            MessageBox.Show("Kategori Kaydetme İşlemi Başarıyla Gerçekleşti");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKategoriId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();


        }

        private void TtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update TBLKATEGORI set KATEGORIAD=@P1 where KATEGORIID=@p2",baglanti);
            komut4.Parameters.AddWithValue("@p1",TxtKategoriAd.Text);
             komut4.Parameters.AddWithValue("@p2", TxtKategoriId.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Güncelleme İşlemi Gerçekleşti");

        }

        private void FrmKategoriler_Load(object sender, EventArgs e)
        {

        }
    }
}


//Data Source=DESKTOP-ELIF;Initial Catalog=SatisVT;Integrated Security=True;Trust Server Certificate=True