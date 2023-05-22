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
    public partial class Form15 : Form
    {
        public int corner;
        public int penalty;
        public int scor;
        public int rosii;
        public int galbene;
        public Form15(int pieCorner, int piePenalty, int pieScor, int pieRosii, int pieGalbene)
        {
            InitializeComponent();

            corner = pieCorner;
            penalty = piePenalty;
            scor = pieScor;
            rosii = pieRosii;
            galbene = pieGalbene;

            panel1.Paint+=panel1_Paint;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = panel1.ClientRectangle;

            float total = corner + penalty + scor + rosii + galbene;
            float cornerAngle = 360f * corner / total;
            float penaltyAngle = 360f * penalty / total;
            float scorAngle = 360f * scor / total;
            float rosiiAngle = 360f * rosii / total;
            float galbeneAngle = 360f * galbene / total;

            Color cornerColor = Color.MistyRose;
            Color penaltyColor = Color.Pink;
            Color scorColor = Color.MediumVioletRed;
            Color rosiiColor = Color.DeepPink;
            Color galbeneColor = Color.Orchid;

            using (SolidBrush brush = new SolidBrush(cornerColor))
            {
                g.FillPie(brush, bounds, 0, cornerAngle);
                DrawPercentage(g, brush, bounds, 0, cornerAngle, (float)corner / total, "Corner");
            }

            using (SolidBrush brush = new SolidBrush(penaltyColor))
            {
                g.FillPie(brush, bounds, cornerAngle, penaltyAngle);
                DrawPercentage(g, brush, bounds, cornerAngle, penaltyAngle, (float)penalty / total, "Penalty");
            }

            using (SolidBrush brush = new SolidBrush(scorColor))
            {
                g.FillPie(brush, bounds, cornerAngle + penaltyAngle, scorAngle);
                DrawPercentage(g, brush, bounds, cornerAngle + penaltyAngle, scorAngle, (float)scor / total, "ScorFinal");
            }

            using (SolidBrush brush = new SolidBrush(rosiiColor))
            {
                g.FillPie(brush, bounds, cornerAngle + penaltyAngle + scorAngle, rosiiAngle);
                DrawPercentage(g, brush, bounds, cornerAngle + penaltyAngle + scorAngle, rosiiAngle, (float)rosii / total, "NumarCartonaseRosii");
            }

            using (SolidBrush brush = new SolidBrush(galbeneColor))
            {
                g.FillPie(brush, bounds, cornerAngle + penaltyAngle + scorAngle + rosiiAngle, galbeneAngle);
                DrawPercentage(g, brush, bounds, cornerAngle + penaltyAngle + scorAngle + rosiiAngle, galbeneAngle, (float)galbene / total, "NumarCartonaseGalbene");
            }

        }
        private void DrawPercentage(Graphics g, Brush brush, RectangleF bounds, float startAngle, float sweepAngle, float percentage, string text)
        {
            float centerX = bounds.Left + bounds.Width / 2;
            float centerY = bounds.Top + bounds.Height / 2;

            // angle center of pie
            float angle = startAngle + sweepAngle / 2;

            // radius felii mai subtiri
            float radius = Math.Min(bounds.Width, bounds.Height) / 2;

            // coordonate text
            float x = centerX + (radius * 0.75f) * (float)Math.Cos(angle * Math.PI / 180);
            float y = centerY + (radius * 0.75f) * (float)Math.Sin(angle * Math.PI / 180);

            string percentageText = $"{(percentage * 100):0}%";
            string displayText = $"{text} {percentageText}";

            using (Font font = new Font(Font.FontFamily, Font.Size * 1.2f, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                SizeF textSize = g.MeasureString(displayText, font);

                x -= textSize.Width / 2;
                y -= textSize.Height / 2;

                g.DrawString(displayText, font, textBrush, x, y);
            }
        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.MarginBounds;

            float total = corner + penalty + scor + rosii + galbene;
            float cornerAngle = 360f * corner / total;
            float penaltyAngle = 360f * penalty / total;
            float scorAngle = 360f * scor / total;
            float rosiiAngle = 360f * rosii / total;
            float galbeneAngle = 360f * galbene / total;

            Color cornerColor = Color.MistyRose;
            Color penaltyColor = Color.Pink;
            Color scorColor = Color.MediumVioletRed;
            Color rosiiColor = Color.DeepPink;
            Color galbeneColor = Color.Orchid;

            using (SolidBrush brush = new SolidBrush(cornerColor))
            {
                g.FillPie(brush, bounds, 0, cornerAngle);
                DrawPercentage(g, brush, bounds, 0, cornerAngle, (float)corner / total, "Corner");
            }

            using (SolidBrush brush = new SolidBrush(penaltyColor))
            {
                g.FillPie(brush, bounds, cornerAngle, penaltyAngle);
                DrawPercentage(g, brush, bounds, cornerAngle, penaltyAngle, (float)penalty / total, "Penalty");
            }

            using (SolidBrush brush = new SolidBrush(scorColor))
            {
                g.FillPie(brush, bounds, cornerAngle + penaltyAngle, scorAngle);
                DrawPercentage(g, brush, bounds, cornerAngle + penaltyAngle, scorAngle, (float)scor / total, "ScorFinal");
            }

            using (SolidBrush brush = new SolidBrush(rosiiColor))
            {
                g.FillPie(brush, bounds, cornerAngle + penaltyAngle + scorAngle, rosiiAngle);
                DrawPercentage(g, brush, bounds, cornerAngle + penaltyAngle + scorAngle, rosiiAngle, (float)rosii / total, "NumarCartonaseRosii");
            }

            using (SolidBrush brush = new SolidBrush(galbeneColor))
            {
                g.FillPie(brush, bounds, cornerAngle + penaltyAngle + scorAngle + rosiiAngle, galbeneAngle);
                DrawPercentage(g, brush, bounds, cornerAngle + penaltyAngle + scorAngle + rosiiAngle, galbeneAngle, (float)galbene / total, "NumarCartonaseGalbene");
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
