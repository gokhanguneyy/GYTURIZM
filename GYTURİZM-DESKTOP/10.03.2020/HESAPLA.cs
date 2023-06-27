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
    public partial class HESAPLA : Form
    {
        MySqlConnection con;
        MySqlDataReader dr;
        MySqlCommand cmd;
        public HESAPLA()
        {
            InitializeComponent();
        }

        private void HESAPLA_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("NEREDEN?");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("NEREYE?");
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Add("NEREDEN?");
            comboBox3.SelectedIndex = 0;
            comboBox4.Items.Add("NEREYE?");
            comboBox4.SelectedIndex = 0;

            con = new MySqlConnection(baglan.bag);
            con.Open();
            cmd = new MySqlCommand("Select * from nereden", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["IL"].ToString());
            }
            con.Close();
          
            con = new MySqlConnection(baglan.bag);
            con.Open();
            cmd = new MySqlCommand("Select * from nereden", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["IL"].ToString());
            }
            con.Close();
        }
        int fiyat;

        private void comboBox1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "SİNOP":
                    comboBox2.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("Select * from nereye1", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"].ToString());
                    }
                    break;

                case "SAMSUN(ÖÖ)":
                    comboBox2.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye2", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "SAMSUN(ÖS)":
                    comboBox2.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye2", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "KASTAMONU":
                    comboBox2.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye3", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "KARABÜK":
                    comboBox2.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye4", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "BOLU":
                    comboBox2.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye5", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "SAKARYA":
                    comboBox2.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye6", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                case "İSTANBUL":
                    comboBox2.Items.Clear();
                    con = new MySqlConnection(baglan.bag);
                    con.Open();
                    cmd = new MySqlCommand("select * from nereye7", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr["IL"]);
                    }
                    con.Close();
                    break;
                default: break;



            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            con = new MySqlConnection(baglan.bag);
            con.Open();
            cmd = new MySqlCommand("select * from otobüsöz where NEREDEN='" + comboBox1.Text + "' AND NEREYE='" + comboBox2.Text + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fiyat =Convert.ToInt32(dr["FİYAT"]);
            }
            con.Close();
            label5.Text = (fiyat * numericUpDown1.Value).ToString();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
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
        int fiyat1, fiyat2;

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tutar1, tutar2, toplam;
            tutar1 = Convert.ToInt32(label5.Text);
            tutar2 = Convert.ToInt32(label6.Text);
            toplam = tutar1 + tutar2;
            label11.Text = toplam.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = 0;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new MySqlCommand("select * from otobüsöz where NEREDEN='" + comboBox3.Text + "' AND NEREYE='" + comboBox4.Text + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fiyat1 =Convert.ToInt32(dr["FİYAT"]);
            }
            con.Close();
          
            con.Open();
            cmd = new MySqlCommand("select * from otobüsöz where NEREDEN='" + comboBox4.Text + "' AND NEREYE='" + comboBox3.Text + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fiyat2 =Convert.ToInt32(dr["FİYAT"]);
            }
            con.Close();
          
            label6.Text = ((fiyat1 + fiyat2) * numericUpDown2.Value).ToString();
        }
    }
}
//groupbox2 ve groupbox3 ün enabled özellikleri hep true olacak
