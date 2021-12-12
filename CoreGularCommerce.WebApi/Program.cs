using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Repo.Data;
using CoreGularCommerce.Repo.Data.Repository;
using CoreGularCommerce.Repo.Data.SeedData;
using CoreGularCommerce.WebApi.Errors;
using CoreGularCommerce.WebApi.Extensions;
using CoreGularCommerce.WebApi.Helper;
using CoreGularCommerce.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options => {
    options.UseSqlite(connectionString);
});


builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices();
builder.Services.ApplicationServices();
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", policy => {
       policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7012"); 
    });
});

var app = builder.Build();
using(var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try {
        var context = services.GetRequiredService<StoreContext>();
        await context.Database.MigrateAsync();
        await StoreContextSeed.SeedAsync(context, loggerFactory);
    } catch(Exception ex) {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Bir hata oluştu");
    }
}

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentationBuilder();
}

app.UseStatusCodePagesWithReExecute("/api/Error/{0}");

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();


app.Run();
