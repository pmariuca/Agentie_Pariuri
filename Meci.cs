using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Agentie_Pariuri
{
    public class Meci
    {
        string id;
        string echipaAcasa;
        string echipaDeplasare;
        string data;
        int goluriAcasa;
        int goluriDeplasare;
        int nrCornere;
        int nrPenalty;
        int nrCartonaseRosii;
        int nrCartonaseGalbene;
        int totalGoluri;

        public Meci()
        {
            id = "Necunoscut";
            echipaAcasa = "Necunoscuta";
            echipaDeplasare = "Necunoscuta";
            data = "Necunoscuta";
            goluriAcasa = 0;
            goluriDeplasare = 0;
            nrCornere = 0;
            nrPenalty = 0;
            nrCartonaseRosii = 0;
            nrCartonaseGalbene = 0;
            totalGoluri = 0;
        }

        public Meci( string echipaAcasa, string echipaDeplasare, string data, int goluriAcasa, int goluriDeplasare, int nrCornere, int nrPenalty, int nrCartonaseRosii, int nrCartonaseGalbene)
        {
            var secunde = DateTime.Now.Ticks;
            var guid = Guid.NewGuid().ToString();
            this.id = guid.Substring(1, 5);

            this.echipaAcasa = echipaAcasa;
            this.echipaDeplasare = echipaDeplasare;

            DateTime dataCopie;

            bool dataValida = DateTime.TryParseExact(data, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie);
            if (dataValida)
            {
                this.data = data;
            }
            else
            {
                this.data = new DateTime().ToString("dd/mm/yyyy");
            }

            this.goluriAcasa = goluriAcasa;
            this.goluriDeplasare = goluriDeplasare;
            this.nrCornere = nrCornere;
            this.nrPenalty = nrPenalty;
            this.nrCartonaseRosii = nrCartonaseRosii;
            this.nrCartonaseGalbene = nrCartonaseGalbene;
            this.totalGoluri = calculeazaGoluri(this.goluriAcasa, this.goluriDeplasare);
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string EchipaAcasa
        {
            get
            {
                return echipaAcasa;
            }
            set
            {
                if (this.echipaAcasa != value && value != null)
                    this.echipaAcasa = value;
            }
        }

        public string EchipaDeplasare
        {
            get
            {
                return echipaDeplasare;
            }
            set
            {
                if (this.echipaDeplasare != value && value != null)
                    this.echipaDeplasare = value;
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
                DateTime dataExemplu;

                bool dataValida = DateTime.TryParseExact(value, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataExemplu);

                if (this.data != value && value != null && dataValida)
                    this.data = value;
            }
        }

        public int GoluriAcasa
        {
            get
            {
                return goluriAcasa;
            }
            set
            {
                if(this.goluriAcasa != value && value >= 0)
                    this.goluriAcasa = value;
            }
        }

        public int GoluriDeplasare
        {
            get
            {
                return goluriDeplasare;
            }
            set
            {
                if (this.goluriDeplasare != value && value >= 0)
                    this.goluriDeplasare = value;
            }
        }

        public int NrCornere
        {
            get
            {
                return nrCornere;
            }
        }

        public int NrPenalty
        {
            get
            {
                return nrPenalty;
            }
        }

        public int NrCartonaseRosii
        {
            get
            {
                return nrCartonaseRosii;
            }
        }

        public int NrCartonaseGalbene
        {
            get
            {
                return nrCartonaseGalbene;
            }
        }

        public int TotalGoluri
        {
            get
            {
                return totalGoluri;
            }
        }

        public int calculeazaGoluri(int goluriAcasa, int goluriDeplasare)
        {
            return goluriAcasa + goluriDeplasare;
        }

        public override string ToString()
        {
            string detaliiMeci = "Id: " + id + ", meci: " + echipaAcasa + " - " + echipaDeplasare + ", data: " + data + ", goluri: " + goluriAcasa + ":" + goluriDeplasare + ", nr. cornere: " + nrCornere + "nr. penalty-uri: " + nrPenalty + ", nr. cartonase rosii: " + nrCartonaseRosii + ", nr. cartonase galbene: " + nrCartonaseGalbene + ", total goluri: " + totalGoluri;
            return detaliiMeci;
        }

    }
}
