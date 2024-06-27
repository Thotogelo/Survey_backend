using Survey_backend.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.RoutePrefix = string.Empty;
    opt.DocumentTitle = "Survey Data API";
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "DBWebApp v1");
});

// Add services to the container.
builder.Services.Configure<SurveyDatabaseSettings>(
    builder.Configuration.GetSection("Survey_data"));

app.Run();