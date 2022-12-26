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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            label1.Text = "0"; label2.Text = "";
            toolStripStatusLabel2.Text = " 193302025  MAHMUT ULUDAĞ ";
           
        }
        static string conmu = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
            Application.StartupPath + "\\data\\mu.veritabanı.mdb";


        OleDbConnection baglantı = new OleDbConnection(conmu);
        OleDbCommand komut = new OleDbCommand();
        private void Form1_Load(object sender, EventArgs e)
        {
            goruntule(dataGridView1, "muveritabanı");
        }

        #region UYGULAMA1
        #region goruntuleme 
        public void goruntule(DataGridView data,string ad)
        {
                string sqlKomut = "select * from "+ ad;
                DataTable dt = new DataTable();

                if (baglantı.State != ConnectionState.Open)
                {
                    baglantı.Open();
                }
                komut.CommandText = sqlKomut;
                komut.Connection = baglantı;
                OleDbDataAdapter da = new OleDbDataAdapter(komut);
                da.Fill(dt);
                data.DataSource = dt;
                baglantı.Close();  
        }
        #endregion  
        private void button3_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.CurrentCell.RowIndex;
            string del= dataGridView1.Rows[secilen].Cells["ÜRÜNADI"].FormattedValue.ToString();
            string sqlKomut = "Delete From muveritabanı where ÜRÜNADI='" +del +"'";
            try
            {
                DialogResult dg = MessageBox.Show("Kayıt Silinsin mi?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    if (baglantı.State != ConnectionState.Open) baglantı.Open();
                    komut = new OleDbCommand(sqlKomut, baglantı);
                    komut.ExecuteNonQuery();
                    goruntule(dataGridView1, "muveritabanı");
                    MessageBox.Show("Silme İşlemi Gerçekleştirildi");
                    baglantı.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                baglantı.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.data = dataGridView1;
            frm2.mu = 1;
            frm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.data = dataGridView1;
            frm2.mu = 2;
            frm2.txt1.Text = textbox1;
            frm2.txt2.Text = textbox2;
            frm2.txt3.Text = textbox3;
            frm2.txt4.Text = textbox4;
            frm2.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.CurrentCell.RowIndex;
            string girişfiyat= dataGridView1.Rows[secilen].Cells["FİYAT"].FormattedValue.ToString();
            string kar = dataGridView1.Rows[secilen].Cells["KAR"].FormattedValue.ToString();

            float sonuc = float.Parse(girişfiyat)*(1+float.Parse(kar)/100) * 1.18f;
            label8.Text ="SEÇİLEN ÜRÜNÜN SATIŞ FİYATI "+ sonuc.ToString();


        }
        public string textbox1, textbox2, textbox3, textbox4;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            textbox1 = dataGridView1.Rows[selectedIndex].Cells["ÜRÜNADI"].FormattedValue.ToString();
            textbox2 = dataGridView1.Rows[selectedIndex].Cells["FİYAT"].FormattedValue.ToString();
            textbox3 = dataGridView1.Rows[selectedIndex].Cells["KAR"].FormattedValue.ToString();
            textbox4 = dataGridView1.Rows[selectedIndex].Cells["STOK"].FormattedValue.ToString();
        }
        #endregion
        #region UYGULAMA 2
        #region timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }
        #endregion
        Random rd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {

            label1.Text = "0"; label2.Text = "";
            ğ = 0;
            sa();
            DateTime t = DateTime.Now;
            string s = t.ToLongTimeString();
            toolStripStatusLabel1.Text = "Saat: " + s;
            k = 0;
           
        }
        #region sa metotu
        void sa()
        {
            int[] dizi = new int[40];
            f(dizi);
            flowLayoutPanel1.Controls.Clear();
            for (int i = 1; i < 101; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Height = 20;
                btn.Click += Btn_Click;
                for (int j = 0; j < 40; j++)
                {
                    if (dizi[j] == i)
                    {
                        btn.Tag = "mayın";
                        ğ++;
                        label2.Text = ğ.ToString();
                    }
                }
                btn.Width = 40;
                btn.Height = 40;
                btn.BackColor = Color.Blue;
                flowLayoutPanel1.Controls.Add(btn);
            }

        }
        #endregion
        #region f metotu
        void f(int[] dizi)
        {
            int[] mu = new int[40];
            if (radioButton1.Checked == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    dizi[i] = rd.Next(1, 101);
                    int j = 0;
                    while (j < i + 1)
                    {
                        if (mu[j] == dizi[i])
                        {
                            dizi[i] = rd.Next(1, 101);
                            j = 0;
                            continue;
                        }
                        j++;
                    }
                    mu[i] = dizi[i];
                }
            }
            if (radioButton2.Checked == true)
            {
                for (int i = 0; i < 25; i++)
                {
                    dizi[i] = rd.Next(1, 101);
                    int j = 0;
                    while (j < i + 1)
                    {
                        if (mu[j] == dizi[i])
                        {
                            dizi[i] = rd.Next(1, 101);
                            j = 0;
                            continue;
                        }
                        j++;
                    }
                    mu[i] = dizi[i];
                }
            }


            if (radioButton3.Checked == true)
            {
                for (int i = 0; i < 40; i++)
                {
                    dizi[i] = rd.Next(1, 101);
                    int j = 0;
                    while (j < i + 1)
                    {
                        if (mu[j] == dizi[i])
                        {
                            dizi[i] = rd.Next(1, 101);
                            j = 0;
                            continue;
                        }
                        j++;
                    }
                    mu[i] = dizi[i];
                }
            }
        }
        #endregion
        bool alfa = false;
        int ğ = 1;
        #region btn_click
        private void Btn_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;


            if (btn.Tag == "mayın")
            {

                btn.BackgroundImage = Properties.Resources.mayin;
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                MessageBox.Show("   --> GAME OVER <-- " + "\n TOPLAM PUANINIZ  " + label1.Text);
               
                for (int i = 1; i <= 100; i++)
                {
                    Button mu = (Button)(flowLayoutPanel1.Controls.Find(i.ToString(), true)[0]);
                    if (mu.Tag == "mayın")
                    {

                        mu.BackgroundImage = Properties.Resources.mayin;
                        mu.BackgroundImageLayout = ImageLayout.Zoom;


                    }
                    else
                    {
                        mu.BackColor = Color.Green;
                    }

                    mu.Enabled = false;
                    groupBox1.Enabled = true;
                }
                if (label1.Text!="0")
                {
                    DialogResult dg = MessageBox.Show("SKORUNUZU KAYDETMEK İSTERMİSİNİZ", "KAYDET", MessageBoxButtons.YesNo);
                    if (dg == DialogResult.Yes)
                    {
                        alfa = true;
                        k = 0;
                        button6.PerformClick();
                    
                    }
                }
               
            }
            else
            {
                int a = rd.Next(1, ğ);
                btn.Text = a.ToString();
                btn.BackColor = Color.Green;

                int b;
                if (label1.Text == "")
                {
                    b = a;
                }
                else
                {
                    b = int.Parse(label1.Text) + a;
                } 
                label1.Text = b.ToString();
                btn.Enabled = false;
            }
        }


        #endregion

        #endregion
        #region ekstra
        TextBox textBox5 = new TextBox();
        Label label5 = new Label();
        Label label6 = new Label();
        Label label7 = new Label();
        Button button5 = new Button();
        Button buttoniptal = new Button();
        DataGridView dataview = new DataGridView();
        #region olustur
        void olustur()
        {
            #region dataview
            dataview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            panel3.Controls.Add(dataview);
            dataview.Location = new System.Drawing.Point(3, 3);
            dataview.Name = "dataview";
            dataview.Size = new Size(265, 185);
            goruntule(dataview, "mayın");
            #endregion
            if (label1.Text!="0")
            {
                #region textbox5
                textBox5.Location = new Point(92, 45);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 20);
            textBox5.TabIndex = 16;
            panel2.Controls.Add(textBox5);
                #endregion
                #region label5
            label5.AutoSize = true;
            label5.Location = new Point(25, 50);
            label5.Name = "label5";
            label5.Size = new Size(35, 13);
            label5.TabIndex = 17;
            label5.Text = "İSİMİNİZ";
            panel2.Controls.Add(label5);
            #endregion
                #region label6
            label6.AutoSize = true;
            label6.Location = new Point(25, 80);
            label6.Name = "label6";
            label6.Size = new Size(60, 13);
            label6.TabIndex = 17;
            label6.Text = "SKORUNUZ";
            panel2.Controls.Add(label6);

            #endregion
                #region label7
            label7.AutoSize = true;
            label7.Location = new Point(121, 80);
            label7.Name = "label7";
            label7.Size = new Size(35, 13);
            label7.TabIndex = 17;
            label7.Text = label1.Text;
            panel2.Controls.Add(label7);

                #endregion
                #region button5

                button5.Location = new Point(28, 119);
                button5.Name = "button5";
                button5.Size = new Size(75, 25);
                button5.TabIndex = 18;
                button5.Text = "KAYDET";
                button5.UseVisualStyleBackColor = true;
                button5.Click += button5_Click;
                panel2.Controls.Add(button5);

                #endregion
                #region buttoniptal
                buttoniptal.Location = new Point(117, 119);
                buttoniptal.Name = "buttoniptal";
                buttoniptal.Size = new Size(75, 25);
                buttoniptal.TabIndex = 18;
                buttoniptal.Text = "İPTAL";
                buttoniptal.UseVisualStyleBackColor = true;
                buttoniptal.Click += buttoniptal_Click;
                panel2.Controls.Add(buttoniptal);
                #endregion
            }
        }
        #endregion
        private void buttoniptal_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            alfa = false;
        }
        #region sil
        void sil()
        {
            tabPage2.Controls.Remove(textBox5);
            tabPage2.Controls.Remove(label5);
            tabPage2.Controls.Remove(button5);
            panel3.Controls.Remove(dataview);
        }
        #endregion
        int k = 0;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
           if( k%2==0)
            {

                if (alfa == true)
                {
                    panel1.Visible = false;
                    alfa = false;
                }
                olustur();
                button6.Text = "SKOR KAPAT";
              
            }
            else
            {
                panel1.Visible = true;
                sil();
                button6.Text = "SKOR GOSTER";
            }
            k++;
        }

      
        private void button5_Click(object sender, EventArgs e)
        {  
            komut.CommandText = "select count(*) from mayın";
            komut.Connection = baglantı;
            baglantı.Open();
            int kayıt = Convert.ToInt32(komut.ExecuteScalar());
            baglantı.Close();

            if (textBox5.Text != null || textBox5.Text != "")
            {
                bool hata = false;
                for(int i=0;i< kayıt; i++)
                {
                   string a= dataview.Rows[i].Cells["isim"].FormattedValue.ToString();
                    if (a == textBox5.Text)
                    {
                        MessageBox.Show("DAHA ONCE KULLANILDI \n FARKLI BİR İSİM SEÇİN");
                        hata = true;
                    }
                }
                if (hata == false)
                {
                    skorekle();
                    panel1.Visible = true;
                }
              
            }
            else
            {
                MessageBox.Show("Lütfen İsminiz Giriniz");
            }

          
        }
        #region skor ekle
        void skorekle()
        {
            
            string sqlKomut = "insert into mayın (isim, skor) values ('" + textBox5.Text + "','"
                  + label1.Text + "')";
            try
            {
                if (baglantı.State != ConnectionState.Open)
                {
                    baglantı.Open();
                }
                komut.CommandText = sqlKomut;
                komut.Connection = baglantı;
                komut.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Yeni kayıt eklendi..!");
                goruntule(dataview, "mayın");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                baglantı.Close();
            }
        }
        #endregion
        #endregion
    }
}
