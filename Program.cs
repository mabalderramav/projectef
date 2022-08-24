using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TaskDB"));
// builder.Services.AddSqlServer<TasksContext>("Data Source=(local); Initial Catalog= TaskDb;Trusted_Connection=True; Integrated Security=True");
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTask"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Database in memory: {dbContext.Database.IsInMemory()}");
});

app.Run();
