using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            c.Show();
        }

        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Commande c = new Commande();
            c.Show();
        }

        private void ajouterToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Marque m = new Marque();
            m.Show();
        }

        private void consulterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csltclt clt = new csltclt();
            clt.Show();
        }

        private void miseAJourToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void consulterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CsltGamme cs = new CsltGamme();
            cs.Show();

        }

        private void consulterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Csltcommande c = new Csltcommande();
            c.Show();
        }

        private void ajouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Gamme c = new Gamme();
            c.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ajouteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nomoclature n = new Nomoclature();
            n.Show();
        }

        private void ajouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingrediant i = new Ingrediant();
            i.Show();
        }

        private void consulterToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CsltMarque m = new CsltMarque();
            m.Show();
        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsltIngrediant cs1 = new CsltIngrediant();
            cs1.Show();
        }

        private void consultationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CsltNomoclature css = new CsltNomoclature();
            css.Show();
        }

        private void ajouterToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Approvisionner a = new Approvisionner();
            a.Show();
        }

        private void consulterToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            csltApprovisionner a1 = new csltApprovisionner();
            a1.Show();
        }

        private void caclulerLesBesoinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculer_Besoin ca = new Calculer_Besoin();
            ca.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                this.Close();
            }
        }
    }
}
