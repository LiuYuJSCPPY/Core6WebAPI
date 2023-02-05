using aspnetWebApi.Data;
using Microsoft.EntityFrameworkCore;
using aspnetWebApi.Interface;
using aspnetWebApi.Porteis;

var builder = WebApplication.CreateBuilder(args);
string CrossMyPolicy = "_CorssMyPolicy";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ASPWewbApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ASPWewbApiContext")));

builder.Services.AddScoped<IPost, PostCrudServier>();


builder.Services.AddCors(options => options.AddPolicy(name: CrossMyPolicy, policy =>
{
    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
})
) ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CrossMyPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
