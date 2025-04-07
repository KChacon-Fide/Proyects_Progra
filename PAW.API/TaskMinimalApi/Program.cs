using Microsoft.EntityFrameworkCore;
using TaskMinimalApi; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseSqlServer(
        "Server=Yeray1;Database=ProductDB2;Trusted_Connection=true;"
    );
});

// 2. Construimos la aplicación.
var app = builder.Build();

app.MapGet("/tasks", async (TaskDbContext db) => await db.Tasks.ToListAsync())
    .WithName("GetAllTasks")
    .WithTags("Tasks");

app.MapGet("/tasks/{id}", async (TaskDbContext db, int id) =>
    await db.Tasks.FindAsync(id) is AppTask task
        ? Results.Ok(task)
        : Results.NotFound())
    .WithName("GetTaskById")
    .WithTags("Tasks");

app.MapPost("/tasks", async (TaskDbContext db, AppTask newTask) =>
{
    db.Tasks.Add(newTask);
    await db.SaveChangesAsync();
    return Results.Created($"/tasks/{newTask.Id}", newTask);
})
.WithName("CreateTask")
.WithTags("Tasks");

app.MapPut("/tasks/{id}", async (TaskDbContext db, int id, AppTask update) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    task.Title = update.Title;
    task.IsCompleted = update.IsCompleted;
    await db.SaveChangesAsync();
    return Results.Ok(task);
})
.WithName("UpdateTask")
.WithTags("Tasks");

app.MapDelete("/tasks/{id}", async (TaskDbContext db, int id) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();
    return Results.Ok(true);
})
.WithName("DeleteTask")
.WithTags("Tasks");


// 4. Ejecutamos la app
app.Run();
