using Microsoft.EntityFrameworkCore;

namespace WalutyBusinessLogic.LoadingFromFile.DatabaseLoading
{
    public class WalutyDBContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyInfo> CurrencyInfos { get; set; }

        public WalutyDBContext(DbContextOptions<WalutyDBContext> options) : base(options)
        {
        }
    }
}
