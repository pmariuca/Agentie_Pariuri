using System;

public enum TipPariu
{
    Necunoscut,
    Corner,
    Penalty,
    ScorFinal,
    NumarCartonaseRosii,
    NumarCartonaseGalbene,
    NumarGoluri
}

namespace Agentie_Pariuri
{
    [Serializable] public class Pariu
    {

        TipPariu tip;
        string nrPariat;
        float cota;
        Meci meci;

        public Pariu()
        {
            tip = TipPariu.Necunoscut;
            nrPariat = "Necunoscut";
            cota = 0;
            meci = null;
        }

        public Pariu(string tip, string nrPariat, Meci meci)
        {
            if (tip == "Corner")
                this.tip = TipPariu.Corner;
            else if (tip == "Penalty")
                this.tip = TipPariu.Penalty;
            else if (tip == "ScorFinal")
                this.tip = TipPariu.ScorFinal;
            else if (tip == "NumarCartonaseRosii")
                this.tip = TipPariu.NumarCartonaseRosii;
            else if (tip == "NumarCartonaseGalbene")
                this.tip = TipPariu.NumarCartonaseGalbene;
            else if (tip == "NumarGoluri")
                this.tip = TipPariu.NumarGoluri;

            this.nrPariat = nrPariat;
            
            Random rand = new Random();
            double numarRandom = rand.NextDouble();
            string numarFinal = ((numarRandom * 20) + 1).ToString().Substring(0, 4);
            this.cota = float.Parse(numarFinal);

            this.meci = meci;
        }

        public TipPariu Tip
        {
            get
            {
                return tip;
            }
        }

        public string NrPariat
        {
            get 
            { 
                return nrPariat; 
            }
        }

        public float Cota
        {
            get
            {
                return cota;
            }
        }

        public Meci Meci
        {
            get
            {
                return meci;
            }
        }
        public override string ToString()
        {
            string detaliiPariu = Environment.NewLine+"Tip pariu: " + tip + Environment.NewLine + " Pariu: " + nrPariat + Environment.NewLine + " Cota: " + cota + Environment.NewLine + " Meci: " + meci.scrieMeci();
            return detaliiPariu;
        }
    }
}
