var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
const string CORS_POLICY = "AllowAll";
builder.Services.AddCors(el =>
{
    el.AddPolicy(CORS_POLICY, config =>
    {
        config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});




var app = builder.Build();

app.MapControllers();

app.UseCors(CORS_POLICY);


app.MapGet("/", () => "Hello World!");


app.Run();
