var builder = WebApplication.CreateBuilder(args);

// adding controllers service
builder.Services.AddControllers();

// Add services to the container.

var app = builder.Build();


app.MapControllers();   
app.Run();