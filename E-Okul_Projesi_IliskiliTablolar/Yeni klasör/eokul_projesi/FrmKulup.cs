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
namespace eokul_projesi
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=RABIA-AYDEMIR;Initial Catalog=E-Okul_Projesi;Integrated Security=True");
        void listele()
        {
            //listeleme
            SqlDataAdapter daList = new SqlDataAdapter("select * from tbl_kulupler", baglanti);
            DataTable dtList = new DataTable();
            daList.Fill(dtList);
            dataGridView1.DataSource = dtList;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutEkle = new SqlCommand("insert into tbl_kulupler (kulupAd) values (@kulup)", baglanti);
            komutEkle.Parameters.AddWithValue("@kulup", txtkulupAd.Text);
            komutEkle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("delete from tbl_kulupler where kulupID=@kulupid", baglanti);
            komutSil.Parameters.AddWithValue("@kulupid", txtkulupID.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp silme işlemi gerçekleşti.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("update tbl_kulupler set kulupAd=@kulupad where kulupId=@kulupid", baglanti);
            komutGuncelle.Parameters.AddWithValue("@kulupad", txtkulupAd.Text);
            komutGuncelle.Parameters.AddWithValue("@kulupid", txtkulupID.Text);
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işleminiz gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }
    }
}
