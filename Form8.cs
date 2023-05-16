using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class Form8 : Form
    {
        public int IndexPers { get; set; }
        public List<int> Pariuri { get; set; } 

        public List<Pariu> listaP = new List<Pariu>();
        public List<Persoana> listaPers = new List<Persoana>();
        public List<Bilet> listaC = new List<Bilet>();
        public Form8(List<Pariu> listaPariuri, List<Persoana> listaPersoane, List<Bilet> listaCastiguri)
        {
            InitializeComponent();
            listaP = listaPariuri;
            listaPers = listaPersoane;
            listaC = listaCastiguri;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dataCopie;

            if (tbData.Text == "")
                errorProvider1.SetError(tbData, "Introduceti data!");
            else
                if (DateTime.TryParseExact(tbData.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie) == false)
                errorProvider1.SetError(tbData, "Introduceti o data valida!");
            else
                if (numSumaPariata.Value <= 0)
                errorProvider1.SetError(numSumaPariata, "Suma pariata trebuie sa fie pozitiva!");
            else
            {
                try
                {
                    int indexListaPers = IndexPers;
                    string data = Convert.ToString(tbData.Text);
                    int suma = Convert.ToInt32(numSumaPariata.Value);
                    Pariu[] pariuriAlese = new Pariu[Pariuri.Count];
                    for (int i = 0; i < Pariuri.Count; i++)
                    {
                        pariuriAlese[i] = listaP[i];
                    }

                    Bilet bilet = new Bilet(listaPers[IndexPers], data, pariuriAlese, suma);

                    listaC.Add(bilet);

                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("bilete.dat", FileMode.OpenOrCreate,
                        FileAccess.Write);
                    bf.Serialize(fs, listaC);
                    fs.Close();

                    Form10 form = new Form10(bilet);
                    form.ShowDialog();

                    listaPers[IndexPers].ModificaSuma(suma);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbData.Text = "";
                    numSumaPariata.Value = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form = new Form9(listaPers);
            form.Owner = this;
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(listaP);
            form.Owner = this;
            form.ShowDialog();
        }
    }
}
