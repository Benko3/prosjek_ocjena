using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prosjek_ocjena
{
    public partial class Form1 : Form
    {
        int ocjena, brojOcjena = 0, zbroj;
        double prosjek;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ocjena = Convert.ToInt32(txtunosOcjene.Text);

                if (ocjena != 1)
                {
                    brojOcjena++;
                    zbroj += ocjena;
                    DialogResult odgovor = MessageBox.Show("zelis li upisati jos ocjena?", "upit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (odgovor)
                    {
                        case DialogResult.Yes:
                            txtunosOcjene.Clear();
                            txtunosOcjene.Focus();
                            break;
                        case DialogResult.No:
                            prosjek = (double)zbroj / brojOcjena;

                            txtProsjekOcjene.Text = prosjek.ToString();
                            break;
                    }
                }
                else if (ocjena == 0)
                {
                    MessageBox.Show("Imas negativnu ocjenu, ispravi je prije nego" +
                        "da", "Pogrešan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Imas negativnu ocjenu, ispravi je prije nego" +
                        "ideš računati peosjek!", "NEGATIVNO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message, "Greška unosa", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
