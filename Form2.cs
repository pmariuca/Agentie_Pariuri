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
    public partial class Form2 : Form
    {
        public List<Meci> lista = new List<Meci>();
        public Form2(List<Meci> listaMeciuri)
        {
            InitializeComponent();
            lista = listaMeciuri;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dataCopie;
            if (tbNumeAcasa.Text == "")
                errorProvider1.SetError(tbNumeAcasa, "Introduceti echipa!");
            else
                if (tbNumeDeplasare.Text == "")
                    errorProvider1.SetError(tbNumeDeplasare, "Introduceti echipa!");
            else
                if (tbData.Text == "")
                    errorProvider1.SetError(tbData, "Introduceti data!");
            else
                if (DateTime.TryParseExact(tbData.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie) == false)
                    errorProvider1.SetError(tbData, "Introduceti o data valida!");
            else
            {
                try
                {
                    string numeAcasa = Convert.ToString(tbNumeAcasa.Text);
                    string numeDeplasare = Convert.ToString(tbNumeDeplasare.Text);
                    string data = Convert.ToString(tbData.Text);
                    int goluriAcasa = Convert.ToInt32(numGolAcasa.Value);
                    int goluriDeplasare = Convert.ToInt32(numGolDeplasare.Value);
                    int nrCornere = Convert.ToInt32(numCornere.Value);
                    int nrPenalty = Convert.ToInt32(numPenalty.Value);
                    int cartonaseRosii = Convert.ToInt32(numRosii.Value);
                    int cartonaseGalbene = Convert.ToInt32(numGalbene.Value);

                    Meci meci = new Meci(numeAcasa, numeDeplasare, data, goluriAcasa, goluriDeplasare, nrCornere, nrPenalty, cartonaseRosii, cartonaseGalbene);
                    lista.Add(meci);

                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("meciuri.dat", FileMode.OpenOrCreate,
                        FileAccess.Write);
                    bf.Serialize(fs, lista);
                    fs.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbNumeAcasa.Clear();
                    tbNumeDeplasare.Clear();
                    tbData.Clear();
                    numGolAcasa.Value = 0;
                    numGolDeplasare.Value = 0;
                    numCornere.Value = 0;
                    numPenalty.Value = 0;
                    numRosii.Value = 0;
                    numGalbene.Value = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(lista, false);
            form.ShowDialog();
        }
    }
}
