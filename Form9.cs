﻿using System;
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
    public partial class Form9 : Form
    {
        public int index = 0;
        List<Persoana> persoana = new List<Persoana>();
        public Form9(List<Persoana> listaPersoane)
        {
            InitializeComponent();
            persoana = listaPersoane;
            foreach (Persoana persoana in listaPersoane)
            {
                lbPersoane.Items.Add(persoana);
            }
        }

        private void lbPersoane_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lbPersoane.Items.Count; i++)
            {
                if (lbPersoane.GetSelected(i))
                {
                    index = i;
                }
            }
            ((Form8)this.Owner).IndexPers = index;
        }
    }
}
