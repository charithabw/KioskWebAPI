using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Services;
using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5173", "http://localhost:5175", "http://localhost:5176")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IKioskResponse, KioskResponse>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IHomeScreenService, HomeScreenService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductNameService, ProductNameService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IScreenService, ScreenService>();
builder.Services.AddScoped<IPromotionalService, PromotionalService>();
builder.Services.AddScoped<IUserService, UserService>(); // <-- ADD THIS

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost3000");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Combine both file providers into a single CompositeFileProvider
var compositeFileProvider = new CompositeFileProvider(
    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "KioskCMS", "public", "uploads")),
    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "KioskFrontend", "public", "uploads"))
);

// Serve static files from both locations under /uploads
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = compositeFileProvider,
    RequestPath = "/uploads"
});

app.Run();
