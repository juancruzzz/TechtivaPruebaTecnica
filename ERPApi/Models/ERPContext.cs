using Microsoft.EntityFrameworkCore;

namespace TechtivaERPApi.Models
{
    /// <summary>
    /// Database context for the ERP application, handling the connection to the database
    /// and providing DbSet properties for entity access.
    /// </summary>
    public class ERPContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the ERPContext class.
        /// </summary>
        /// <param name="options">Options to configure the context.</param>
        /// <exception cref="ArgumentNullException">Thrown when options is null.</exception>
        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options ?? throw new ArgumentNullException(nameof(options)))
        {
        }

        /// <summary>
        /// Gets or sets the Clients DbSet.
        /// </summary>
        public DbSet<Client> Clients { get; set; } = null!;

        /// <summary>
        /// Configures the entity mappings for the model.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional de la entidad Client si es necesario.
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20);
            });
        }
    }
}
