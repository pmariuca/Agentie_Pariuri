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
    public partial class Form13 : Form
    {
        private string username;
        private string parola;

        private bool userCorect;
        public bool modInchidere;
        public bool UserCorect { get => userCorect; set => userCorect = value; }

        public Form13()
        {
            InitializeComponent();

            this.modInchidere = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.username = tbUsername.Text;
            this.parola = tbParola.Text;

            if (username == "mariucapricop" && parola == ")caA)Fw^t2o4")
                UserCorect = true;
            else UserCorect = false;

            this.modInchidere = true;

            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbParola.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
