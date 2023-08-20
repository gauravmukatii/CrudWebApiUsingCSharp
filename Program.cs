using CrudApi.Data;
using CrudApi.Models;
using CrudApi.Repository.Interfaces;
using CrudApi.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<CrudApiDbContext>(options => options.UseInMemoryDatabase("EmployeeDb");

builder.Services.AddDbContext<CrudApiDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrudApiConnectionString")));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
