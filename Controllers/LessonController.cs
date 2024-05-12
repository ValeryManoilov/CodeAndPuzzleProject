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
}