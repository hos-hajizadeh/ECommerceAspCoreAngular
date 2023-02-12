using ECommerce.Catalog.Api.Controllers;
using ECommerce.Catalog.Application;
using ECommerce.Catalog.Data;
using ECommerce.Web.Framework;
using ECommerce.Web.Framework.Mvc.Filters;
using FluentValidation;

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