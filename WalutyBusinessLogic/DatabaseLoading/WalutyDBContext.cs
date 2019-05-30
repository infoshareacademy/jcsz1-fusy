using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.LoadingFromFile.DatabaseLoading
{
    public class WalutyDBContext : IdentityDbContext<User>
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyInfo> CurrencyInfos { get; set; }

        public WalutyDBContext(DbContextOptions<WalutyDBContext> options) : base(options)
        {
        }
    }
}
