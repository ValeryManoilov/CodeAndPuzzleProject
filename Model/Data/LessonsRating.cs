public class LessonsRating{
    public int Id { get; set; }
    public int? LessonId { get; set; }
    public int? MarkCount { get; set; }
    public int? Rating { get; set; }

    public LessonsRating () { }

    public LessonsRating(int id, int lessonId, int markCount, int contentType, int rating){
        Id = id;
        LessonId = lessonId;
        MarkCount = markCount;
        Rating = rating;
    }
}