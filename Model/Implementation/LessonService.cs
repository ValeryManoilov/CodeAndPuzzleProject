public class LessonService : ILessonService
{
    private ILessonRepository _lessonRepository;
    public LessonService(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }
    public void Add(LessonDataForm dataForm)
    {
        _lessonRepository.Add(dataForm);
    }
    public void Delete(int lessonId)
    {
        _lessonRepository.Delete(lessonId);
    }
    public void Edit(LessonDataForm lessonDataForm)
    {
        _lessonRepository.Edit(lessonDataForm);
    }
    public void Mark(int userId, int lessonId, int mark)
    {
        _lessonRepository.Mark(userId, lessonId, mark);
    }
    public void AddFavourite(int userId, int lessonId)
    {
        _lessonRepository.AddFavourite(userId, lessonId);
    }

    public void DeleteFavourite(int userId, int lessonId)
    {
        _lessonRepository.DeleteFavourite(userId, lessonId);
    }

    public List<GetLessonsResponseData> GetLessonsNonAuthUser()
    {
        return _lessonRepository.GetLessonsNonAuthUser();
    }
    public List<GetLessonsResponseData> GetLessonsAuthUser(int userId)
    {
        return _lessonRepository.GetLessonsAuthUser(userId);
    }
    public GetLessonResponseData GetLesson(int lessonId)
    {
        return _lessonRepository.GetLesson(lessonId);
    }
}