using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
    public partial class Form8 : Form
    {
        private string connString;
        public int IndexPers { get; set; }
        public List<int> Pariuri { get; set; } 

        public List<Pariu> listaP = new List<Pariu>();
        public List<Persoana> listaPers = new List<Persoana>();
        public List<Bilet> listaC = new List<Bilet>();
        public Form8(List<Pariu> listaPariuri, List<Persoana> listaPersoane, List<Bilet> listaCastiguri)
        {
            InitializeComponent();
            listaP = listaPariuri;
            listaPers = listaPersoane;
            listaC = listaCastiguri;

            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(Application.StartupPath, "database_pariuri.accdb");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dataCopie;

            if (tbData.Text == "")
                errorProvider1.SetError(tbData, "Introduceti data!");
            else
                if (!DateTime.TryParseExact(tbData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie))
                    errorProvider1.SetError(tbData, "Introduceti o data valida!");
            else 
                if (dataCopie.Date < DateTime.Today.Date)
                    errorProvider1.SetError(tbData, "Data trebuie sa fie mai mare sau egala cu data de azi!");
            else
                if (numSumaPariata.Value <= 0)
                    errorProvider1.SetError(numSumaPariata, "Suma pariata trebuie sa fie pozitiva!");
            else
            {
                try
                {
                    int indexListaPers = IndexPers;
                    string data = Convert.ToString(tbData.Text);
                    int suma = Convert.ToInt32(numSumaPariata.Value);
                    Pariu[] pariuriAlese = new Pariu[Pariuri.Count];
                    for (int i = 0; i < Pariuri.Count; i++)
                    {
                        pariuriAlese[i] = listaP[Pariuri[i]];
                    }

                    Bilet bilet = new Bilet(listaPers[IndexPers], data, pariuriAlese, suma);

                    listaC.Add(bilet);

                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("bilete.dat", FileMode.OpenOrCreate,
                        FileAccess.Write);
                    bf.Serialize(fs, listaC);
                    fs.Close();

                    Form10 form = new Form10(bilet);
                    form.ShowDialog();

                    listaPers[IndexPers].ModificaSuma(suma);

                    using (OleDbConnection connection = new OleDbConnection(connString))
                    {
                        connection.Open();

                        using (OleDbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Bilete VALUES (?,?,?,?,?,?,?)";
                            command.Parameters.Add("ID", OleDbType.Char).Value = bilet.Id;

                            string persoana = listaPers[indexListaPers].Nume + " " + listaPers[indexListaPers].Prenume;
                            command.Parameters.Add("persoana", OleDbType.Char).Value = persoana;
                            command.Parameters.Add("data", OleDbType.Char).Value = data;

                            string id_string = "";
                            foreach (int id in Pariuri)
                            {
                                id_string += id.ToString() + " ";
                            }
                            command.Parameters.Add("idPariuri", OleDbType.Char).Value = id_string;

                            string cote = "";
                            foreach (Pariu pariu in pariuriAlese)
                            {
                                cote += pariu.Cota + " ";
                            }
                            command.Parameters.Add("cote", OleDbType.Char).Value = cote;
                            command.Parameters.Add("sumaPariata", OleDbType.Integer).Value = suma;
                            command.Parameters.Add("castigPosibil", OleDbType.Double).Value = bilet.CastigPosibil;

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbData.Text = "";
                    numSumaPariata.Value = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form = new Form9(listaPers, true);
            form.Owner = this;
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(listaP, true);
            form.Owner = this;
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                string numeTabel = "Bilete";
                string query = $"SELECT * FROM {numeTabel}";

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                string fileName = "Bilete.csv";
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                string filePath = Path.Combine(downloadsPath, fileName);
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
        }
    }
}
