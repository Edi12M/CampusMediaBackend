using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Models;
namespace CampusMediaBack.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<PostDetail> PostDetails { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Story> Stories { get; set; } = null!;
    public DbSet<University> Universities { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Models.Program> Programs { get; set; } = null!;
    public DbSet<Pedagogue> Pedagogues { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserProfile>()
            .HasKey(up => up.UserId);
        modelBuilder.Entity<UserProfile>()
            .HasOne(up => up.User)
            .WithOne()
            .HasForeignKey<UserProfile>(up => up.UserId);
        modelBuilder.Entity<PostDetail>()
            .HasKey(pd => pd.PostId);
        modelBuilder.Entity<PostDetail>()
            .HasOne(pd => pd.Post)
            .WithOne()
            .HasForeignKey<PostDetail>(pd => pd.PostId);
        modelBuilder.Entity<Review>().HasKey(r => r.Id);
        SeedData(modelBuilder);
    }
    private void SeedData(ModelBuilder modelBuilder)
    {
        // Universities
        modelBuilder.Entity<University>().HasData(
            Enumerable.Range(1, 10).Select(i => new University
            {
                Id = i,
                Name = $"University {i}",
                Rating = 4.0 + i * 0.1
            }).ToArray()
        );
        // Departments
        modelBuilder.Entity<Department>().HasData(
            Enumerable.Range(1, 10).Select(i => new Department
            {
                Id = i,
                Name = $"Department {i}"
            }).ToArray()
        );
        // Programs
        modelBuilder.Entity<Models.Program>().HasData(
            Enumerable.Range(1, 10).Select(i => new Models.Program
            {
                Id = i,
                Name = $"Program {i}",
                Type = i % 3 == 0 ? "PhD" : (i % 2 == 0 ? "Master" : "Bachelor"),
                Department = $"Department {(i % 10) + 1}",
                Rating = 4.0 + i * 0.1
            }).ToArray()
        );
        // Pedagogues
        modelBuilder.Entity<Pedagogue>().HasData(
            Enumerable.Range(1, 10).Select(i => new Pedagogue
            {
                Id = i,
                Name = $"PedagogueName{i}",
                Surname = $"PedagogueSurname{i}",
                University = $"University {(i % 10) + 1}",
                Department = $"Department {(i % 10) + 1}",
                Rating = 4.0 + i * 0.1,
                YearsOfExperience = 5 + i
            }).ToArray()
        );
        // Users
        modelBuilder.Entity<User>().HasData(
            Enumerable.Range(1, 10).Select(i => new User
            {
                Id = i,
                Name = $"User {i}",
                Email = $"user{i}@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword($"password{i}"),
                University = $"University {(i % 10) + 1}",
                Department = $"Department {(i % 10) + 1}",
                ProfileImage = $"https://api.dicebear.com/7.x/avataaars/svg?seed=user{i}",
                Role = "student"
            }).ToArray()
        );
        // Posts
        modelBuilder.Entity<Post>().HasData(
            Enumerable.Range(1, 10).Select(i => new Post
            {
                Id = i,
                UserId = ((i - 1) % 10) + 1,
                Image = $"https://picsum.photos/seed/post{i}/200/300",
                Caption = $"Post Caption {i}",
                Date = DateTime.UtcNow.AddDays(-i).ToString("yyyy-MM-dd")
            }).ToArray()
        );
        // Stories
        modelBuilder.Entity<Story>().HasData(
            Enumerable.Range(1, 10).Select(i => new Story
            {
                Id = i,
                UserId = ((i - 1) % 10) + 1,
                Image = $"https://picsum.photos/seed/story{i}/200/300",
                Username = $"User {((i - 1) % 10) + 1}",
                ViewedBy = new List<int>()
            }).ToArray()
        );
        // Reviews
        modelBuilder.Entity<Review>().HasData(
            Enumerable.Range(1, 10).Select(i => new Review
            {
                Id = i.ToString(),
                TargetType = i % 2 == 0 ? "uni" : "prof",
                TargetId = ((i - 1) % 10) + 1,
                Score = 3 + (i % 3),
                Comment = $"Review Comment {i}",
                ReviewerId = $"{((i - 1) % 10) + 1}",
                Date = DateTime.UtcNow.AddDays(-i).ToString("yyyy-MM-dd")
            }).ToArray()
        );
    }
}