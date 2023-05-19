using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class Form10 : Form
    {
        Bilet bilet = new Bilet();
        public Form10(Bilet bilet)
        {
            InitializeComponent();

            tbBilet.Text = bilet.ToString();
            this.bilet = bilet;
        }

        private void verificareCastigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testeazaCastig(bilet) == true)
            {
                DialogResult result = MessageBox.Show("Biletul este castigator! Vrei sa adaugi o poza cu pisica ta in clubul Pisicile Salbatice?", "Pisicile Salbatice", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    bool allowImageDrop = true;

                    Form12 form = new Form12();
                    form.IsImageDropAllowed = allowImageDrop;
                    form.ShowDialog();
                }
            }
            if (testeazaCastig(bilet) == false)
                MessageBox.Show("Biletul nu este castigator!");
        }

        private bool testeazaCastig(Bilet bilet)
        {
            bool rezultat = false;
            if (bilet == null || bilet.Pariuri == null)
                rezultat = false;
            foreach(Pariu pariu in bilet.Pariuri)
            {
                TipPariu tip = pariu.Tip;
                
                if (tip == TipPariu.Necunoscut)
                    rezultat = false;
                else if (tip == TipPariu.Corner)
                {
                    if (pariu.NrPariat == Convert.ToString(pariu.Meci.NrCornere))
                        rezultat = true;
                    else rezultat = false;
                }
                else if (tip == TipPariu.Penalty)
                {
                    if (pariu.NrPariat == Convert.ToString(pariu.Meci.NrPenalty))
                        rezultat = true;
                    else rezultat = false;
                }
                else if (tip == TipPariu.ScorFinal)
                {
                    if (pariu.NrPariat == Convert.ToString(pariu.Meci.calculeazaGoluri(pariu.Meci.GoluriAcasa, pariu.Meci.GoluriDeplasare)))
                        rezultat = true;
                    else rezultat = false;
                }
                else if (tip == TipPariu.NumarCartonaseRosii)
                {
                    if (pariu.NrPariat == Convert.ToString(pariu.Meci.NrCartonaseRosii))
                        rezultat = true;
                    else rezultat = false;
                }
                else if (tip == TipPariu.NumarCartonaseGalbene)
                {
                    if (pariu.NrPariat == Convert.ToString(pariu.Meci.NrCartonaseGalbene))
                        rezultat = true;
                    else rezultat = false;
                }
            }
            return rezultat;
        }
    }
}
