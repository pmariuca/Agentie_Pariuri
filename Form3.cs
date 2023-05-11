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
    public partial class Form3 : Form
    {
        public int index = -1;
        List<Meci> lista2 = new List<Meci>();
        public Form3(List<Meci> listaMeciuri)
        {
            InitializeComponent();
            lista2 = listaMeciuri;
            foreach(Meci meci in listaMeciuri)
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
            ((Form4)this.Owner).Index = index;
        }
    }
}
