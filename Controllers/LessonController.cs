using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class LessonController : ControllerBase
{
    private readonly ILessonManager _lessonManager;

    public LessonController(ILessonManager lessonManager)
    {
        _lessonManager = lessonManager;
    }   

    [HttpPost("/api/lessons/add")]
    public void AddLesson([FromBody] Lesson lesson)
    {
        _lessonManager.AddLesson(lesson);
    }

    [HttpPost("/api/lessontags/add")]
    public void AddLessonTag([FromBody] LessonTag lessonTag)
    {
        _lessonManager.AddLessonTag(lessonTag);
    }

    [HttpPost("/api/lessonsrating/add")]
    public void AddLessonRating([FromBody] LessonsRating lessonsRating)
    {
        _lessonManager.AddLessonRating(lessonsRating);
    }

    [HttpPost("/api/lessoncontents/add")]
    public void AddLessonContent([FromBody] LessonContent lessonContent)
    {
        _lessonManager.AddLessonContent(lessonContent);
    }
}