using TodoApp.Constants;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
            
var app = builder.Build();
app.MapHealthChecks(ApiRoutes.Healthy);
app.Run();
public partial class Program { }