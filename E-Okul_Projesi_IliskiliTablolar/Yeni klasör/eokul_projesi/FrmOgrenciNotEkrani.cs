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
    public partial class FrmOgrenciNotEkrani : Form
    {
        public FrmOgrenciNotEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=RABIA-AYDEMIR;Initial Catalog=E-Okul_Projesi;Integrated Security=True"); 
        public string numara;
        private void FrmOgrenciNotEkrani_Load(object sender, EventArgs e)
        {
            /*SqlCommand komut = new SqlCommand("select * from tbl_notlar where ogrID=@ogrid", baglanti);
            komut.Parameters.AddWithValue("@ogrid", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/

            SqlCommand komut2 = new SqlCommand("select dersAd,sinav1,sinav2,sinav3,ortalama,durum from tbl_notlar inner join tbl_dersler on tbl_notlar.dersID = tbl_dersler.dersID where ogrID=@ogrid", baglanti);
            komut2.Parameters.AddWithValue("@ogrid", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter daNotDers = new SqlDataAdapter(komut2);
            DataTable dtNotDers = new DataTable();
            daNotDers.Fill(dtNotDers);
            dataGridView1.DataSource = dtNotDers;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    
