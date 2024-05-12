public interface ILessonContentsManager
{
    void AddLessonContent(LessonContent lessonContent);
    void DeleteLessonContent(int id);
    void EditLessonContent(int id, string newContentPath);
}