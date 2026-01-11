var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/getall", () => Results.Ok(new List<string>()
{
    "EXAMPLE 1",
    "EXAMPLE 2",
    "EXAMPLE 3"
}));

app.MapGet("/create", (string work) =>{Results.Ok(work);});

app.Run();