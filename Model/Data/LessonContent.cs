public class LessonContent{
    public int Id { get; set; }
    public int? LessonId { get; set; }
    public string? ContentType { get; set; }
    public string? ContentPath { get; set; }

    
    public LessonContent () { }

    public LessonContent(int id, int lessonId, string contentType, string contentPath){
        Id = id;
        LessonId = lessonId;
        ContentType = contentType;
        ContentPath = contentPath;
    }
}