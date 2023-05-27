using BussinessLogic.Interfaces;
using BussinessLogic.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using SPU123_Shop_WebApi;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("AzureDb");

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopDbContext>(x => x.UseSqlServer(connStr));

// add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// configure custom services
builder.Services.AddScoped<IProductsService, ProductsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// create middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
