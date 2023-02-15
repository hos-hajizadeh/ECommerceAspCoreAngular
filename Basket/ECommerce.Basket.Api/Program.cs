using ECommerce.Basket.Api.Controllers;
using ECommerce.Basket.Application;
using ECommerce.Basket.Data;
using ECommerce.Basket.Data.Persistence.DbContexts;
using ECommerce.Catalog.Data;
using ECommerce.Web.Framework;
using ECommerce.Web.Framework.Mvc.Filters;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddBasketDataServices(builder.Configuration)
    .AddBasketApplicationServices(builder.Configuration)
    .AddCatalogDataServices(builder.Configuration)
    .AddWebFrameworkServices(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<ShoppingCartController>();
builder.Services.AddScoped<ValidationFilter>();

//App
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
    var context = ((IApplicationBuilder)webApplication).ApplicationServices.GetService<BasketContext>();
    try
    {
        context.Database.Migrate();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}