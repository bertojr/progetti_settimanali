using _07192024_s5_progetto.Models;

namespace _07192024_s5_progetto.Interface
{
    public interface IVerbaleDAO
    {
        Verbale Create(Verbale newVerbale);
        List<Verbale> GetAll();
        List<Verbale> GetTotalViolationsGroupeByTransgressor();
        List<Verbale> GetTotalPointsDeductedGroupeByTransgressor();
        List<Verbale> GetViolationsWithPointsGreaterThan10();
        List<Verbale> GetViolationsWithAmountGreaterThan400();
    }
}
