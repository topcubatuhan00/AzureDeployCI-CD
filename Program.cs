using Microsoft.EntityFrameworkCore;
using Todos.WebAPI.Context;
using Todos.WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/getall", (AppDbContext context) => Results.Ok(
        context.Todos.ToList()
    ));

app.MapGet("/create", (AppDbContext context, string work) =>
{
    var todo = new Todo() { Work = work};
    context.Add(todo);
    context.SaveChanges();  
    Results.Ok(work);
});

using (var scope = app.Services.CreateScope())
{
    var svr = scope.ServiceProvider;
    var context = svr.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.Run();