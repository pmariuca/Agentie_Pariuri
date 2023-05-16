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
    public partial class Form6 : Form
    {
        public List<int> indexList = new List<int>();
        List<Pariu> pariu = new List<Pariu>();
        public Form6(List<Pariu> listaPariuri)
        {
            InitializeComponent();
            this.pariu=listaPariuri;

            foreach (Pariu pariu in pariu)
            {
                lbPariuri.Items.Add(pariu.ToString());
            }
        }

        private void lbPariuri_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i=0;i<lbPariuri.Items.Count;i++)
            {
                if(lbPariuri.GetSelected(i))
                {
                    indexList.Add(i);
                }
            }
            ((Form8)this.Owner).Pariuri = indexList;
        }
    }
}
