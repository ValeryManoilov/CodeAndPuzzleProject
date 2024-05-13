public class LessonManager : ILessonManager
{
    private LessonProjContext _lessonContext;

    public LessonManager(LessonProjContext lessonContext)
    {
        _lessonContext = lessonContext;
    }

    // Урок
    public void AddLesson(Lesson lesson)
    { 
        _lessonContext.Lessons.Add(lesson);
        _lessonContext.SaveChanges();
    }

    public void DeleteLesson(int id)
    { 
        Lesson les = _lessonContext.Lessons.FirstOrDefault(l => l.Id == id);
        _lessonContext.Lessons.Remove(les);
        _lessonContext.SaveChanges();
    }

    public void EditLesson(int id, string newName)
    { 
        Lesson les = _lessonContext.Lessons.FirstOrDefault(l => l.Id == id);
        les.Name = newName;
        _lessonContext.SaveChanges();
    }

    public void MarkLesson(int id, int mark)
    {
        LessonsRating lesrating = _lessonContext.LessonsRatings.FirstOrDefault(lr => lr.LessonId == id);
        lesrating.MarkCount++;
        lesrating.Rating = (lesrating.Rating + mark)/lesrating.MarkCount;
        _lessonContext.SaveChanges();
    }

    public List<Lesson> AllLessons(){
        return _lessonContext.Lessons.ToList();
    }


    // Тег
    public void AddLessonTag(LessonTag lessonTag)
    { 
        _lessonContext.LessonTags.Add(lessonTag);
        _lessonContext.SaveChanges();
    }

    public void DeleteLessonTag(int id)
    { 
        LessonTag lesTag = _lessonContext.LessonTags.FirstOrDefault(lt => lt.Id == id);
        _lessonContext.LessonTags.Remove(lesTag);
        _lessonContext.SaveChanges();
    }

    public void EditLessonTag(int id, string newTagName)
    { 
        LessonTag lesTag = _lessonContext.LessonTags.FirstOrDefault(lt => lt.Id == id);
        lesTag.TagName = newTagName;
        _lessonContext.SaveChanges();
    }


    // Контент
    public void AddLessonContent(LessonContent lessonContent)
    { 
        _lessonContext.LessonContents.Add(lessonContent);
        _lessonContext.SaveChanges();
    }

    public void DeleteLessonContent(int id)
    { 
        LessonContent lesCon = _lessonContext.LessonContents.FirstOrDefault(lc => lc.Id == id);
        _lessonContext.LessonContents.Remove(lesCon);
        _lessonContext.SaveChanges();
    }

    public void EditLessonContent(int id, string newContentPath)
    { 
        LessonContent lesCon = _lessonContext.LessonContents.FirstOrDefault(lc => lc.Id == id);
        lesCon.ContentPath = newContentPath;
        _lessonContext.SaveChanges();
    }


    // Рейтинг
    public void AddLessonRating(LessonsRating lessonRating)
    { 
        _lessonContext.LessonsRatings.Add(lessonRating);
        _lessonContext.SaveChanges();
    }

    public void DeleteLessonRating(int id)
    { 
        LessonsRating lesRat = _lessonContext.LessonsRatings.FirstOrDefault(lr => lr.Id == id);
        _lessonContext.LessonsRatings.Remove(lesRat);
        _lessonContext.SaveChanges();
    }

    public void EditLessonRating(int id, int newRating)
    { 
        LessonsRating lesRat = _lessonContext.LessonsRatings.FirstOrDefault(lr => lr.Id == id);
        lesRat.Rating = newRating;
        _lessonContext.SaveChanges();
    }
}