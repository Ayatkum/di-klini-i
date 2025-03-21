using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dişkliniği
{
    public partial class Tedavi : Form
    {
        public Tedavi()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string query = "insert into TedaviTbl values('" + TedaviAdiTb.Text + "','" + TutarTb.Text + "','" + AciklamaTb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Tedavi Başarıyla Eklendi");
                uyeler();
                Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Reset()
        {
            TedaviAdiTb.Text = "";
            TutarTb.Text = "";
            AciklamaTb.Text = "";
        }

        private void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from TedaviTbl";
            DataSet ds = Hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }

        int key = 0;
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek Tedaviyi Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Update TedaviTbl set TAd = '" + TedaviAdiTb.Text + "',TUcret = '" + TutarTb.Text + "',TAciklama = '" + AciklamaTb.Text + "' where TId = " + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi Başarıyla Güncellendi.");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Tedaviyi Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Delete from TedaviTbl where TId = " + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi Başarıyla Silindi.");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Tedavi_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();

            // Başlık stilini değiştirme
            TedaviDGV.EnableHeadersVisualStyles = false; // Varsayılan temayı devre dışı bırak
            TedaviDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Cascadia Mono", 12, FontStyle.Bold); // Yeni font

            TedaviDGV.DefaultCellStyle.Font = new Font("Cascadia Mono", 10, FontStyle.Regular);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TedaviDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tedavi_Load_1(object sender, EventArgs e)
        {
            uyeler();
            Reset();

            // Başlık stilini değiştirme
            TedaviDGV.EnableHeadersVisualStyles = false; // Varsayılan temayı devre dışı bırak
            TedaviDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Cascadia Mono", 12, FontStyle.Bold); // Yeni font

            TedaviDGV.DefaultCellStyle.Font = new Font("Cascadia Mono", 10, FontStyle.Regular);
        }

        private void TedaviDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TedaviAdiTb.Text = TedaviDGV.SelectedRows[0].Cells[1].Value.ToString();
            TutarTb.Text = TedaviDGV.SelectedRows[0].Cells[2].Value.ToString();
            AciklamaTb.Text = TedaviDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (TedaviAdiTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TedaviDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
