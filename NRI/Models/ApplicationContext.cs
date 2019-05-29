using Microsoft.EntityFrameworkCore;
using NRI.Models;

namespace NRI
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        //public DbSet<FileModel> Files { get; set; }
        public  DbSet<Calendar> calendars { get; set; }
        public  DbSet<Equipment> equipments { get; set; }
        public  DbSet<Mode> modes { get; set; }
        public  DbSet<Nomenclature> nomenclatures { get; set; }
        public  DbSet<NomenclatureType> nomenclatureTypes { get; set; }
        public  DbSet<Pattern> patterns { get; set; }
        public  DbSet<Personal> personals { get; set; }
        public  DbSet<ProductionUnit> productionUnits { get; set; }
        public  DbSet<Resource> resources { get; set; }
        public  DbSet<Schedule> schedules { get; set; }
        public  DbSet<Setup> setups { get; set; }
        public  DbSet<TechOperation> techOperations { get; set; }
        public  DbSet<TechOperationNeed> techOperationNeeds { get; set; }
        public  DbSet<TechOperationOut> techOperationOuts { get; set; }
        public  DbSet<TechProcess> techProcesses { get; set; }
        public  DbSet<Tool> tools { get; set; }
        public  DbSet<ReceiptType> receiptTypes { get; set; }
        public  DbSet<ResourceUsageType> resourceUsageTypes { get; set; }
        public  DbSet<CalendarDisplayType> calendarDisplayTypes { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("public");
        //    base.OnModelCreating(modelBuilder);
        //    //optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=50480;Database=postgres;Username=postgres;Password=superuser");
        //}
        //Server=127.0.0.1;Port=58540;Database=NRI;User Id=postgres;Password=superuser;
    }
}
