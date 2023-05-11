using System;
using System.Globalization;

namespace Agentie_Pariuri
{
    public class Bilet
    {
        string id;
        Persoana persoana;
        string data;
        Pariu[] pariuri;
        float[] cote;
        int sumaPariata;
        float castigPosibil;

        public Bilet()
        {
            id = "Necunoscut";
            persoana = null;
            data = "Necunoscuta";
            pariuri = null;
            cote = null;
            sumaPariata = 0;
            castigPosibil = 0.0f;
        }

        public Bilet(Persoana persoana, string data, Pariu[] pariuri, int sumaPariata)
        {
            var secunde = DateTime.Now.Ticks;
            var guid = Guid.NewGuid().ToString();
            this.id = guid.Substring(1, 5);
            this.persoana = persoana;

            DateTime dataCopie;

            bool dataValida = DateTime.TryParseExact(data, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie);
            if(dataValida)
            {
                this.data = data;
            }
            else
            {
                this.data = new DateTime().ToString("dd/mm/yyyy");
            }

            this.pariuri = pariuri;
            this.cote = new float[pariuri.Length];
            for(int i = 0; i < pariuri.Length; i++)
            {
                this.cote[i] = pariuri[i].Cota;
            }
            this.sumaPariata = sumaPariata;
            this.castigPosibil = calculareCastig(this.sumaPariata, this.cote);
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                DateTime data;

                bool dataValida = DateTime.TryParseExact(value, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data);

                if (this.data != value && value != null && dataValida)
                    this.data = value;
            }
        }

        public float[] Cote
        {
            get
            {
                return cote;
            }
        }

        public int SumaPariata
        {
            get
            {
                return sumaPariata;
            }
        }

        public float CastigPosibil
        {
            get
            {
                return castigPosibil;
            }
        }

        public float calculareCastig(int sumaPariata, float[] cote)
        {
            float cotaFinala = 1.0f;
            for(int i = 0; i < cote.Length; i++)
            {
                cotaFinala *= cote[i];
            }
            return sumaPariata * cotaFinala;
        }

        public override string ToString()
        {
            string detaliiBilet = "Id: " + id + ", persoana: " + persoana + ", data: " + data + ", pariuri: ";
            for( int i = 0; i < pariuri.Length; i++)
            {
                detaliiBilet += pariuri[i] + ", ";
            }
            detaliiBilet += "cote: ";
            for (int i = 0; i < cote.Length; i++)
            {
                detaliiBilet += cote[i] + ", ";
            }
            detaliiBilet += "suma pariata: " + sumaPariata + ", castig posibil: " + castigPosibil;
            return detaliiBilet;
        }
    }
}
