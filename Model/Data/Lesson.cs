public class Lesson{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<LessonTag>? Tags { get; set; }
    public List<LessonContent>? Contents { get; set; }
    public LessonsRating? Rating { get; set; }

    public Lesson () { }

    public Lesson(int id, string name, string description, List<LessonTag> tags, List<LessonContent> contents, LessonsRating rating){
        Id = id;
        Name = name;
        Description = description;
        Tags = tags;
        Contents = contents;
        Rating = rating;
    }
}