public interface ILessonService
{
    public void Add(LessonDataForm dataForm);
    public void Delete(int lessonId);
    public void Edit(LessonDataForm lessonDataForm);
    public void Mark(int userId, int lessonId, int mark);
    public void AddFavourite(int userId, int lessonId);
    public void DeleteFavourite(int userId, int lessonId);
    public List<GetLessonsResponseData> GetLessonsNonAuthUser(List<string> tags);
    public List<GetLessonsResponseData> GetLessonsAuthUser(int userId, List<string> tags);
    public GetLessonResponseData GetLesson(int lessonId);
}