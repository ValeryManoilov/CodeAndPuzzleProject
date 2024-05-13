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

    
    [HttpDelete("/api/lessons/deletelesson/{id}")]
    public void DeleteLesson(int id)
    {
        _lessonManager.DeleteLesson(id);
    }

    [HttpGet("/api/lessons/editlesson/{id}/{newName}")]
    public void EditLesson(int id, string newName)
    {
        _lessonManager.EditLesson(id, newName);
    }

    [HttpGet("api/lessons/marklesson/{id}/{mark}")]
    public void MarkLesson(int id, int mark)
    {
        _lessonManager.MarkLesson(id, mark);
    }

    [HttpGet("api/lessons/getlessons")]
    public IEnumerable<Lesson> AllLessons()
    {
        return _lessonManager.AllLessons();
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