using _07192024_s5_progetto.Interface;

namespace _07192024_s5_progetto.DAO
{
    public class BaseDAO
    {
        protected readonly ILogger<IAnagraficaDAO> logger;
        protected readonly string connectionString;

        public BaseDAO(ILogger<IAnagraficaDAO> logger, IConfiguration config)
        {
            connectionString = config.GetConnectionString("PoliziaMun")!;
            this.logger = logger;
        }
    }
}
