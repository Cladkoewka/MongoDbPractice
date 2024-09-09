using MongoDbPractice.API.Middlewares;
using MongoDbPractice.Logic;
using MongoDbPractice.Persistence;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddScoped<CustomerService>();
services.AddSingleton<MongoRepository>(rep => 
    new MongoRepository(
        builder.Configuration.GetConnectionString("DbConnection")
    ));
services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.MapGet("/", () => "MongoDB Practice");

app.Run();


