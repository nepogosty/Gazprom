namespace Gazprom.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BTContext : DbContext
    {
        public BTContext()
            : base("name=BTContext")
        {
        }

        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Business_trip> Business_trip { get; set; }
        public virtual DbSet<Code_access> Code_access { get; set; }
        public virtual DbSet<Counterparty> Counterparty { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subdivision> Subdivision { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tariff_daily> Tariff_daily { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Code_access>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Code_access)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Business_trip)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Business_trip)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subdivision>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Subdivision)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tariff_daily>()
                .HasMany(e => e.Business_trip)
                .WithRequired(e => e.Tariff_daily)
                .WillCascadeOnDelete(false);
        }
    }
}
