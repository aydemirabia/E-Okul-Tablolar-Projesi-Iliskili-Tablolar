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
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=RABIA-AYDEMIR;Initial Catalog=E-Okul_Projesi;Integrated Security=True");


        DataSet1TableAdapters.tbl_notlarTableAdapter ds = new DataSet1TableAdapters.tbl_notlarTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtID.Text));
        }

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_dersler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbDers.DisplayMember = "dersAd";
            cbDers.ValueMember = "dersID";
            cbDers.DataSource = dt;
            baglanti.Close();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
            int s1, s2, s3;
            double ort;

        private void btnHesapla_Click(object sender, EventArgs e)
        {  
            s1 = Convert.ToInt32(txtSinav1.Text);
            s2 = Convert.ToInt32(txtSinav2.Text);
            s3 = Convert.ToInt32(txtSinav3.Text);

            ort = (s1 + s2 + s3) / 3;
            txtOrt.Text = ort.ToString();

            if (ort >= 45)
            {
                txtDurum.Text = "True";
            }
            else
            {
                txtDurum.Text = "False";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cbDers.SelectedValue.ToString()), int.Parse(txtID.Text), byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), double.Parse(txtOrt.Text), bool.Parse(txtDurum.Text),notid);
        }
    }
}
