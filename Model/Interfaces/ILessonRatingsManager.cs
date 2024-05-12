public interface ILessonRatingsManager
{
    void AddLessonRating(LessonsRating lessonRating);
    void DeleteLessonRating(int id);
    void EditLessonRating(int id, string newRating);
}