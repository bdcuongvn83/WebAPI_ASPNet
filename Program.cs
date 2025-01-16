using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIPortal.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAPIPortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAPIPortalContext") ?? throw new InvalidOperationException("Connection string 'WebAPIPortalContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add config CORS to allow access WebAPI - Thêm cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  // Cho phép tất cả origin
              .AllowAnyMethod()  // Cho phép tất cả HTTP methods (GET, POST, PUT, DELETE)
              .AllowAnyHeader(); // Cho phép tất cả headers
    });
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
// allow CORS
app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//TODO muon su dung page
app.UseRouting();
app.MapRazorPages(); // This maps Razor Pages to the URL routing


app.UseAuthorization();

app.MapControllers();

app.Run();
