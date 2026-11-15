using Velo.Api.Extensions;
using Velo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Infrastructure Services (DbContext & Identity)
builder.Services.AddInfrastructureDependencyInjection(builder.Configuration);

// Add Swagger with JWT Support
builder.Services.AddSwaggerDocumentation();

// Add JWT Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Redirect root to Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapControllers();

app.Run();
