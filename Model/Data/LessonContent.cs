public class LessonContent
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public string ContentType { get; set;}
    public string? Content { get; set; } // Для текстовых статей напрямую это
    public string? ContentStoragePath { get; set;} // Если в contenttype указано, что это фото, видео или презентация
    public int Order { get; set; } // Какой порядок был у элемента в уроке(какое по счету видео, фото и т.д)
}