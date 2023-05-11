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
    public partial class Form1 : Form
    {
        public List<Meci> listaMeciuri = new List<Meci>();
        public List<Pariu> listaPariuri = new List<Pariu>();
        public List<Persoana> listaPersoana = new List<Persoana>();
        public List<Bilet> listaCastiguri = new List<Bilet>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(listaMeciuri);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(listaPariuri, listaMeciuri);
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5(listaPersoana);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(listaMeciuri);
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(listaPariuri);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7(listaCastiguri);
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8(listaPariuri, listaPersoana, listaCastiguri);
            form.ShowDialog();
        }
    }
}
