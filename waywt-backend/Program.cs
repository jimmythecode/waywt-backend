using Microsoft.Extensions.Options;
using MongoDB.Driver;
using waywt_backend.Models;
using waywt_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// CORS
var MyAllowSpecificOrigins = "waywtCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://waywt.netlify.app",
                                              "http://www.contoso.com")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                      });
});

// Add services to the container.
builder.Services.Configure<WAYWTDatabaseSettings>(
    builder.Configuration.GetSection("WAYWT-Database")); // Gets database connection string and properties from appsettings.json

// Trying 7th March Tutorial
builder.Services.Configure<WAYWTDatabaseSettings>(
                builder.Configuration.GetSection(nameof(WAYWTDatabaseSettings)));
builder.Services.AddSingleton<IWaywtDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<WAYWTDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("WAYWT-Database:ConnectionString")));
// Add the dependency injection to the services.
builder.Services.AddScoped<IUserActionLogService, UserActionLogService>();
builder.Services.AddScoped<ISessionService, SessionService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
