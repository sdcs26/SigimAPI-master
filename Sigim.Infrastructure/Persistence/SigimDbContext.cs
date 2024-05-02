using Sigim.Domain;
using Microsoft.EntityFrameworkCore;
using Sigim.Application.Models;

namespace Sigim.Infrastructure.Persistence
{
    public class SigimDbContext : DbContext
    {
        public SigimDbContext(DbContextOptions<SigimDbContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(m => m.Histories)
                .WithOne(n => n.Usuario)
                .HasForeignKey(fk => fk.IdUsuario);

            modelBuilder.Entity<User>()
                .HasMany(m => m.Incomes)
                .WithOne(n => n.Usuario)
                .HasForeignKey(fk => fk.IdUsuario);

            modelBuilder.Entity<User>()
                .HasMany(m => m.UserRoutines)
                .WithOne(n => n.Usuario)
                .HasForeignKey(fk => fk.IdUsuario);

            modelBuilder.Entity<Routine>()
                .HasMany(m => m.RoutineExercises)
                .WithOne(n => n.Rutina)
                .HasForeignKey(fk => fk.IdRutina)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Routine>()
                .HasMany(m => m.UserRoutines)
                .WithOne(n => n.Rutina)
                .HasForeignKey(fk => fk.IdRutina)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exercise>()
                .HasMany(m => m.RoutineExercises)
                .WithOne(n => n.Exercises)
                .HasForeignKey(fk => fk.IdEjercicio)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
