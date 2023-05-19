using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class Form11 : Form
    {
        Graphics gr;
        const int marg = 10;
        Color culoare = Color.DeepPink;
        List<Bilet> lista2;
        int nrElem;
        public Form11(List<Bilet> lista)
        {
            InitializeComponent();
            gr = panel1.CreateGraphics();

            lista2 = lista;
            nrElem = lista.Count();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rec = new Rectangle(panel1.ClientRectangle.X + marg,
                    panel1.ClientRectangle.Y + 2 * marg,
                    panel1.ClientRectangle.Width - 2 * marg,
                    panel1.ClientRectangle.Height - 3 * marg);
            Pen pen = new Pen(Color.Pink, 2);
            gr.DrawRectangle(pen, rec);

            double latime = rec.Width / nrElem / 2;
            double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
            double vMax=0;
            foreach(Bilet b in lista2)
            {
                if (b.CastigPosibil > vMax)
                    vMax = b.CastigPosibil;
            }

            Brush br = new SolidBrush(culoare);
            Rectangle[] recs = new Rectangle[nrElem];
            for (int i = 0; i < nrElem; i++)
            {
                recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                    (int)(rec.Location.Y + rec.Height - lista2[i].CastigPosibil / vMax * rec.Height),
                    (int)latime,
                    (int)(lista2[i].CastigPosibil / vMax * rec.Height));
                gr.DrawString(lista2[i].CastigPosibil.ToString(), this.Font,
                    br, recs[i].Location.X, recs[i].Location.Y - this.Font.Height);
            }
            gr.FillRectangles(br, recs);
        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            gr = e.Graphics;
            Rectangle rec = new Rectangle(panel1.ClientRectangle.X + marg,
                    panel1.ClientRectangle.Y + 2 * marg,
                    panel1.ClientRectangle.Width - 2 * marg,
                    panel1.ClientRectangle.Height - 3 * marg);
            Pen pen = new Pen(Color.Pink, 2);
            gr.DrawRectangle(pen, rec);

            double latime = rec.Width / nrElem / 2;
            double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
            double vMax = 0;
            foreach (Bilet b in lista2)
            {
                if (b.CastigPosibil > vMax)
                    vMax = b.CastigPosibil;
            }

            Brush br = new SolidBrush(culoare);
            Rectangle[] recs = new Rectangle[nrElem];
            for (int i = 0; i < nrElem; i++)
            {
                recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                    (int)(rec.Location.Y + rec.Height - lista2[i].CastigPosibil / vMax * rec.Height),
                    (int)latime,
                    (int)(lista2[i].CastigPosibil / vMax * rec.Height));
                gr.DrawString(lista2[i].CastigPosibil.ToString(), this.Font,
                    br, recs[i].Location.X, recs[i].Location.Y - this.Font.Height);
            }
        }

        private void printareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }
    }
}
