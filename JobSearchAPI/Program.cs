using JobSearchAPI;
using JobSearchAPI.Data;
using JobSearchAPI.Services;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allCors",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                        .AllowAnyMethod();
                      });
});



    builder.Services.AddDbContext<DataBaseContext>(
                        opts => opts
                        //  .UseSqlServer("Data Source = localhost; Intial Catalog = JobSearch; UserId=APIAccess; Password=Password001;")
                          .UseSqlServer("Data Source=.;Initial Catalog=JobSearch;Persist Security Info=False;User ID=APIAccess;Password=Password001;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;")
                    );


builder.Services.AddTransient<JobSearchService>();
builder.Services.AddTransient<JobDetailsService>();
builder.Services.AddTransient<JobStorageService>();

builder.Services.AddTransient<DataBaseContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("allCors");

app.MapControllers();

app.Run();
