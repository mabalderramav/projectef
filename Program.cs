using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTask"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Database in memory: {dbContext.Database.IsInMemory()}");
});
app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks
    .Include(t => t.Category));
    // .Where(t => t.PriorityTask == projectef.Models.Priority.Low));
});
app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] projectef.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;

    await dbContext.AddAsync(task);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tasks/{id}",
async ([FromServices] TasksContext dbContext, [FromBody] projectef.Models.Task task, [FromRoute] Guid id) =>
{
    var taskActual = dbContext.Tasks.Find(id);
    if (taskActual != null)
    {
        taskActual.CategoryId = task.CategoryId;
        taskActual.Title = task.Title;
        taskActual.PriorityTask = task.PriorityTask;
        taskActual.Description = task.Description;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});


app.Run();
