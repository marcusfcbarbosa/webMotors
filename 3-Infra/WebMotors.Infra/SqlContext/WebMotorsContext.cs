using FluentValidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebMotors.Domain.WebMotorsContext.Entities;

namespace WebMotors.Infra.SqlContext
{
    public class WebMotorsContext : DbContext
    {
        private readonly IConfiguration _config;
        public WebMotorsContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public WebMotorsContext(DbContextOptions<WebMotorsContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public DbSet<AnuncioWebMotors> AnuncioWebMotors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebMotorsContext).Assembly);
            modelBuilder.Ignore<Notifiable>();
            modelBuilder.Ignore<Notification>();

            EntityMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void EntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnuncioWebMotors>(entity =>
            {
                entity.ToTable("tb_AnuncioWebmotors").HasKey(e => e.Id);

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
