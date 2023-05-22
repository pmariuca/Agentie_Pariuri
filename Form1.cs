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
using System.Data.OleDb;


namespace Agentie_Pariuri
{
    public partial class Form1 : Form
    {
        public List<Meci> listaMeciuri = new List<Meci>();
        public List<Pariu> listaPariuri = new List<Pariu>();
        public List<Persoana> listaPersoana = new List<Persoana>();
        public List<Bilet> listaCastiguri = new List<Bilet>();

        private int pieCorner = 0;
        private int piePenalty = 0;
        private int pieScor = 0;
        private int pieRosii = 0;
        private int pieGalbene = 0;

        private bool isLoggedIn;

        public int PieCorner { get => pieCorner; set => pieCorner = value; }
        public int PiePenalty { get => piePenalty; set => piePenalty = value; }
        public int PieScor { get => pieScor; set => pieScor = value; }
        public int PieRosii { get => pieRosii; set => pieRosii = value; }
        public int PieGalbene { get => pieGalbene; set => pieGalbene = value; }

        public Form1()
        {
            InitializeComponent();
            isLoggedIn = false;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("meciuri.dat", FileMode.OpenOrCreate,
                FileAccess.Read);
            FileInfo fi = new FileInfo("meciuri.dat");
            if(fi.Length > 0)
            {
                listaMeciuri = (List<Meci>)bf.Deserialize(fs);
            }
            fs.Close();

            BinaryFormatter bf1 = new BinaryFormatter();
            FileStream fs1 = new FileStream("pariuri.dat", FileMode.OpenOrCreate,
                FileAccess.Read);
            FileInfo fi1 = new FileInfo("pariuri.dat");
            if(fi1.Length > 0)
            {
                listaPariuri = (List<Pariu>)bf1.Deserialize(fs1);
            }
            fs1.Close();

            BinaryFormatter bf2 = new BinaryFormatter();
            FileStream fs2 = new FileStream("persoane.dat", FileMode.OpenOrCreate,
                FileAccess.Read);
            FileInfo fi2 = new FileInfo("persoane.dat");
            if (fi2.Length > 0)
            {
                listaPersoana = (List<Persoana>)bf2.Deserialize(fs2);
            }
            fs2.Close();

            BinaryFormatter bf3 = new BinaryFormatter();
            FileStream fs3 = new FileStream("bilete.dat", FileMode.OpenOrCreate,
                FileAccess.Read);
            FileInfo fi3 = new FileInfo("bilete.dat");
            if (fi3.Length > 0)
            {
                listaCastiguri = (List<Bilet>)bf3.Deserialize(fs3);
            }
            fs3.Close();

            Form14 form = new Form14();
            form.ShowDialog();

            TipPariu tip;
            foreach(Pariu pariu in listaPariuri)
            {
                tip = pariu.Tip;

                if (tip.ToString() == "Corner")
                    PieCorner = PieCorner + 1;
                if (tip.ToString() == "Penalty")
                    PiePenalty = PiePenalty + 1;
                if (tip.ToString() == "ScorFinal")
                    PieScor = PieScor + 1;
                if (tip.ToString() == "NumarCartonaseRosii")
                    PieRosii = PieRosii + 1;
                if (tip.ToString() == "NumarCartonaseGalbene")
                    PieGalbene = PieGalbene + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isLoggedIn)
            {
                Form2 form = new Form2(listaMeciuri);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pentru a adauga un meci trebuie sa te conectezi.");

                Form13 form13 = new Form13();
                form13.ShowDialog();
                if (form13.UserCorect)
                {
                    Form2 form = new Form2(listaMeciuri);
                    form.ShowDialog();

                    this.isLoggedIn = true;
                }
                else if (!form13.UserCorect)
                {
                    if (form13.modInchidere == true)
                        MessageBox.Show("Username sau parola incorecta!");
                }
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(listaPariuri, listaMeciuri);
            form.Owner = this;
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5(listaPersoana);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 form = new Form12();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form15 form = new Form15(pieCorner, piePenalty, pieScor, pieRosii, pieGalbene);
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
