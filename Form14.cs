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
    public partial class Form14 : Form
    {
        private Timer timer;
        public Form14()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;

            textBox1.Text = "Bine ai venit la Pisicile Salbatice!\r\n\r\nPentru o utilizare placuta a aplicatiei am conceput cateva reguli.\r\n1. Pentru a adauga un meci trebuie sa fii administrator. Astfel evitam crearea de Dummy Data.\r\n2. Pentru a-ti adauga pisica la Clubul Pisicilor Salbatice trebuie sa adaugi un bilet si in final acesta sa fie castigator. Nu te supara, vei putea totusi sa vizionezi pisicutele castigatoare.\r\n3. Aplicatia noastra permite salvarea pe computer-ul tau a bazelor de date folosite. Tot ce trebuie sa faci este sa apesi butonul 'Download'.\r\n4. Poti vizualiza biletele jucate in ordinea descrescatoare a sumei care poate fi castigata si poti vedea si un grafic al acestora pe care il poti printa.\r\n5. Avem o placintica care iti va prezenta ponderea tipurilor de pariuri pe care le poti juca la agentia noastra si o poti printa si pe aceasta.\r\n6. Recomandam urmatoarea ordine a operatiilor:\r\n  - daca nu esti inregistrat in baza noastra de date apasa pe 'Inregistrare persoana'\r\n  - adauga-ti propriul tau pariu apasand pe 'Adauga pariu'\r\n  - adauga biletul apasand pe 'Adauga bilet'; in momentul in care iti va aparea o fereastra cu biletul tau poti verifica daca acesta este castigator apasand Click dreapta.\r\n\r\nAcum poti inchide aceasta fereastra, ea se va inchide automat dupa 30 secunde. Speram ca norocul pisicilor salbatice sa fie de partea ta!";

            textBox1.Select(0, 0);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            timer.Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            timer.Dispose();
        }
    }
}
