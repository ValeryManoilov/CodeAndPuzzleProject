public class LessonTag{
    public int Id { get; set; }
    public int? LessonId { get; set; }
    public string? TagName { get; set; }
    
    public LessonTag () { }

    public LessonTag(int id, int lessonId, string tagName){
        Id = id;
        LessonId = lessonId;
        TagName = tagName;
    }
}