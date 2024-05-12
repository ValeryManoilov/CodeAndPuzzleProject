public interface ILessonTagsManager
{
    void AddLessonTag(LessonTag lessonTag);
    void DeleteLessonTag(int id);
    void EditLessonTag(int id, string newTagName);
}