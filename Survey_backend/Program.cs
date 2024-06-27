using Survey_backend.Model;
using Survey_backend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SurveyRepository>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Survey API", Version = "v1" });
});

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