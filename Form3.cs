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
    public partial class Form3 : Form
    {
        public int index = -1;
        public bool isSelected;
        List<Meci> lista2 = new List<Meci>();
        public Form3(List<Meci> listaMeciuri, bool isSelected)
        {
            InitializeComponent();
            lista2 = listaMeciuri;
            this.isSelected = isSelected;

            foreach (Meci meci in lista2)
            {
                listBoxMeciuri.Items.Add(meci.ToString());
            }
        }

        private void listBoxMeciuri_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxMeciuri.Items.Count; i++)
            {
                if (listBoxMeciuri.GetSelected(i))
                {
                    index = i;
                }
            }
            if(isSelected)
            {
                ((Form4)this.Owner).Index = index;
            }
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("meciuri.dat", FileMode.OpenOrCreate,
                FileAccess.Write);
            bf.Serialize(fs, lista2);
            fs.Close();
            listBoxMeciuri.Items.Clear();
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("meciuri.dat", FileMode.Open,
                FileAccess.Read);
            List<Meci> listaNoua = (List<Meci>)bf.Deserialize(fs);
            foreach (Meci meci in listaNoua)
            {
                listBoxMeciuri.Items.Add(meci.ToString());
            }
            fs.Close();
        }
    }
}
