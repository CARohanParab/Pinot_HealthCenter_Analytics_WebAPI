using Microsoft.EntityFrameworkCore;
using Pinot_HealthCenter_Analytics_WebAPI.Models;

namespace Pinot_HealthCenter_Analytics_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
