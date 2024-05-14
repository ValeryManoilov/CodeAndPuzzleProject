public interface ILessonRepository
{
    public void Add(LessonDataForm dataForm);
    public void Delete(int lessonId);
    public void Edit(LessonDataForm lessonDataForm);
    public void Mark(int userId, int lessonId, int mark);
    public void AddFavourite(int userId, int lessonId);
    public void DeleteFavourite(int userId, int lessonId);
    public List<GetLessonsResponseData> GetLessonsNonAuthUser();
    public List<GetLessonsResponseData> GetLessonsAuthUser(int userId);
    public GetLessonResponseData GetLesson(int lessonId);
}