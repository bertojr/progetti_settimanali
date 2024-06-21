using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06212024_s1_progetto
{
    internal class Contribuente
    {
        private string nome;
        private string cognome;
        private string dataNascita;
        private string codiceFiscale;
        private string sesso;
        private string comuneResidenza;
        private double redditoAnnuale;
        private double imposta;

        public Contribuente(string nome, string cognome, string dataNascita, string codiceFiscale, string sesso, string comuneResidenza, double redditoAnnuale)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.dataNascita = dataNascita;
            this.codiceFiscale = codiceFiscale;
            this.sesso = sesso;
            this.comuneResidenza = comuneResidenza;
            this.redditoAnnuale = redditoAnnuale;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Cognome
        {
            get { return cognome; }
            set { cognome = value; }
        }
        public string DataNascita
        {
            get { return dataNascita; }
            set { dataNascita = value; }
        }
        public string CodiceFiscale
        {
            get { return codiceFiscale; }
            set { codiceFiscale = value; }
        }
        public string Sesso
        {
            get { return sesso; }
            set { sesso = value; }
        }
        public string ComuneResidenza
        {
            get { return comuneResidenza; }
            set { comuneResidenza = value; }
        }
        public double RedditoAnnuale
        {
            get { return redditoAnnuale; }
            set { redditoAnnuale = value; }
        }

        private void calcoloImposta()
        {
            double ecc;
            if (redditoAnnuale < 15000)
            {
                imposta = redditoAnnuale / 100 * 23;
            }
            else if(redditoAnnuale > 15001 && redditoAnnuale < 28000)
            {
                ecc = redditoAnnuale - 15000;
                imposta = (ecc / 100 * 27) + 3450;
            }
            else if (redditoAnnuale > 28001 && redditoAnnuale < 55000)
            {
                ecc = redditoAnnuale - 28000;
                imposta = (ecc / 100 * 38) + 6960;
            }
            else if (redditoAnnuale > 55001 && redditoAnnuale < 75000)
            {
                ecc = redditoAnnuale - 55000;
                imposta = (ecc / 100 * 41) + 17220;
            }
            else
            {
                ecc = redditoAnnuale - 75000;
                imposta = (ecc / 100 * 43) + 25420;
            }
        }
        public void riepilogo()
        {
            calcoloImposta();
            Console.WriteLine($"Conribuente: {nome} {cognome},");
            Console.WriteLine($"nato il {dataNascita},");
            Console.WriteLine($"residente a {comuneResidenza},");
            Console.WriteLine($"codice fiscale: {codiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: {redditoAnnuale}");
            Console.WriteLine($"IMPOSTA DA VERSARE: {Math.Round(imposta, 2)}");

        }
    }
}
