using RedSocial.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RedSocial.Infraestructure.Persistence.Contexts
{
  
   public class ApplicationContext : DbContext
   {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Tabla

            modelBuilder.Entity<Comentario>()
                .ToTable("Comentarios");

            modelBuilder.Entity<Amigo>()
              .ToTable("Amigos");

            modelBuilder.Entity<Post>()
              .ToTable("Posts");




            #endregion

            #region Claves primarias

            modelBuilder.Entity<Comentario>()
                .HasKey(c => c.ID);

            modelBuilder.Entity<Post>()
            .HasKey(c => c.ID);

            modelBuilder.Entity<Amigo>()
            .HasKey(c => c.ID);


            #endregion

            #region Relaciones

            modelBuilder.Entity<Post>()
                .HasMany(d => d.Comentarios)
                .WithOne(a => a.Post)
                .HasForeignKey(a => a.PostID)
                .OnDelete(DeleteBehavior.Cascade);


           
            #endregion

            #region Property Configuration

            #region Comment

            modelBuilder.Entity<Comentario>().
               Property(d => d.Text)
            .IsRequired();

            modelBuilder.Entity<Comentario>().
               Property(d => d.Created)
            .IsRequired();

         


            #endregion

            #region Post

            modelBuilder.Entity<Post>().
               Property(d => d.Created)
            .IsRequired();


            #endregion







            #endregion





        }





    }
}
