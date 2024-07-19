namespace _07192024_s5_progetto.Models
{
    public class Verbale
    {
        public int Id { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; } 
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti {  get; set; }
        public int AnagraficaID { get; set; }
        public Anagrafica Anagrafica { get; set; }
        public int ViolazioneID { get; set; }
        public TipoViolazione TipoViolazione { get; set; }
    }
}
