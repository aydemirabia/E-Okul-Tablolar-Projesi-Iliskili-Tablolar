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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=RABIA-AYDEMIR;Initial Catalog=E-Okul_Projesi;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxKulup.DisplayMember = "kulupAd";
            comboBoxKulup.ValueMember = "kulupID";
            comboBoxKulup.DataSource = dt;
            baglanti.Close();
        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (radioButtonKiz.Checked == true)
            {
                c = "Kız";
            }
            if (radioButtonErkek.Checked == true)
            {
                c = "Erkek";
            }
            ds.OgrenciEkle(txtogrAd.Text, txtogrSoyad.Text, byte.Parse(comboBoxKulup.SelectedValue.ToString()), c);
            
            MessageBox.Show("Öğrenci ekleme işlemi yapıldı.");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds;
        }

        private void comboBoxKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtogrId.Text = comboBoxKulup.SelectedValue.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtogrId.Text));
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtogrId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtogrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtogrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBoxKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.Equals("Kız"))
            {
                radioButtonKiz.Checked = true;
            }
            else
            {
                radioButtonKiz.Checked=false;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.Equals("Erkek"))
            {
                radioButtonErkek.Checked = true;
            }
            else
            {
                radioButtonErkek.Checked = false;
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtogrAd.Text, txtogrSoyad.Text, byte.Parse(comboBoxKulup.SelectedValue.ToString()), c, int.Parse(txtogrId.Text));
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        /*private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciGetir(int.Parse(txtAra.Text));
        }*/
    }
}
