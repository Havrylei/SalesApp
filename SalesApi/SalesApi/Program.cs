using Microsoft.EntityFrameworkCore;
using SalesApi.Infrastructure;
using SalesApi.Infrastructure.Extensions;
using SalesApi.Services;
using SalesApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddDbContext<SalesDbContext>(options
    => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy => policy
            .WithOrigins(builder.Configuration.GetValue<string>("AllowedCorsOrigins").Split(';'))
            .AllowAnyMethod()
            .AllowAnyHeader()
    )
);

var app = builder.Build();

await app.MigrateAsync();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors();
app.Run();
