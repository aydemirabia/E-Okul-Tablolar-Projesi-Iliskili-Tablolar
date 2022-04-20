using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eokul_projesi
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_derslerTableAdapter dsDersler = new DataSet1TableAdapters.tbl_derslerTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dsDersler.DersListesi();
        
        
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            dsDersler.DersEkle(txtdersAd.Text);
            MessageBox.Show("Ders Eklendi.");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dsDersler.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            dsDersler.DersSil(byte.Parse(txtdersID.Text));
            MessageBox.Show("Ders silme işleminiz gerçekleşti.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dsDersler.DersGuncelle(txtdersAd.Text,byte.Parse(txtdersID.Text));
            MessageBox.Show("Ders güncelleme işleminiz gerçekleşti.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
