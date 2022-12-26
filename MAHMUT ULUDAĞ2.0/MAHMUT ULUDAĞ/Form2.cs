using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MAHMUT_ULUDAĞ
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = txt1.Text;
            textBox2.Text = txt2.Text;
            textBox3.Text = txt3.Text;
            textBox4.Text = txt4.Text;
        }
        string yenı;
        private void Form2_Load(object sender, EventArgs e)
        {
            yenı = textBox1.Text;
        }
        public DataGridView data;
        #region baglantı
        static string conmu = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\data\\mu.veritabanı.mdb";
        OleDbConnection baglantı = new OleDbConnection(conmu);
        OleDbCommand komut = new OleDbCommand();
        #endregion
        #region txt
        Form1 frm = new Form1();
        public TextBox txt1
        { set { txt1 = value; } get { return textBox1; } }
        public TextBox txt2
        {
            set { txt2 = value; }
            get { return textBox2; }
        }
        public TextBox txt3
        {
            set { txt3 = value; }
            get { return textBox3; }
        }
        public TextBox txt4
        {
            set { txt4 = value; }
            get { return textBox4; }
        }

        public int mu;
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            if (mu==1)
            {
                ekle();
            }
            else if (mu == 2)
            {
                guncelle();
            }
            frm.goruntule(data, "muveritabanı");
            this.Close(); 
        }
        #region ekle
        private void ekle()
        {
            string uludag = "insert into muveritabanı (ÜRÜNADI, FİYAT,KAR,STOK) values ('" +
                  textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"
                  + textBox4.Text + "')";
            try
            {
                if (baglantı.State != ConnectionState.Open)
                {
                    baglantı.Open();
                }
                komut.CommandText = uludag;
                komut.Connection = baglantı;
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Yeni kayıt eklendi..!");

            }
            catch (Exception u)
            {
                MessageBox.Show(u.ToString());
                baglantı.Close();
            }

        }
        #endregion
        #region guncelle
        private void guncelle()
        {

            string uludag = "UPDATE muveritabanı SET ÜRÜNADI='" + textBox1.Text +
                "',FİYAT='" + textBox2.Text + "',KAR='" + textBox3.Text +
                "',STOK='" + textBox4.Text + "' WHERE ÜRÜNADI='" +yenı  + "'";

            try
            {
                if (baglantı.State != ConnectionState.Open) baglantı.Open();
                komut = new OleDbCommand(uludag, baglantı);
                komut.ExecuteNonQuery();
                MessageBox.Show("Veri Güncellemesi Yapıldı");
                baglantı.Close();
            }
            catch (Exception u)
            {
                MessageBox.Show(u.ToString());
                baglantı.Close();
            }
        }
        #endregion
     
    }
}
