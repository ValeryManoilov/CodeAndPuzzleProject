public interface ILessonService
{
    public Task Add(LessonDataForm dataForm);
    public Task Delete(int lessonId);
    public Task Edit(LessonDataForm lessonDataForm);
    public Task Mark(int userId, int lessonId, int mark);
    public Task AddFavourite(int userId, int lessonId);
    public Task DeleteFavourite(int userId, int lessonId);
    public List<GetLessonsResponseData> GetLessonsNonAuthUser(List<string> tags);
    public List<GetLessonsResponseData> GetLessonsAuthUser(int userId, List<string> tags);
    public GetLessonResponseData GetLesson(int lessonId);
}