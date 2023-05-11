using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Agentie_Pariuri
{
    public class Persoana
    {
        string id;
        string nume;
        string prenume;
        string telefon;
        string email;
        string dataNasterii;
        float sumaCastigata;

        public Persoana()
        {
            id = "Necunoscut";
            nume = "Necunoscut";
            prenume = "Necunoscut";
            telefon = "Necunoscut";
            email = "Necunoscut";
            dataNasterii = "Necunoscuta";
            sumaCastigata = 0;
        }

        public Persoana(string nume, string prenume, string telefon, string email, string dataNasterii, float sumaCastigata)
        {
            var secunde = DateTime.Now.Ticks;
            var guid = Guid.NewGuid().ToString();
            this.id = guid.Substring(1, 5);

            this.nume = nume;
            this.prenume = prenume;

            const string regexTelefon = @"^\(?(07)\)?([0-9]{8})$";
            if(Regex.IsMatch(telefon, regexTelefon))
            {
                this.telefon = telefon;
            }
            else
            {
                this.telefon = "Necunoscut";
            }

            var adresa = new EmailAddressAttribute();
            if(adresa.IsValid(email))
            {
                this.email = email;
            }    
            else
            {
                this.email = "Necunoscut";
            }

            DateTime dataCopie;

            bool dataValida = DateTime.TryParseExact(dataNasterii, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataCopie);
            if (dataValida)
            {
                this.dataNasterii = dataNasterii;
            }
            else
            {
                this.dataNasterii = new DateTime().ToString("dd/mm/yyyy");
            }
            this.sumaCastigata = sumaCastigata;
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string Nume 
        {
            get
            {
                return nume;
            }
            set
            {
                if (this.nume != value && value != null)
                    this.nume = value;
            }
        }

        public string Prenume 
        { 
            get
            {
                return prenume;
            }
            set
            {
                if (this.prenume != value && value != null)
                    this.prenume = value;
            }
        }

        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                const string regexTelefon = @"^\(?(07)\)?([0-9]{8})$";
                if (this.telefon != value && value != null && Regex.IsMatch(value, regexTelefon))
                    this.telefon = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                var adresa = new EmailAddressAttribute();
                if (this.email != value && value != null && adresa.IsValid(value))
                    this.telefon = value;
            }
        }

        public string DataNasterii
        {
            get
            {
                return dataNasterii;
            }
            set
            {
                DateTime data;

                bool dataValida = DateTime.TryParseExact(value, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data);

                if (this.dataNasterii != value && value != null && dataValida)
                    this.dataNasterii = value;
            }
        }

        public float SumaCastigata
        {
            get
            {
                return sumaCastigata;
            }
            set
            {
                if(value !=0)
                    this.sumaCastigata = value;
            }
        }

        public float ModificaSuma(float suma)
        {
            this.sumaCastigata += suma;
            return sumaCastigata;
        }

        public override string ToString()
        {
            string detaliiPersoana = "Id: " +  id + ", nume: " + nume + " " + prenume + ", telefon: " + telefon + ", email: " + email + ", data nasterii: " + dataNasterii + ", suma castigata: " + sumaCastigata;
            return detaliiPersoana;
        }
    }
}
