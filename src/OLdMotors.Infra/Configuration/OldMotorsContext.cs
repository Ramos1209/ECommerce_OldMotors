

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OldMotors.Entityes.Entityes;

namespace OLdMotors.Infra.Configuration
{
   public class OldMotorsContext :IdentityDbContext<ApplicationUser>
    {
        public OldMotorsContext(DbContextOptions<OldMotorsContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CompraUsuario> CompraUsuarios { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStrincConnection());
                base.OnConfiguring(optionsBuilder);
            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string GetStrincConnection()
        {
            string str = "Data Source=DESKTOP-OF7OPC1\\SQLEXPRESS;Initial Catalog=OldMotors;Integrated Security=True;";
            return str;
        }
        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}



    }
}
