using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddSingleton<ILessonManager>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LessonProjContext>();
    optionsBuilder.UseSqlite("Data Source=TaskDataBase.db"); 
    var lessonContext = new LessonProjContext(optionsBuilder.Options);
    lessonContext.Database.EnsureCreated(); 
    ILessonManager lessonManager = new LessonManager(lessonContext);

    return lessonManager;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
