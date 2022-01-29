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

namespace test13
{
    public partial class Form1 : Form
    {
        acceuil form = new acceuil();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Bibliothéque";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                using (SqlConnection con = new SqlConnection(@"server=.;database = Bibliothéque;integrated security = true"))
                {
                    SqlCommand cmd = new SqlCommand("select * from login", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr[0].ToString() == textBox1.Text && dr[1].ToString() == textBox2.Text)
                            {
                                this.Hide();
                                form.Show();
                            }
                        }

                    }
                }
            }
        }
    }
}