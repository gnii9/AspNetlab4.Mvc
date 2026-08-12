using Microsoft.EntityFrameworkCore;
using AspNetWeek2.Mvc.Models;

namespace AspNetWeek2.Mvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genres");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(p => p.Price)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(p => p.Genre)
                      .WithMany(c => c.Books)
                      .HasForeignKey(p => p.GenreId);
            });

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Programming" },
                new Genre { Id = 2, Name = "Data Science" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Clean Code",
                    Price = 350000,
                    AvailableCopies = 15,
                    GenreId = 1
                },
                new Book
                {
                    Id = 2,
                    Name = "Design Patterns",
                    Price = 420000,
                    AvailableCopies = 10,
                    GenreId = 1
                },
                new Book
                {
                    Id = 3,
                    Name = "Hands-On Machine Learning",
                    Price = 550000,
                    AvailableCopies = 8,
                    GenreId = 2
                }
            );
        }
    }
}