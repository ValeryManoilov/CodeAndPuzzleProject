public interface ILessonManager
{
    // Уроки
    void AddLesson(Lesson lesson);
    void DeleteLesson(int id);
    void EditLesson(int id, string newName);
    void MarkLesson(int id, int mark);
    List<Lesson> AllLessons();
    // Контент
    void AddLessonContent(LessonContent lessonContent);
    void DeleteLessonContent(int id);
    void EditLessonContent(int id, string newContentPath);
    // Рейтинг
    void AddLessonRating(LessonsRating lessonRating);
    void DeleteLessonRating(int id);
    void EditLessonRating(int id, int newRating);
    // Теги
    void AddLessonTag(LessonTag lessonTag);
    void DeleteLessonTag(int id);
    void EditLessonTag(int id, string newTagName);
}