namespace _06212024_s1_progetto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string scelta, nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza;
            double redditoAnnuale;

            do
            {
                Console.Write("Inserire un nome: ");
                nome = Console.ReadLine();
                Console.Write("Inserire un cognome: ");
                cognome = Console.ReadLine();
                Console.Write("Inserire data di nascita: ");
                dataNascita = Console.ReadLine();
                Console.Write("Inserire codice fiscale: ");
                codiceFiscale = Console.ReadLine();
                Console.Write("Inserire generalità: ");
                sesso = Console.ReadLine();
                Console.Write("Inserire comune di residenza: ");
                comuneResidenza = Console.ReadLine();
                Console.Write("Inserire reddito annuale: ");
                redditoAnnuale = Convert.ToDouble(Console.ReadLine());
                Contribuente c1 = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);
                c1.riepilogo();
                Console.WriteLine("Vuoi verificare un altro conribuente? (si - no)");
                scelta = Console.ReadLine();
            }
            while (scelta != "no");
            
            
        }
    }
}
