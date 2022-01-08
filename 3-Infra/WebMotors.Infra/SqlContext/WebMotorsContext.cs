using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebMotors.Domain.WebMotorsContext.Entities;

namespace WebMotors.Infra.SqlContext
{
    public class WebMotorsContext : DbContext
    {
        public WebMotorsContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public WebMotorsContext(DbContextOptions<WebMotorsContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=TDAChallenge.DB");//alterar esse nome depois
            }
        }
        public DbSet<AnuncioWebMotors> Medicos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebMotorsContext).Assembly);
            //modelBuilder.Ignore<Notifiable>();
            //modelBuilder.Ignore<Notification>();

            EntityMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void EntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnuncioWebMotors>(entity =>
            {
                entity.ToTable("AnuncioWebMotors").HasKey(e => e.Id);
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");

                entity.Property(e => e.Marca)
                    .HasMaxLength(45)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(45)
                    .HasColumnName("modelo");
                entity.Property(e => e.Versao)
                    .HasMaxLength(45)
                    .HasColumnName("versao");

                entity.Property(e => e.Ano)
                    .HasColumnType("integer")
                    .HasColumnName("ano");

                entity.Property(e => e.Quilometragem)
                    .HasColumnType("integer")
                    .HasColumnName("quilometragem");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(45)
                    .HasColumnName("observacao");
            });
        }
    }
}
