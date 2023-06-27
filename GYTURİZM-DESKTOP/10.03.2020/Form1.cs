using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace _10._03._2020
{
    public partial class Form1 : Form
    {
       
        MySqlConnection con;
        MySqlDataReader dr;
        MySqlCommand cmd;
        string kalkıssaat, kalkıssaat2, fiyat, fiyat2 ;//biletler tablosuna bilet kayıt ederken kalkış saati ve fiyat bilgisi de eklemek için oluşturuldu.
        int sayac = 0;//panellere butonu koyarken kullanıyorum.
        string saat, nerden, nereye;
        string ad2, soyad2, tc2, ID2, cins2; //ikinci sayfadaki listviewde gözüken bilgileri çekiyorum ve bilet iptal ederken veya
        //güncellerken kullanıyorum.

        public Form1()
        { 
            InitializeComponent();
        }
       
       
        private void Form1_Load(object sender, EventArgs e)
        {
            #region veri tabanındaki biletler havuzundaki tarihi geçmiş biletleri siler
            con = new MySqlConnection(baglan.bag);
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM biletler where (t='" + DateTime.Now.ToLongDateString() + "' And kalkış<='" + DateTime.Now.ToLongTimeString() + "') or (t='" + DateTime.Now.AddDays(2).ToLongDateString() + "' AND (cins='" + "REZ-KA" + "' OR cins='" + "REZ-ER" + "') And kalkış<='" + DateTime.Now.ToLongTimeString() + "')";
            //rezervasyon olmayan biletleri kalkış günü ve kalkış saatinde siliyorum. rezervasyon olan biletler iki gün önceden siliniyor.
            cmd.ExecuteNonQuery();
            con.Close();


            #endregion

            #region combobox1 ve combobox2'ye form1 yüklenirkenki değerlerini verdik.
            comboBox1.Items.Add("NEREDEN?");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("NEREYE?");
            comboBox2.SelectedIndex = 0;
            #endregion

            #region ilk sayfadaki nerden ve ikinci sayfadaki nerden combobox'larına  veri tabanından "NEREDEN" tablosu çekildi.
            con = new MySqlConnection(baglan.bag);
            con.Open();
            cmd = new MySqlCommand("Select * from nereden", con);
            dr =cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["IL"].ToString());
                comboBox3.Items.Add(dr["IL"].ToString());
            }
            con.Close();
            #endregion

            #region datetime1, datetime2 ve datetime3'e form 1 yüklenirken ki değerlerini verdik
            dateTimePicker1.MinDate = DateTime.Now.AddDays(0);//ilk sayfa
            dateTimePicker2.MinDate = DateTime.Now.AddDays(0);//ilk sayfa
            dateTimePicker3.MinDate = DateTime.Now.AddDays(0);//ilk sayfa
            #endregion

            #region İKİNCİ SAYFADA Kİ LİSTVİEWE BÜTÜN BİLETLERİN LİSTELENDİĞİ KOD
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM biletler ORDER BY ID ASC ";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["u"].ToString());
                item.SubItems.Add(dr["cins"].ToString());
                item.SubItems.Add(dr["ad"].ToString());
                item.SubItems.Add(dr["soyad"].ToString());
                item.SubItems.Add(dr["tc"].ToString());
                item.SubItems.Add(dr["nereden"].ToString());
                item.SubItems.Add(dr["nereye"].ToString());
                item.SubItems.Add(dr["t"].ToString());
                listView3.Items.Add(item);
            }
            con.Close();
            #endregion


        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//ilk sayfade rezervasyon seçeneğinin kutusu
        {
           # region rezervasyon yapılacaksa erken iki gün sonraya alınacağını belirten messagebox
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("EN ERKEN İKİ GÜN SONRAYA REZERVASYON YAPABİLİRSİNİZ...");
                dateTimePicker1.MinDate = DateTime.Now.AddDays(2);
                if (radioButton2.Checked == true)//GİDİŞ-DÖNÜŞ AKTİFSE
                { dateTimePicker2.MinDate = DateTime.Now.AddDays(2); }
            }
            else
            {
                dateTimePicker1.MinDate = DateTime.Now.AddDays(0);
                dateTimePicker2.MinDate = DateTime.Now.AddDays(0);
               
            }

            #endregion
        }

        private void button2_Click(object sender, EventArgs e)//ilk sayfadaki temizle butonu
        {
            #region temizle butonuna basılınca temizleyeceği yerler
            if (radioButton2.Checked == true)
            {
                if (comboBox1.Text != "NEREDEN?" && listView2.Enabled==true)
                {//GİDİŞ-DÖNÜŞ BİLET ALINIRKEN GİDİŞ BİLETİNİ ALDIKTAN SONRA İŞLEM İPTAL/TEMİZLE İSTENİRSE SATILAN GİDİŞ BİLETİ SİLİNİR.
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM biletler where nereden='" + comboBox1.SelectedItem.ToString() + "' And nereye='" + comboBox2.SelectedItem.ToString() + "' And tc='" + tc + "' And t='" + dateTimePicker1.Value.ToLongDateString() + "' And u=" + no + "";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                button3.Visible = false;
                button116.Visible = true;
                listView2.Items.Clear();
                listView2.Enabled = false;
                panel2.Enabled = false;
                panel2.Controls.Clear();
                dateTimePicker2.MinDate = DateTime.Now.AddDays(0);
                dateTimePicker2.ResetText();
                dateTimePicker2.Enabled = false;
            }
            listView1.Enabled = false;
            listView1.Items.Clear();
            panel1.Enabled = false;
            panel1.Controls.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox6.Clear();
            checkBox1.Checked = false;
            radioButton1.Checked = true;
            dateTimePicker1.MinDate = DateTime.Now.AddDays(0);
            dateTimePicker1.ResetText();
            comboBox1.SelectedIndex = 0;
            comboBox2.Text = "NEREYE?";
            radioButton9.Enabled = false;
            #endregion
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            #region tek yön kısmı aktif ise tarih seçme şekli
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = false;
            }
            #endregion
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            #region gidiş-dönüş kısmı aktif ise tarih seçme şekli
            if (radioButton1.Checked == false && radioButton2.Checked == true)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            #endregion 
        }


        private void button1_Click(object sender, EventArgs e)// İLK SAYFADAKİ SEFERLERİ GÖSTER BUTONU
        {
            listView1.Items.Clear();
            panel1.Controls.Clear();

            #region TEK YÖN BİLETTE SEÇİLEN YÖNÜN BİLGİLERİNİ LİSTVİEW1'E EKLİYOR. 

            listView1.Items.Clear();
            con = new MySqlConnection(baglan.bag);
            con.Open();
            cmd = new MySqlCommand("select * from otobüsöz where NEREDEN='" + comboBox1.SelectedItem + "' AND NEREYE='" + comboBox2.SelectedItem + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                kalkıssaat = dr["KALKIŞ_SAAT"].ToString();
                item.SubItems.Add(kalkıssaat);
                item.SubItems.Add(dr["KOLTUKADED"].ToString());
                fiyat = dr["FİYAT"].ToString();
                item.SubItems.Add(fiyat);
                listView1.Items.Add(item);

            }
            con.Close();

            #endregion  //İLK SAYFADAKİ SAĞ ÜST KÖŞE LİSTVİEW1

            #region SEFER BİLGİLERİ KISMINI COMBOBOXLAR VE TEK-YÖN VEYA GİDİŞ-DÖNÜŞ BİLET SEÇENEKLERİNE GÖRE TEXTBOXLARI DOLDURDUK.
            listView1.Enabled = true;
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                con = new MySqlConnection(baglan.bag);
                con.Open();
                cmd = new MySqlCommand("Select NEREDEN, NEREYE, KM, SAAT, MOLA_SAYISI From sefer_bilgileri where NEREDEN='" + comboBox1.SelectedItem + "'AND NEREYE='" + comboBox2.SelectedItem + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = (dr["NEREDEN"]) + "/" + (dr["NEREYE"]).ToString();
                    textBox2.Text = (dr["KM"]).ToString();
                    textBox4.Text = (dr["SAAT"]).ToString();
                    textBox5.Text = (dr["MOLA_SAYISI"]).ToString();
                }
                con.Close();

            }
            else
            {
                con = new MySqlConnection(baglan.bag);
                con.Open();
                cmd = new MySqlCommand("Select NEREDEN, NEREYE, KM, SAAT, MOLA_SAYISI From sefer_bilgileri where NEREDEN='" + comboBox1.SelectedItem + "'AND NEREYE='" + comboBox2.SelectedItem + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = (dr["NEREDEN"]) + "/" + (dr["NEREYE"]) + "---" + (dr["NEREYE"]) + "/" + (dr["NEREDEN"]).ToString();
                    textBox2.Text = (dr["KM"]) + "---" + (dr["KM"]).ToString();
                    textBox4.Text = (dr["SAAT"]) + "---" + (dr["SAAT"]).ToString();
                    textBox5.Text = (dr["MOLA_SAYISI"]) + "---" + (dr["MOLA_SAYISI"]).ToString();
                }
                con.Close();
            }
            #endregion

            #region OTOBÜSÜN GÜN İÇERİSİNDEKİ KALKIŞ SAATİNE GÖRE EN ERKEN BİR SONRAKİ GÜNE BİLET SAATTIRMASI.
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * From otobüsöz Where NEREDEN='" + comboBox1.SelectedItem.ToString() + "' AND NEREYE='" + comboBox2.SelectedItem.ToString() + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                saat = dr["KALKIŞ_SAAT"].ToString();
                nerden = dr["NEREDEN"].ToString();
                nereye = dr["NEREYE"].ToString();
            }
            con.Close();
            if (nerden == comboBox1.SelectedItem.ToString() && nereye == comboBox2.SelectedItem.ToString() && Convert.ToDateTime(saat) < Convert.ToDateTime(DateTime.Now.ToLongTimeString()) && (radioButton1.Checked == true || radioButton2.Checked == true) && checkBox1.Checked == false)
            {
                dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
                dateTimePicker2.MinDate = DateTime.Now.AddDays(1);
            }
            else if (nerden == comboBox1.SelectedItem.ToString() && nereye == comboBox2.SelectedItem.ToString() && Convert.ToDateTime(saat) < Convert.ToDateTime(DateTime.Now.ToLongTimeString()) && (radioButton1.Checked == true || radioButton2.Checked == true) && checkBox1.Checked == true)
            {
                dateTimePicker1.MinDate = DateTime.Now.AddDays(3);
                dateTimePicker2.MinDate = DateTime.Now.AddDays(3);
            }
            #endregion

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            #region combobox1'e göre combobox2 de çıkıcak verilerin kodları
            switch (comboBox1.Text)
            {
                case "SİNOP":
                    comboBox2.Items.Clear();
                 con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from nereye1";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"].ToString());
                    }
                    con.Close();
                    break;
                    

                case "SAMSUN(ÖÖ)":
                    comboBox2.Items.Clear();
                     con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from nereye2";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "SAMSUN(ÖS)":
                    comboBox2.Items.Clear();
                   con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from nereye2";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "KASTAMONU":
                    comboBox2.Items.Clear();
                   con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from nereye3";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "KARABÜK":
                    comboBox2.Items.Clear();
                   con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from nereye4";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "BOLU":
                    comboBox2.Items.Clear();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from nereye5";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "SAKARYA":
                    comboBox2.Items.Clear();
                   con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from nereye6";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "İSTANBUL":
                    comboBox2.Items.Clear();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from nereye7";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                default: break;
            }
            #endregion
          
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {//BİRİNCİ SAYFADA SOL ALT KÖŞEDE BİLET KAYDEDERKEN TC YAZILAN KISIM.
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  //tc kısmına sadecece sayı girmesini sağlıyor.
        }

        #region PANEL1 İÇLERİNİN DOLDUĞU KISIM
        //bu bölümde 4 kısım var ilk kısım panel1'in içini dolduruyor. ama veri1 ve veri2 kısmına göre
        //dördüncü kısımda yani (btn_CLick) kısmı da koltuklara click özelliği veriyor
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           
            panel1.Enabled = true;
            radioButton9.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
           
            
            sayac = 1;
            for (int j = 0; j < 14; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 2)
                    {
                        continue;
                    }
                    Button btn = new Button();
                    btn.BackColor = Color.Azure;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Size = new Size(49, 43);
                    btn.Image = Properties.Resources.boş;
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    btn.TabIndex = sayac;
                    btn.Location = new Point(45 + j * 49, -1 + i * 43);                   
                    sayac++;
                    this.panel1.Controls.Add(btn);                  
                    btn.Click += new EventHandler(btn_Click);        
                    
                          btn.Text = veri1(btn.Name);
                          btn.Name = veri2(btn.Name);

                    if (btn.Text == "KADIN")//dolu olan koltukların resmini ve click özelliğinin değiştiği kısım
                    {
                        btn.Image = Properties.Resources.kız;
                        btn.Click -= btn_Click;
                    }
                    else if (btn.Text == "ERKEK")
                    {
                        btn.Image = Properties.Resources.erkek;
                        btn.Click -= btn_Click;
                    }
                    else if (btn.Text == "REZ-KA" || btn.Text == "REZ-ER")
                    {
                        btn.Image = Properties.Resources.rezerve;
                        btn.Click -= btn_Click;
                    }
                }
            }
            

        }

        public string veri1(string veri1)
        {
            string veri3 = "";
            string cins = "";
            string u = "";
            string tarih = "";
            string nerden = "";
            string nereye = "";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM biletler WHERE u=" + veri1.ToString() + " and nereden='" + comboBox1.SelectedItem.ToString() + "' and nereye='" + comboBox2.SelectedItem.ToString() + "' and t='" + dateTimePicker1.Value.ToLongDateString() + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cins = dr["cins"].ToString();
                u = dr["u"].ToString();
                tarih = dr["t"].ToString();
                nerden = dr["nereden"].ToString();
                nereye = dr["nereye"].ToString();
            }
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM koltuk WHERE sıra1=" + veri1.ToString() + "";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string no = dr["sıra1"].ToString();


                if ((no == u && cins == "KADIN" && tarih == dateTimePicker1.Value.ToLongDateString() && nerden == comboBox1.SelectedItem.ToString() && nereye == comboBox2.SelectedItem.ToString()) || (no == u && cins == "ERKEK" && nerden == comboBox1.SelectedItem.ToString() && nereye == comboBox2.SelectedItem.ToString() && tarih == dateTimePicker1.Value.ToLongDateString()))
                {
                    veri3 = cins.ToString();

                }
                else if ((no == u && cins == "REZ-KA" && tarih == dateTimePicker1.Value.ToLongDateString() && nerden == comboBox1.SelectedItem.ToString() && nereye == comboBox2.SelectedItem.ToString()) || (no == u && cins == "REZ-ER" && nerden == comboBox1.SelectedItem.ToString() && nereye == comboBox2.SelectedItem.ToString() && tarih == dateTimePicker1.Value.ToLongDateString()))
                {
                    veri3 = cins.ToString();
                }
                else
                {
                    veri3 = no.ToString();

                }
            }
            con.Close();
            return veri3;
        }
      
        public string veri2(string veri1)
        {
            string veri3 = "";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM koltuk WHERE sıra1=" + veri1.ToString() + "";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string no = dr["sıra1"].ToString();
                veri3 = no.ToString();
            }
            con.Close();
            return veri3;
        }
        

        void btn_Click(object sender, EventArgs e)
        {
            /*radiobutton1=>TEK YÖN radiobutton2=>GİDİŞ-DÖNÜŞ checbox1=>REZERVASYON SEÇENEĞİ
             radiobutton3=>KADIN radiobutton4=>ERKEK radiobutton9=>BOŞ KOLTUK
             rezervasyon yapan kadın veya erkeğin koltuk rengi yeşil üstünde REZ-KA VEYA REZ-ER yazar.*/
            Button btn = (Button)sender;
            if (radioButton3.Checked == true && radioButton4.Checked == false && checkBox1.Checked == false)
            {
                btn.Image = Properties.Resources.kız;
                btn.Text = radioButton3.Text;
                radioButton3.Checked = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;               
                textBox8.Text = btn.Name.ToString();
                textBox6.Text = btn.Text;
            }
            else if (radioButton3.Checked == false && radioButton4.Checked == true && checkBox1.Checked == false)
            {

                btn.Image = Properties.Resources.erkek;
                btn.Text = radioButton4.Text;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton4.Checked = false;
                textBox8.Text = btn.Name.ToString();
                textBox6.Text = btn.Text;
            }
            else if (radioButton3.Checked == true && radioButton4.Checked == false && checkBox1.Checked == true)
            {
                btn.Image = Properties.Resources.rezerve;
                btn.Text = "REZ-KA";
                radioButton3.Checked = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                textBox8.Text = btn.Name.ToString();
                textBox6.Text = btn.Text;
            }
            else if (radioButton3.Checked == false && radioButton4.Checked == true && checkBox1.Checked == true)
            {
                btn.Image = Properties.Resources.rezerve;
                btn.Text = "REZ-ER";
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton4.Checked = false;
                textBox8.Text = btn.Name.ToString();
                textBox6.Text = btn.Text;
            }
            if (radioButton9.Checked == true)
            {
                btn.Image = Properties.Resources.boş;
                btn.Text = btn.Name;
                textBox8.Clear();
                textBox6.Clear();
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
            }
        }
        #endregion

        #region PANEL2 KISIMLARININ İÇLERİNİN DOLDUĞU BÖLÜM (GİDİŞ DÖNÜŞLERDE KULLANILIR) (PANEL1 İLE AYNI ÖZELLİĞE SAHİPTİR)
        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            radioButton9.Enabled = true;
            if (cins == "KADIN" || cins == "REZ-KA")
            {//gidiş dönüş biletlerde gidiş kısmının cinsiyeti kadın ise dönüş kısmıda zorunlu olarak kadın olur
                radioButton3.Checked = true;
                radioButton3.Enabled = true;

            }
            else
            {
                radioButton4.Checked = true;
                radioButton4.Enabled = true;
            }
            panel2.Enabled = true;

            sayac = 1;
            for (int j = 0; j < 14; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 2)
                    {
                        continue;
                    }
                    Button btn = new Button();
                    btn.BackColor = Color.Azure;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Size = new Size(49, 43);
                    btn.Image = Properties.Resources.boş;
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    btn.TabIndex = sayac;
                    btn.Location = new Point(45 + j * 49, -1 + i * 43);
                    sayac++;
                    this.panel2.Controls.Add(btn);
                    btn.Click += new EventHandler(btn_Click1);
                    btn.Text = veri3(btn.Name);
                    btn.Name = veri4(btn.Name);
                    if (btn.Text == "KADIN")
                    {
                        btn.Image = Properties.Resources.kız;
                        btn.Click -= btn_Click1;
                    }
                    else if (btn.Text == "ERKEK")
                    {
                        btn.Image = Properties.Resources.erkek;
                        btn.Click -= btn_Click1;
                    }
                    else if (btn.Text=="REZ-KA" || btn.Text=="REZ-ER")
                    {
                        btn.Image = Properties.Resources.rezerve;
                        btn.Click -= btn_Click1;
                    }
                }
            }

        }
        public string veri3(string veri1)
        {
            string veri3 = "";
            string cins = "";
            string u = "";
            string tarih = "";
            string nerden = "";
            string nereye = "";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM biletler WHERE u=" + veri1.ToString() + " and nereden='" + comboBox2.SelectedItem.ToString() + "' and nereye='" + comboBox1.SelectedItem.ToString() + "' and t='" + dateTimePicker2.Value.ToLongDateString() + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cins = dr["cins"].ToString();
                u = dr["u"].ToString();
                tarih = dr["t"].ToString();
                nerden = dr["nereden"].ToString();
                nereye = dr["nereye"].ToString();
            }
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM koltuk WHERE sıra1=" + veri1.ToString() + "";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string no = dr["sıra1"].ToString();
                if ((no == u && cins == "KADIN" && tarih == dateTimePicker2.Value.ToLongDateString() && nerden == comboBox2.SelectedItem.ToString() && nereye == comboBox1.SelectedItem.ToString()) || (no == u && cins == "ERKEK" && nerden == comboBox2.SelectedItem.ToString() && nereye == comboBox1.SelectedItem.ToString() && tarih == dateTimePicker2.Value.ToLongDateString()))
                {
                    veri3 = cins.ToString();

                }
                else if ((no == u && cins == "REZ-KA" && tarih == dateTimePicker2.Value.ToLongDateString() && nerden == comboBox2.SelectedItem.ToString() && nereye == comboBox1.SelectedItem.ToString()) || (no == u && cins == "REZ-ER" && nerden == comboBox2.SelectedItem.ToString() && nereye == comboBox1.SelectedItem.ToString() && tarih == dateTimePicker2.Value.ToLongDateString()))
                {
                    veri3 = cins.ToString();
                }
                else
                {
                    veri3 = no.ToString();

                }
            }
            con.Close();
            return veri3;
        }



        public string veri4(string veri1)
        {
            string veri3 = "";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM koltuk WHERE sıra1=" + veri1.ToString() + "";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string no = dr["sıra1"].ToString();
                veri3 = no.ToString();
            }
            con.Close();
            return veri3;
        }

       

        void btn_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (radioButton3.Checked == true && radioButton4.Checked == false && checkBox1.Checked == false)
            {
                btn.Image = Properties.Resources.kız;
                btn.Text = radioButton3.Text;
                radioButton3.Checked = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                textBox8.Text = btn.Name.ToString();
                textBox6.Text = btn.Text;
                textBox10.Text = ad;
                textBox9.Text = soyad;
                textBox3.Text = tc;

            }
            else if (radioButton3.Checked == false && radioButton4.Checked == true && checkBox1.Checked == false)
            {

                btn.Image = Properties.Resources.erkek;
                btn.Text = radioButton4.Text;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton4.Checked = false;
                textBox8.Text = btn.Name.ToString();
                textBox6.Text = btn.Text;
                textBox10.Text = ad;
                textBox9.Text = soyad;
                textBox3.Text = tc;
            }
            else if (radioButton3.Checked == true && radioButton4.Checked == false && checkBox1.Checked == true)
            {
                btn.Image = Properties.Resources.rezerve;
                btn.Text = "REZ-KA";
                radioButton3.Checked = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                textBox8.Text = btn.Name.ToString();
                textBox6.Text = btn.Text;
                textBox10.Text = ad;
                textBox9.Text = soyad;
                textBox3.Text = tc;
            }
            else if (radioButton3.Checked == false && radioButton4.Checked == true && checkBox1.Checked == true)
            {
                btn.Image = Properties.Resources.rezerve;
                btn.Text = "REZ-ER";
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton4.Checked = false;
                textBox8.Text = btn.Name.ToString();
                textBox6.Text = btn.Text;
                textBox10.Text = ad;
                textBox9.Text = soyad;
                textBox3.Text = tc;
            }
            if (radioButton9.Checked == true)
            {
                btn.Image = Properties.Resources.boş;
                btn.Text = btn.Name;
                textBox8.Clear();
                textBox6.Clear();
                if (cins == "KADIN")
                {
                    radioButton3.Checked = true;
                    radioButton3.Enabled = true;

                }
                else
                {
                    radioButton4.Checked = true;
                    radioButton4.Enabled = true;
                }
            }
        }
        #endregion

        #region TEK YÖN VE GİDİŞ-DÖNÜŞ SEÇENEĞİNİN GİDİŞ KISMININ BİLETİNİ KAYDETME BUTONU
        string ad, soyad, tc, cins, no;//BİLET TÜRÜ GİDİŞ DÖNÜŞ OLDUĞUNDA  DÖNÜŞ BİLETİNİ SEÇTİKTEN SONRA AD SOYAD TC Yİ BİR DAHA YAZMAMAK
        //İÇİN OLUŞTURULMUŞTUR.

       

        private void button116_Click(object sender, EventArgs e)
        {//TEK YÖN VE GİDİŞ-DÖNÜŞ BİLETLERİNDEN GİDİŞ TARAFININ BİLETLERİNİ KAYDEDEN BUTON
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into biletler (ID,u,cins,nereden,nereye,kalkış,t,fiyat,ad,soyad,tc) values (@ID,@u,@cins,@nereden,@nereye,@kalkış,@t,@fiyat,@ad,@soyad,@tc)";
            cmd.Parameters.AddWithValue("@ID", textBox8.Text.ToString());
            cmd.Parameters.AddWithValue("@u", textBox8.Text.ToString());
            cmd.Parameters.AddWithValue("@cins", textBox6.Text);
            cmd.Parameters.AddWithValue("@nereden", comboBox1.Text);
            cmd.Parameters.AddWithValue("@nereye", comboBox2.Text);
            cmd.Parameters.AddWithValue("@kalkış", kalkıssaat);
            cmd.Parameters.AddWithValue("@t", dateTimePicker1.Value.ToLongDateString());
            cmd.Parameters.AddWithValue("@fiyat", fiyat);
            cmd.Parameters.AddWithValue("@ad", textBox10.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox9.Text);
            cmd.Parameters.AddWithValue("@tc", textBox3.Text.ToString());
        
            cmd.ExecuteNonQuery();
            con.Close();

            panel1.Controls.Clear();
            panel1.Enabled = false;
            listView1.Items.Clear();
            listView1.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton9.Enabled = false;
            
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                button116.Visible = true;               
                textBox10.Clear();
                textBox9.Clear();
                textBox3.Clear();
                textBox8.Clear();
                textBox6.Clear();
               
                MessageBox.Show("BİLETİNİZ KAYDEDİLMİŞTİR...");
                DialogResult secenek1 = MessageBox.Show("AYNI YÖNDE BAŞKA BİLET ALMAK İSTERMİSİNİZ?","", MessageBoxButtons.YesNo);
                if (secenek1 == DialogResult.No)
                {
                    checkBox1.Checked = false;
                   textBox1.Clear();
                    textBox2.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    dateTimePicker1.MinDate = DateTime.Now.AddDays(0);
                    dateTimePicker1.ResetText();
                    dateTimePicker2.MinDate = DateTime.Now.AddDays(0);
                    dateTimePicker2.ResetText();
                    comboBox1.SelectedIndex = 0;
                    comboBox2.Text = "NEREYE?";
                }
            }
            else
            {
                button116.Visible = false;
                button3.Visible = true;
                ad = textBox10.Text;
                soyad = textBox9.Text;
                tc = textBox3.Text;
                cins = textBox6.Text;
                no = textBox8.Text;
                textBox10.Clear();
                textBox9.Clear();
                textBox3.Clear();
                textBox8.Clear();
                textBox6.Clear();
                
                DialogResult secenek = MessageBox.Show("GİDİŞ BİLETİNİZ SATILMIŞTIR.LÜTFEN DÖNÜŞ BİLETİNİ DE ALINIZ.", "BİLGİLENDİRME PENCERESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (secenek == DialogResult.OK)
                {
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from otobüsöz where NEREDEN='" + comboBox2.SelectedItem + "' AND NEREYE='" + comboBox1.SelectedItem + "'", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListViewItem item1 = new ListViewItem(dr["ID"].ToString());
                        kalkıssaat2 = dr["KALKIŞ_SAAT"].ToString();
                        item1.SubItems.Add(kalkıssaat2);
                        item1.SubItems.Add(dr["KOLTUKADED"].ToString());
                        fiyat2 = dr["FİYAT"].ToString();
                        item1.SubItems.Add(fiyat2);
                        listView2.Items.Add(item1);

                    }
                    con.Close();
                    listView2.Enabled = true;
                }
            }
        }


       


        #endregion

        #region GİDİŞ DÖNÜŞ BİLET ALMA SEÇENEĞİNİN DÖNÜŞ BİLETİNİ KAYDEDEN BUTONU
        private void button3_Click_1(object sender, EventArgs e)
        {
               con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into biletler (ID,u,cins,nereden,nereye,kalkış,t,fiyat,ad,soyad,tc) values (@ID,@u,@cins,@nereden,@nereye,@kalkış,@t,@fiyat,@ad,@soyad,@tc)";
            cmd.Parameters.AddWithValue("@ID", textBox8.Text.ToString());
            cmd.Parameters.AddWithValue("@u", textBox8.Text.ToString());
            cmd.Parameters.AddWithValue("@cins", textBox6.Text);
            cmd.Parameters.AddWithValue("@nereden", comboBox1.Text);
            cmd.Parameters.AddWithValue("@nereye", comboBox2.Text);
            cmd.Parameters.AddWithValue("@kalkış", kalkıssaat);
            cmd.Parameters.AddWithValue("@t", dateTimePicker1.Value.ToLongDateString());
            cmd.Parameters.AddWithValue("@fiyat", fiyat);
            cmd.Parameters.AddWithValue("@ad", textBox10.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox9.Text);
            cmd.Parameters.AddWithValue("@tc", textBox3.Text.ToString());
        
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("GİDİŞ-DÖNÜŞ BİLETİNİZ KAYDEDİLMİŞTİR.");
            
            textBox10.Clear();
            textBox9.Clear();
            textBox3.Clear();
            textBox8.Clear();
            textBox6.Clear();
            panel2.Controls.Clear();
            panel2.Enabled = false;
            listView2.Items.Clear();
            listView2.Enabled = false;

            DialogResult secenek2 = MessageBox.Show("AYNI YÖNDE GİDİŞ-DÖNÜŞ BİLETİ ALMAK İSTER MİSİNİZ?","", MessageBoxButtons.YesNo);
            if (secenek2 == DialogResult.No)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton9.Enabled = false;
                dateTimePicker1.MinDate = DateTime.Now.AddDays(0);
                dateTimePicker1.ResetText();
                dateTimePicker2.MinDate = DateTime.Now.AddDays(0);
                dateTimePicker2.ResetText();
                dateTimePicker2.Enabled = false;
                checkBox1.Checked = false; 
                comboBox1.SelectedIndex = 0;
                comboBox2.Text = "NEREYE?";
                radioButton1.Checked = true;
                button3.Visible = false;
                button116.Visible = true;
            }
            else
            {
                button116.Visible = true;
                button3.Visible = false;
            }
           
        }
        #endregion

        #region HESAPLA BUTONU
        private void button7_Click(object sender, EventArgs e)
        {
            HESAPLA frm2 = new HESAPLA();
            frm2.Show();
        }     
        #endregion

        //İKİNCİ SAYFA KODLARI,

        #region BİLET İPTAL KISMINININ BÜTÜN KODLARI

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {//BİLET İPTAL KISMININ TC KISMI
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  //tc kısmına sadecece sayı girmesini sağlıyor.
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {//BİLET İPTAL KISMININ RADİOBUTONU
            if (radioButton5.Checked == true)
            {
                groupBox5.Enabled = true;
            }
            else
            {
                groupBox5.Enabled = false;
            }
        }
        private void button109_Click(object sender, EventArgs e)
        {
            //BİLET AL KISMININ YOLCU BUL BUTONU
            if (textBox7.Text == "" || textBox11.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("LÜTFEN BOŞ OLAN ALANLARI DOLDURUNUZ!!!", "BİLGİLENDİRME PENCERESİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listView3.Items.Clear();
                con = new MySqlConnection(baglan.bag);//BU SATIRI YAZMAZSAM HATA VERİYOR.TEMEL ALDIĞI RCW ÜZERİNDEN COM TARZINDA BİR HATA VERİYOR
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM biletler where ad='" + textBox11.Text + "' AND soyad='" + textBox12.Text + "' AND tc='" + textBox7.Text + "'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["ID"].ToString());
                    item.SubItems.Add(dr["u"].ToString());
                    item.SubItems.Add(dr["cins"].ToString());
                    item.SubItems.Add(dr["ad"].ToString());
                    item.SubItems.Add(dr["soyad"].ToString());
                    item.SubItems.Add(dr["tc"].ToString());
                    item.SubItems.Add(dr["nereden"].ToString());
                    item.SubItems.Add(dr["nereye"].ToString());
                    item.SubItems.Add(dr["t"].ToString());
                    listView3.Items.Add(item);
                }
                con.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {//BİLET AL KISMININ TEMİZLE BUTONU
            textBox7.Clear();
            textBox11.Clear();
            textBox12.Clear();
            listView3.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM biletler ORDER BY ID ASC";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["u"].ToString());
                item.SubItems.Add(dr["cins"].ToString());
                item.SubItems.Add(dr["ad"].ToString());
                item.SubItems.Add(dr["soyad"].ToString());
                item.SubItems.Add(dr["tc"].ToString());
                item.SubItems.Add(dr["nereden"].ToString());
                item.SubItems.Add(dr["nereye"].ToString());
                item.SubItems.Add(dr["t"].ToString());
                listView3.Items.Add(item);
            }
            con.Close();
        }


        #endregion

        #region BİLET GÜNCELLE KISMININ BÜTÜN KODLARI
        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {//BİLET GÜNCELLE KISMININ TC KISMI
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  //tc kısmına sadecece sayı girmesini sağlıyor.      
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {//BİLET GÜNCELLE KISMININ RADİOBUTONU
            if (radioButton6.Checked == true)
            {
                groupBox7.Enabled = true;
            }
            else
            {
                groupBox7.Enabled = false;
            }
        }
        private void button110_Click(object sender, EventArgs e)
        {          //BİLET GÜNCELLE KISMININ YOLCU BUL BUTONU
            if (textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "")
            {
                MessageBox.Show("LÜTFEN BOŞ OLAN ALANLARI DOLDURUNUZ!!!", "BİLGİLENDİRME PENCERESİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listView3.Items.Clear();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM biletler where ad='" + textBox14.Text + "' AND soyad='" + textBox15.Text + "' AND tc='" + textBox13.Text + "'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["ID"].ToString());
                    item.SubItems.Add(dr["u"].ToString());
                    item.SubItems.Add(dr["cins"].ToString());
                    item.SubItems.Add(dr["ad"].ToString());
                    item.SubItems.Add(dr["soyad"].ToString());
                    item.SubItems.Add(dr["tc"].ToString());
                    item.SubItems.Add(dr["nereden"].ToString());
                    item.SubItems.Add(dr["nereye"].ToString());
                    item.SubItems.Add(dr["t"].ToString());
                    listView3.Items.Add(item);
                }
                con.Close();
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {//BİLET GÜNCELLE KISMIN TEMİZLEBUTONU
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            listView3.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM biletler ORDER BY ID ASC";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["u"].ToString());
                item.SubItems.Add(dr["cins"].ToString());
                item.SubItems.Add(dr["ad"].ToString());
                item.SubItems.Add(dr["soyad"].ToString());
                item.SubItems.Add(dr["tc"].ToString());
                item.SubItems.Add(dr["nereden"].ToString());
                item.SubItems.Add(dr["nereye"].ToString());
                item.SubItems.Add(dr["t"].ToString());             
                listView3.Items.Add(item);
            }
            con.Close();
        }
        #endregion

        #region YOLCU LİSTELEME KISMI
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {//YOLCU LİSTELEME BÖLÜMÜNÜN RADİOBUTONU
            if (radioButton7.Checked == true)
            {
                groupBox8.Enabled = true;
            }
            else
            {
                groupBox8.Enabled = false;
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {//İKİNCİ SAYFADAKİ NERDEN KISMINA GÖRE NEREYE GELECEK OLAN İLLER
            switch (comboBox3.Text)
            {
                case "SİNOP":
                    comboBox4.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("Select * from nereye1", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox4.Items.Add(dr["IL"].ToString());
                    }
                    con.Close();
                    break;


                case "SAMSUN(ÖÖ)":
                    comboBox4.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye2", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox4.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "SAMSUN(ÖS)":
                    comboBox4.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye2", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox4.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "KASTAMONU":
                    comboBox4.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye3", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox4.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "KARABÜK":
                    comboBox4.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye4", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox4.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "BOLU":
                    comboBox4.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye5", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox4.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "SAKARYA":
                    comboBox4.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye6", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox4.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "İSTANBUL":
                    comboBox4.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye7", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox4.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                default: break;
            }
        }
        

        int u;//İF DÖNGÜSÜNDE KULLANMAM İÇİN OLUŞTURULMUŞTUR.
        private void button10_Click(object sender, EventArgs e)
        {//İKİNCİ SAYFADAKİ SEFER BUL BUTONU

            listView3.Items.Clear();
            for (int number = 1; number <= 56; number++)
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM biletler where t='" + dateTimePicker3.Value.ToLongDateString() + "' AND nereden='" + comboBox3.SelectedItem.ToString() + "' AND nereye='" + comboBox4.SelectedItem.ToString() + "' AND u=" + number + "";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    u = Convert.ToInt32(dr["u"].ToString());
                    ListViewItem item1 = new ListViewItem(u.ToString());
                    item1.SubItems.Add(u.ToString());
                    item1.SubItems.Add(dr["cins"].ToString());
                    item1.SubItems.Add(dr["ad"].ToString());
                    item1.SubItems.Add(dr["soyad"].ToString());
                    item1.SubItems.Add(dr["tc"].ToString());
                    item1.SubItems.Add(dr["nereden"].ToString());
                    item1.SubItems.Add(dr["nereye"].ToString());
                    item1.SubItems.Add(dr["t"].ToString());                    
                    listView3.Items.Add(item1);
                }
                con.Close();

                if (u != number)
                {
                    ListViewItem item = new ListViewItem(number.ToString());
                    item.SubItems.Add(number.ToString());
                    item.SubItems.Add("(boş)");
                    item.SubItems.Add("(boş)");
                    item.SubItems.Add("(boş)");
                    item.SubItems.Add("(boş)");
                    item.SubItems.Add("(boş)");
                    item.SubItems.Add("(boş)");
                    item.SubItems.Add("(boş)");                  
                    listView3.Items.Add(item);
                }

            }
        }
        private void button111_Click(object sender, EventArgs e)
        {//İKİNCİ SAYFA YOLCU LİSTELEME BÖLÜMÜNÜN TEMİZLE BUTONU
            listView3.Items.Clear();
            comboBox3.Text = "NEREDEN?";
            comboBox4.Text = "NEREYE?";
            dateTimePicker3.ResetText();
            dateTimePicker3.MinDate = DateTime.Now.AddDays(0);

            listView3.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM biletler ORDER BY ID ASC";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["u"].ToString());
                item.SubItems.Add(dr["cins"].ToString());
                item.SubItems.Add(dr["ad"].ToString());
                item.SubItems.Add(dr["soyad"].ToString());
                item.SubItems.Add(dr["tc"].ToString());
                item.SubItems.Add(dr["nereden"].ToString());
                item.SubItems.Add(dr["nereye"].ToString());
                item.SubItems.Add(dr["t"].ToString());             
                listView3.Items.Add(item);
            }
            con.Close();
        }
        #endregion

        #region LİSTVİEW 3'TEN BİR KAYIT SEÇİLDİĞİNDE
        private void listView3_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            if (listView3.SelectedItems.Count > 0)
            {
                ListViewItem yolcubilgi = listView3.SelectedItems[0];
                ID2 = yolcubilgi.SubItems[0].Text;
                ad2 = yolcubilgi.SubItems[3].Text;
                soyad2 = yolcubilgi.SubItems[4].Text;
                tc2 = yolcubilgi.SubItems[5].Text;
                cins2 = yolcubilgi.SubItems[2].Text;
            }

            if (radioButton5.Checked == true)
            {
                DialogResult iptal = MessageBox.Show("BİLETİ İPTAL ETMEK İSTEDİĞİNİZDEN EMİN MİSİNİZ?", "", MessageBoxButtons.YesNo);
                {
                    if (iptal == DialogResult.Yes)
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "DELETE FROM biletler where ID="+ID2+" AND  ad='" + ad2 + "' AND soyad ='" + soyad2 + "' AND tc='" + tc2 + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();                       
                    }
                    else { }
                }
            }
            else if (radioButton6.Checked == true)
            {
                string cinsiyet;
                if (cins2 == "REZ-KA")
                {
                    cinsiyet = radioButton3.Text;
                }
                else
                {
                    cinsiyet = radioButton4.Text;
                }
                DialogResult guncelle = MessageBox.Show("REZERVE EDİLMİŞ BİLETİ SATMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ?","",MessageBoxButtons.YesNo);
                {
                    if (guncelle == DialogResult.Yes)
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "UPDATE biletler SET  cins='" + cinsiyet + "'  where ID=" + ID2 + " AND  ad='" + ad2 + "' AND soyad ='" + soyad2 + "' AND tc='" + tc2 + "' AND cins='"+cins2+"'";
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else { }
                }
            }
        }
        #endregion

        #region SAYFAYI YENİLE BUTONU
        private void button11_Click(object sender, EventArgs e)
        {//SAYFAYI YENİLE BUTONU
            listView3.Items.Clear();
            con = new MySqlConnection(baglan.bag); //bu satırı yazmazsam =>'Temel aldığı RCW'den ayrılmış COM nesnesi kullanılamaz hatası veriyor.
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM biletler ORDER BY ID ASC";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["u"].ToString());
                item.SubItems.Add(dr["cins"].ToString());
                item.SubItems.Add(dr["ad"].ToString());
                item.SubItems.Add(dr["soyad"].ToString());
                item.SubItems.Add(dr["tc"].ToString());
                item.SubItems.Add(dr["nereden"].ToString());
                item.SubItems.Add(dr["nereye"].ToString());
                item.SubItems.Add(dr["t"].ToString());                
                listView3.Items.Add(item);
            }
            con.Close();
        }
        #endregion
    }
}