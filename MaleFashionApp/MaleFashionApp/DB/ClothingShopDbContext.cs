using MaleFashionApp.Entities;
using MaleFashionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MaleFashionApp.DB;

public class ClothingShopDbContext : DbContext
{
    public DbSet<Form> Forms { get; set; }
    
    public DbSet<Navigate> Navigations { get; set; }
    
    public DbSet<Option> Options { get; set; }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTags> PostTags { get; set; }
    public DbSet<PostCategories> PostCategories { get; set; }
    
    public ClothingShopDbContext(DbContextOptions<ClothingShopDbContext> options)
        : base(options) 
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Option>().HasIndex(o => o.Name).IsUnique();
    }
}