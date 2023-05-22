using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class Form4 : Form
    {
        private int index;
        private string connString;

        public List<Pariu> listaP = new List<Pariu>();
        public List<Meci> listaM = new List<Meci>();

        public int Index { get => index; set => index = value; }

        public Form4(List<Pariu> listaPariuri, List<Meci> listaMeciuri)
        {
            InitializeComponent();
            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(Application.StartupPath, "database_pariuri.accdb");

            cbTipPariu.Items.Add(TipPariu.Corner);
            cbTipPariu.Items.Add(TipPariu.Penalty);
            cbTipPariu.Items.Add(TipPariu.ScorFinal);
            cbTipPariu.Items.Add(TipPariu.NumarCartonaseRosii);
            cbTipPariu.Items.Add(TipPariu.NumarCartonaseGalbene);

            listaP=listaPariuri;
            listaM=listaMeciuri;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(listaM, true);
            form.Owner = this;
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbTipPariu.SelectedIndex == -1)
                errorProvider1.SetError(cbTipPariu, "Selectati tipul pariului!");
            else
            {
                try
                {
                    string tip = Convert.ToString(cbTipPariu.Text);
                    string nr = Convert.ToString(numPariat.Value);

                    Pariu pariu = new Pariu(tip, nr, listaM[Index]);
                    listaP.Add(pariu);

                    if (tip == "Corner")
                        ((Form1)this.Owner).PieCorner= ((Form1)this.Owner).PieCorner+1;
                    if (tip == "Penalty")
                        ((Form1)this.Owner).PiePenalty= ((Form1)this.Owner).PiePenalty+1;
                    if (tip == "ScorFinal")
                        ((Form1)this.Owner).PieScor= ((Form1)this.Owner).PieScor+1;
                    if (tip == "NumarCartonaseRosii")
                        ((Form1)this.Owner).PieRosii= ((Form1)this.Owner).PieRosii+1;
                    if (tip == "NumarCartonaseGalbene")
                        ((Form1)this.Owner).PieGalbene= ((Form1)this.Owner).PieGalbene+1;

                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("pariuri.dat", FileMode.OpenOrCreate,
                        FileAccess.Write);
                    bf.Serialize(fs, listaP);
                    fs.Close();

                    using (OleDbConnection connection = new OleDbConnection(connString))
                    {
                        connection.Open();

                        using (OleDbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Pariuri (tip, nrPariat, cota, indexMeci) VALUES (?,?,?,?)";
                            command.Parameters.Add("tip", OleDbType.Char).Value = tip;
                            command.Parameters.Add("nrPariat", OleDbType.Char).Value = nr;
                            command.Parameters.Add("cota", OleDbType.Double).Value = pariu.Cota;

                            string meci = listaM[Index].EchipaAcasa + ":" + listaM[Index].EchipaDeplasare;
                            command.Parameters.Add("indexMeci", OleDbType.Char).Value = meci;

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
                    numPariat.Value = 0;
                    cbTipPariu.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(listaP, false);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                string numeTabel = "Pariuri";
                string query = $"SELECT * FROM {numeTabel}";

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                string fileName = "Pariuri.csv";
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
