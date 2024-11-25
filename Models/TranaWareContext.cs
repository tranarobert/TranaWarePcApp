using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TranaWarePc.Models
{
    public class TranaWareContext : IdentityDbContext<ApplicationUser>
    {

        public TranaWareContext(DbContextOptions<TranaWareContext> options) 
            :base(options)
        { }

       // public DbSet<IdentityUser>? Users { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        //public DbSet<Cart>? Carts { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<CPU>? CPUs { get; set; }
        public DbSet<CPUCooler>? CPUCoolers { get; set; }
        public DbSet<GPU>? GPUs { get; set; }
        public DbSet<HDD>? HDDs { get; set; }
        public DbSet<Motherboard>? Motherboards { get; set;}
        public DbSet<Newsletter>? Newsletters { get; set; }
        public DbSet<PCCase>? PCCases { get; set; }
        public DbSet<PcComponent>? PCComponents { get; set; }
        public DbSet<PSU>? PSUs { get; set; }
        public DbSet<RAM>? RAMs { get; set; }
        public DbSet<SSD>? SSDs { get; set; }
        public DbSet<Upgrade>? Upgrades { get; set; }
        public DbSet<CartItem> CartItems {  get; set; }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PcComponent>().HasOne(e => e.CPU).WithOne(e => e.pcComponent).HasForeignKey<CPU>(e => e.PcComponentId);
            modelBuilder.Entity<PcComponent>().HasOne(e => e.CPUCooler).WithOne(e => e.pcComponent).HasForeignKey<CPUCooler>(e => e.PcComponentId);
            modelBuilder.Entity<PcComponent>().HasOne(e => e.GPU).WithOne(e => e.pcComponent).HasForeignKey<GPU>(e => e.PcComponentId);
            modelBuilder.Entity<PcComponent>().HasOne(e => e.HDD).WithOne(e => e.pcComponent).HasForeignKey<HDD>(e => e.PcComponentId);
            modelBuilder.Entity<PcComponent>().HasOne(e => e.Motherboard).WithOne(e => e.pcComponent).HasForeignKey<Motherboard>(e => e.PcComponentId);
            modelBuilder.Entity<PcComponent>().HasOne(e => e.PCCase).WithOne(e => e.pcComponent).HasForeignKey<PCCase>(e => e.PcComponentId);
            modelBuilder.Entity<PcComponent>().HasOne(e => e.PSU).WithOne(e => e.pcComponent).HasForeignKey<PSU>(e => e.PcComponentId);
            modelBuilder.Entity<PcComponent>().HasOne(e => e.RAM).WithOne(e => e.pcComponent).HasForeignKey<RAM>(e => e.PcComponentId);
            modelBuilder.Entity<PcComponent>().HasOne(e => e.SSD).WithOne(e => e.pcComponent).HasForeignKey<SSD>(e => e.PcComponentId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
