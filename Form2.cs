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
    public partial class Form2 : Form
    {
        public List<Meci> lista = new List<Meci>();
        private string connString;
        public Form2(List<Meci> listaMeciuri)
        {
            InitializeComponent();
            lista = listaMeciuri;
            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(Application.StartupPath, "database_pariuri.accdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dataCopie;
            if (tbNumeAcasa.Text == "")
                errorProvider1.SetError(tbNumeAcasa, "Introduceti echipa!");
            else
                if (tbNumeDeplasare.Text == "")
                    errorProvider1.SetError(tbNumeDeplasare, "Introduceti echipa!");
            else
                if (tbData.Text == "")
                    errorProvider1.SetError(tbData, "Introduceti data!");
            else
                if (DateTime.TryParseExact(tbData.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie) == false)
                    errorProvider1.SetError(tbData, "Introduceti o data valida!");
            else
            {
                try
                {
                    string numeAcasa = Convert.ToString(tbNumeAcasa.Text);
                    string numeDeplasare = Convert.ToString(tbNumeDeplasare.Text);
                    string data = Convert.ToString(tbData.Text);
                    int goluriAcasa = Convert.ToInt32(numGolAcasa.Value);
                    int goluriDeplasare = Convert.ToInt32(numGolDeplasare.Value);
                    int nrCornere = Convert.ToInt32(numCornere.Value);
                    int nrPenalty = Convert.ToInt32(numPenalty.Value);
                    int cartonaseRosii = Convert.ToInt32(numRosii.Value);
                    int cartonaseGalbene = Convert.ToInt32(numGalbene.Value);

                    Meci meci = new Meci(numeAcasa, numeDeplasare, data, goluriAcasa, goluriDeplasare, nrCornere, nrPenalty, cartonaseRosii, cartonaseGalbene);
                    lista.Add(meci);

                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("meciuri.dat", FileMode.OpenOrCreate,
                        FileAccess.Write);
                    bf.Serialize(fs, lista);
                    fs.Close();

                    using (OleDbConnection connection = new OleDbConnection(connString))
                    {
                        connection.Open();

                        using (OleDbCommand command = connection.CreateCommand())
                        {
                                command.CommandText = "INSERT INTO Meciuri VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                                command.Parameters.Add("ID", OleDbType.Char).Value = meci.Id;
                                command.Parameters.Add("echipaAcasa", OleDbType.Char).Value = meci.EchipaAcasa;
                                command.Parameters.Add("echipaDeplasare", OleDbType.Char).Value = meci.EchipaDeplasare;
                                command.Parameters.Add("data", OleDbType.Char).Value = meci.Data;
                                command.Parameters.Add("goluriAcasa", OleDbType.Integer).Value = meci.GoluriAcasa;
                                command.Parameters.Add("goluriDeplasare", OleDbType.Integer).Value = meci.GoluriDeplasare;
                                command.Parameters.Add("nrCornere", OleDbType.Integer).Value = meci.NrCornere;
                                command.Parameters.Add("nrPenalty", OleDbType.Integer).Value = meci.NrPenalty;
                                command.Parameters.Add("nrCartonaseRosii", OleDbType.Integer).Value = meci.NrCartonaseRosii;
                                command.Parameters.Add("nrCartonaseGalbene", OleDbType.Integer).Value = meci.NrCartonaseGalbene;
                                command.Parameters.Add("goluri", OleDbType.Integer).Value = meci.TotalGoluri;

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
                    tbNumeAcasa.Clear();
                    tbNumeDeplasare.Clear();
                    tbData.Clear();
                    numGolAcasa.Value = 0;
                    numGolDeplasare.Value = 0;
                    numCornere.Value = 0;
                    numPenalty.Value = 0;
                    numRosii.Value = 0;
                    numGalbene.Value = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(lista, false);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                string numeTabel = "Meciuri";
                string query = $"SELECT * FROM {numeTabel}";

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                string fileName = "Meciuri.csv";
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
