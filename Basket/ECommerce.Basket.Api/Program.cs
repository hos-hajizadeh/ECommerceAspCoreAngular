using ECommerce.Basket.Application;
using ECommerce.Basket.Data;
using ECommerce.Catalog.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddBasketDataServices(builder.Configuration)
    .AddBasketApplicationServices(builder.Configuration)
    .AddCatalogDataServices(builder.Configuration);

//App
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