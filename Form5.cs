using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class Form5 : Form
    {
        public List<Persoana> listaPers = new List<Persoana>();
        public bool verificaVarsta(string data)
        {
            DateTime dataTime = DateTime.ParseExact(data, "dd/mm/yyyy", null);
            int anCurent = DateTime.Now.Year;
            int diferenta = anCurent - dataTime.Year;
            if (diferenta >= 18)
                return true;
            else 
                return false;
        }

        public Form5(List<Persoana> listaPersoane)
        {
            InitializeComponent();
            listaPers = listaPersoane;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var adresa = new EmailAddressAttribute();
            DateTime dataCopie;

            if (tbNume.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti numele!");
            else
                if (tbPrenume.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti prenumele!");
            else
                if (tbTelefon.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti numarul de telefon!");
            else
                if (Regex.IsMatch(tbTelefon.Text, @"^\(?(07)\)?([0-9]{8})$") == false)
                errorProvider1.SetError(tbNume, "Introduceti un numar de telefon valid!");
            else
                if (tbEmail.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti emailul!");
            else
                if (adresa.IsValid(tbEmail.Text)==false)
                errorProvider1.SetError(tbNume, "Introduceti un email valid!");
            else
                if(DateTime.TryParseExact(tbDataNasterii.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie) == false)
                    errorProvider1.SetError(tbDataNasterii, "Introduceti o data de nastere valida!");
            else
            {
                try
                {
                    string nume = Convert.ToString(tbNume.Text);
                    string prenume = Convert.ToString(tbPrenume.Text);
                    string telefon = Convert.ToString(tbTelefon.Text);
                    string email = Convert.ToString(tbEmail.Text);
                    string data = Convert.ToString(tbDataNasterii.Text);
                    float suma = (float)(numSumaCastigata.Value);

                    if (verificaVarsta(data))
                    {
                        Persoana persoana = new Persoana(nume, prenume, telefon, email, data, suma);
                        listaPers.Add(persoana);

                        BinaryFormatter bf = new BinaryFormatter();
                        FileStream fs = new FileStream("persoane.dat", FileMode.OpenOrCreate,
                            FileAccess.Write);
                        bf.Serialize(fs, listaPers);
                        fs.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nu te poti inregistra daca ai sub 18 ani!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbNume.Clear();
                    tbPrenume.Clear();
                    tbTelefon.Clear();
                    tbDataNasterii.Clear();
                    tbEmail.Clear();
                    numSumaCastigata.Value = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form = new Form9(listaPers, false);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(verificaVarsta(tbDataNasterii.Text))
            {
                MessageBox.Show("Ai varsta necesara!");
            }
            else
            {
                MessageBox.Show("Nu ai varsta necesara!");
            }
        }
    }
}
