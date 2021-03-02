using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
    }
}