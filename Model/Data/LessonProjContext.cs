using Microsoft.EntityFrameworkCore;

public class LessonProjContext : DbContext
{
 
    public LessonProjContext(DbContextOptions<LessonProjContext> options) : base(options)
    {
    }

    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonsRating> LessonsRatings { get; set; }
    public DbSet<LessonTag> LessonTags { get; set; }
    public DbSet<LessonContent> LessonContents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>().HasKey(lesson=>lesson.Id);
        modelBuilder.Entity<LessonsRating>().HasKey(lessonrating=>lessonrating.Id);
        modelBuilder.Entity<LessonTag>().HasKey(lessontag=>lessontag.Id);
        modelBuilder.Entity<LessonContent>().HasKey(lessoncontent=>lessoncontent.Id);
    }
}