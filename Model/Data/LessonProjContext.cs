using Microsoft.EntityFrameworkCore;

public class LessonProjContext : DbContext
{
 
    public LessonProjContext(DbContextOptions<LessonProjContext> options) : base(options)
    {
    }

    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonsRating> LessonRatings { get; set; }
    public DbSet<LessonTag> LessonTags { get; set; }
    public DbSet<LessonContent> LessonContents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Lesson>().HasKey(l=>l.Id);
        modelBuilder.Entity<LessonsRating>().HasKey(lr=>lr.Id);
        modelBuilder.Entity<LessonTag>().HasKey(lt=>lt.Id);
        modelBuilder.Entity<LessonContent>().HasKey(lc=>lc.Id);

        modelBuilder.Entity<Lesson>()
        .HasOne(l=>l.Rating)
        .WithOne(lr=>lr.LLesson);

        modelBuilder.Entity<Lesson>()
        .HasMany(l=>l.Tags)
        .WithOne(lt=>lt.LLesson);

        modelBuilder.Entity<Lesson>()
        .HasMany(l=>l.Contents)
        .WithOne(lc=>lc.LLesson);

    }
}