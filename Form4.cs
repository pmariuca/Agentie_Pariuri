using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class Form4 : Form
    {
        private int index;


        public List<Pariu> listaP = new List<Pariu>();
        public List<Meci> listaM = new List<Meci>();

        public int Index { get => index; set => index = value; }

        public Form4(List<Pariu> listaPariuri, List<Meci> listaMeciuri)
        {
            InitializeComponent();
            cbTipPariu.Items.Add(TipPariu.Corner);
            cbTipPariu.Items.Add(TipPariu.Penalty);
            cbTipPariu.Items.Add(TipPariu.ScorFinal);
            cbTipPariu.Items.Add(TipPariu.NumarCartonaseRosii);
            cbTipPariu.Items.Add(TipPariu.NumarCartonaseGalbene);

            listaP=listaPariuri;
            listaM=listaMeciuri;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(listaM, true);
            form.Owner = this;
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbTipPariu.SelectedIndex == -1)
                errorProvider1.SetError(cbTipPariu, "Selectati tipul pariului!");
            else
            {
                try
                {
                    string tip = Convert.ToString(cbTipPariu.Text);
                    string nr = Convert.ToString(numPariat.Value);

                    Pariu pariu = new Pariu(tip, nr, listaM[Index]);
                    listaP.Add(pariu);

                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("pariuri.dat", FileMode.OpenOrCreate,
                        FileAccess.Write);
                    bf.Serialize(fs, listaP);
                    fs.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    numPariat.Value = 0;
                    cbTipPariu.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(listaP, false);
            form.ShowDialog();
        }
    }
}
