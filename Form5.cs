using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.OleDb;
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
        private string connString;

        public bool verificaVarsta(string data)
        {
            DateTime dataTime = DateTime.ParseExact(data, "dd/MM/yyyy", null);
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
            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(Application.StartupPath, "database_pariuri.accdb");
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
                if (Regex.IsMatch(tbTelefon.Text, @"^(\(?(07)\)?[-\s]?[0-9]{8})$") == false)
                errorProvider1.SetError(tbNume, "Introduceti un numar de telefon valid!");
            else
                if (tbEmail.Text == "")
                errorProvider1.SetError(tbNume, "Introduceti emailul!");
            else
                if (adresa.IsValid(tbEmail.Text)==false)
                errorProvider1.SetError(tbNume, "Introduceti un email valid!");
            else
                if(DateTime.TryParseExact(tbDataNasterii.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie) == false)
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

                        using (OleDbConnection connection = new OleDbConnection(connString))
                        {
                            connection.Open();

                            using (OleDbCommand command = connection.CreateCommand())
                            {
                                command.CommandText = "INSERT INTO Persoane VALUES (?,?,?,?,?,?,?)";
                                command.Parameters.Add("ID", OleDbType.Char).Value = persoana.Id;
                                command.Parameters.Add("nume", OleDbType.Char).Value = nume;
                                command.Parameters.Add("prenume", OleDbType.Char).Value = prenume;
                                command.Parameters.Add("telefon", OleDbType.Char).Value = telefon;
                                command.Parameters.Add("email", OleDbType.Char).Value = email;
                                command.Parameters.Add("dataNasterii", OleDbType.Char).Value = data;
                                command.Parameters.Add("sumaCastigata", OleDbType.Numeric).Value = persoana.SumaCastigata;
                                command.ExecuteNonQuery();
                            }
                        }
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
            if(tbDataNasterii.Text!="")
            {
                if (verificaVarsta(tbDataNasterii.Text))
                {
                    MessageBox.Show("Ai varsta necesara!");
                }
                else
                {
                    MessageBox.Show("Nu ai varsta necesara!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                string numeTabel = "Persoane";
                string query = $"SELECT * FROM {numeTabel}";

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                string fileName = "Persoane.csv";
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                string filePath = Path.Combine(downloadsPath, fileName);

                StringBuilder sb = new StringBuilder();

                ExportToCsv(table, filePath);

                MessageBox.Show($"Tabelul a fost descarcat in: {filePath}");
            }
        }

        private void ExportToCsv(DataTable table, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> numeColoane = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", numeColoane));

            foreach (DataRow row in table.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filePath, sb.ToString());

            string csvContents = File.ReadAllText(filePath);
            MessageBox.Show(csvContents, "CSV Contents");
        }
    }
}
