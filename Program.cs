using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dektoon.Services;
using Dektoon.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDektoonRepositories, DektoonRepositories>(_ => new DektoonRepositories(builder.Configuration.GetConnectionString("SqlServer")));
//builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
//builder.Services.AddScoped<IDektoonRepositories, DektoonRepositories>();
builder.Services.AddScoped<IDektoonServices, DektoonServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


