using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientReservasi_082
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Form1()
        {
            InitializeComponent();

            TampilData();
            btUpdate.Enabled = false;
            btHapus.Enabled = false;
        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;
            string NamaCustomer = textBoxNama.Text;
            string NoTelpon = textBoxNoTelfon.Text;
            int JmlPemesanan = int.Parse(textBoxJumlah.Text);
            string IdLokasi = textBoxIDLokasi.Text;

            var a = service.pemesanan(IDPemesanan, NamaCustomer, NoTelpon, JmlPemesanan, IdLokasi);

            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;
            string NamaCustomer = textBoxNama.Text;
            string NoTelpon = textBoxNoTelfon.Text;

            var a = service.editPemesanan(IDPemesanan, NamaCustomer, NoTelpon);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBoxID.Text;

            var a = service.deletePemesanan(IDPemesanan);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        public void TampilData()
        {
            var List = service.Pemesanan1();
            dtPemesanan.DataSource = List;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            textBoxID.Clear();
            textBoxNama.Clear();
            textBoxNoTelfon.Clear();
            textBoxJumlah.Clear();
            textBoxIDLokasi.Clear();

            textBoxJumlah.Enabled = true;
            textBoxIDLokasi.Enabled = true;

            btSimpan.Enabled = true;
            btUpdate.Enabled = false;
            btHapus.Enabled = false;

            textBoxID.Enabled = true;
        }

        private void dtPemesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[0].Value);
           
            textBoxJumlah.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[1].Value);
            textBoxIDLokasi.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[2].Value);
            textBoxNama.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[3].Value);
            textBoxNoTelfon.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[4].Value);

            textBoxJumlah.Enabled = false;
            textBoxIDLokasi.Enabled = false;

            btUpdate.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            textBoxID.Enabled = false;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Login fm1 = new Login();
            this.Hide();
            fm1.Show();
        }
    }
}
