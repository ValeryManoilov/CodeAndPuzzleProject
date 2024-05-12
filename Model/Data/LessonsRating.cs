public class LessonsRating{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string MarkCount { get; set; }
    public string Rating { get; set; }

    public Lesson LLesson { get; set; }
    
    public LessonsRating () { }

    public LessonsRating(int id, int lessonId, string markCount, string contentType, string rating, Lesson lesson){
        Id = id;
        LessonId = lessonId;
        MarkCount = markCount;
        Rating = rating;
        LLesson = lesson;
    }
}