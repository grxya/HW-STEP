using HW1.Data.DbContexts;
using Task = HW1.Data.Models.Task;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/addtask", async (TaskManagementDbContext db, Task task) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/gettasks", task);
})
    .WithOpenApi()
    .WithName("AddTask")
    .WithDescription("Add task to database");


app.MapGet("/getalltasks", async (TaskManagementDbContext db) =>
{
    return await db.Tasks.ToListAsync<Task>();
})
    .WithOpenApi()
    .WithName("GetAllTasks")
    .WithDescription("Get all tasks from database");


app.MapGet("/gettask/{id}", async (TaskManagementDbContext db, int id) =>
{
    Task task = await db.Tasks.FindAsync(id);

    if (task == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(task);
})
    .WithOpenApi()
    .WithName("GetTask")
    .WithDescription("Get task from database by its ID");


app.MapPut("/edittask", async (TaskManagementDbContext db, Task edited) =>
{
    Task task = await db.Tasks.FindAsync(edited.Id);

    if (task == null)
    {
        return Results.NotFound();
    }

    task.Name = edited.Name ?? task.Name;
    task.Description = edited.Description ?? task.Description;
    Console.WriteLine(edited.Deadline.ToShortDateString());
    task.Deadline = edited.Deadline.ToShortDateString() != "01.01.0001" ? edited.Deadline : task.Deadline;

    await db.SaveChangesAsync();
    return Results.Ok(task);
})
    .WithOpenApi()
    .WithName("EditTask")
    .WithDescription("Edit task from database");


app.Run();


