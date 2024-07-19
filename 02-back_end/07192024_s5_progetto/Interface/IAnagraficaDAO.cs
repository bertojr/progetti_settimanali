using _07192024_s5_progetto.Models;

namespace _07192024_s5_progetto.Interface
{
    public interface IAnagraficaDAO
    {
        Anagrafica Create(Anagrafica newTrasngressor);
        List<Anagrafica> GetAll();
    }
}
