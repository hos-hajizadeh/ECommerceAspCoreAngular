using ECommerce.Catalog.Api.Controllers;
using ECommerce.Catalog.Application;
using ECommerce.Catalog.Data;
using ECommerce.Catalog.Data.Entities;
using ECommerce.Catalog.Data.Persistence.DbContexts;
using ECommerce.Web.Framework;
using ECommerce.Web.Framework.Mvc.Filters;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddCatalogDataServices(builder.Configuration)
    .AddCatalogApplicationServices(builder.Configuration)
    .AddCatalogDataServices(builder.Configuration)
    .AddWebFrameworkServices(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<ProductController>();
builder.Services.AddScoped<ValidationFilter>();

var app = builder.Build();
MigrateDb(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(i =>
{
    i.AllowAnyOrigin();
    i.AllowAnyHeader();
    i.AllowAnyMethod();
});
app.Run();


void MigrateDb(WebApplication webApplication)
{
    var context = ((IApplicationBuilder)webApplication).ApplicationServices.GetService<CatalogContext>();
    try
    {
        context.Database.Migrate();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }

    var productEntities = new List<ProductEntity>
    {
        new()
        {
            Name = "Product A",
            Price = new Money
            {
                Amount = 100,
                Currency = "USD"
            },
            Description = "Product A ........."
        },
        new()
        {
            Name = "Product B",
            Price = new Money
            {
                Amount = 150,
                Currency = "USD"
            },
            Description = "Product B ........."
        },
        new()
        {
            Name = "Product C",
            Price = new Money
            {
                Amount = 200,
                Currency = "USD"
            },
            Description = "Product C ........."
        }
    };
    if (context.Products.Any())
        return;

    context.Products.AddRange(productEntities);
    context.SaveChanges();
}