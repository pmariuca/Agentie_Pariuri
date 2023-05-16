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
    public partial class Form7 : Form
    {
        List<Bilet> listaCastiguri = new List<Bilet>();
        public Form7(List<Bilet> listaCastig)
        {
            InitializeComponent();
            listaCastiguri = listaCastig;

            List<Bilet> lista = new List<Bilet>();
            lista = listaCastiguri.OrderByDescending(x => x.CastigPosibil).ToList();

            foreach (Bilet b in lista)
            {
                lbCastiguri.Items.Add(b.ToString());
            }
        }

        private void graficCastiguriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 form = new Form11(listaCastiguri);
            form.ShowDialog();
        }
    }
}
