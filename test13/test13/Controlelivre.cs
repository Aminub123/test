using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test13.DslivreTableAdapters;

namespace test13
{
    public partial class Controlelivre : UserControl
    {
        Dslivre ds = new Dslivre();
        LivresTableAdapter tableAdapter = new LivresTableAdapter();
        public Controlelivre()
        {
            InitializeComponent();
        }

        private void Controlelivre_Load(object sender, EventArgs e)
        {
            afficher();
        }

        private void afficher()
        {
            tableAdapter.Fill(ds.Livres);
            GrilleLivre.DataSource = ds.Livres;

        }

        bool search(int code)
        {
            bool resulatt = false;
            foreach (DataRow item in ds.Livres.Rows)
            {
                if ((int)item[0] == code)
                {
                    resulatt = true;
                }
            }
            return resulatt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtnom.Text != "" && txtnomauteur.Text != "" && txtlangue.Text != "" && txtediteur.Text != "" && txtsection.Text != "" && txtnombredepages.Text != "")
            {
                if (search(int.Parse(txtid.Text))==false)
                {
                    DataRow row = ds.Livres.NewRow();
                    row[0] = int.Parse(txtid.Text);
                    row[1] = txtnom.Text;
                    row[2] = txtnomauteur.Text;
                    row[3] = txtsection.Text;
                    row[4] = txtlangue.Text;
                    row[5] = int.Parse(txtnombredepages.Text);
                    ds.Livres.Rows.Add(row);
                    tableAdapter.Update(ds.Livres);
                    afficher();
                }
                else MessageBox.Show("check your id");

            }
            else MessageBox.Show("check your txt");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtnom.Text != "" && txtnomauteur.Text != "" && txtlangue.Text != "" && txtediteur.Text != "" && txtsection.Text != "" && txtnombredepages.Text != "")
            {
                if (search(int.Parse(txtid.Text)) == true)
                {
                    for (int i = 0; i < ds.Livres.Rows.Count; i++)
                    {
                        if ((int)ds.Livres.Rows[i][0] == int.Parse(txtid.Text))
                        {
                            ds.Livres.Rows[i][0] = int.Parse(txtid.Text);
                            ds.Livres.Rows[i][1] = txtnom.Text;
                            ds.Livres.Rows[i][2] = txtnomauteur.Text;
                            ds.Livres.Rows[i][3] = txtsection.Text;
                            ds.Livres.Rows[i][4] = txtlangue.Text;
                            ds.Livres.Rows[i][5] = txtediteur.Text;
                            ds.Livres.Rows[i][6] = int.Parse(txtnombredepages.Text);
                            tableAdapter.Update(ds.Livres);
                            afficher();
                        }
                    }
                }
                else MessageBox.Show("check your id");

            }
            else MessageBox.Show("check your txt");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                if (search(int.Parse(txtid.Text)) == true)
                {
                    for (int i = 0; i < ds.Livres.Rows.Count; i++)
                    {
                        if ((int)ds.Livres.Rows[i][0] == int.Parse(txtid.Text))
                        {
                            ds.Livres.Rows[i].Delete();
                            tableAdapter.Update(ds.Livres);
                            afficher();
                        }
                    }
                }
                else MessageBox.Show("check your id");

            }
            //else if(GrilleLivre.CurrentRow != null)
            //{
            //    for (int i = 0; i < ds.Livres.Rows.Count; i++)
            //    {
            //        if (ds.Livres.Rows[i][0] == GrilleLivre.CurrentRow.Cells[0].Value)
            //        {
            //            ds.Livres.Rows[i].Delete();
            //            tableAdapter.Update(ds.Livres);
            //            afficher();
            //        }
            //    }
            //}
        }

        private void GrilleLivre_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
