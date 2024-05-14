using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.Repositories;
using InventoryFlow.Service.Services;
using InventoryFlow;
using InventoryFlow.Domain.DTO_s.ApplicationUser;
//--------------------------------------------------------------------------------------------
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
//builder.Services.AddDbContext<HfinventoryFlowContext>(options => 
//options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<IdentityContext>(options =>
       options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var  Services=builder.Services;

Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});
// For Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();
// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };  
});
builder.Services.AddSpaStaticFiles(c => { c.RootPath = "app"; });
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//--------------------------------------------------------------------------------------------
//Register Services
builder.Services.AddScoped(typeof(UnitOfWork<>), typeof(UnitOfWork<>));
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddScoped<VendorService, VendorService>();
builder.Services.AddScoped<UserDataService, UserDataService>();
builder.Services.AddScoped<CategoryService, CategoryService>();
builder.Services.AddScoped<StockService, StockService>();
builder.Services.AddScoped<RequestService, RequestService>();
builder.Services.AddScoped<GeoLevelService, GeoLevelService>();
builder.Services.AddScoped<HealthFacilityService, HealthFacilityService>();
//builder.Services.AddScoped<IHttpContextAccessor, IHttpContextAccessor>();

//--------------------------------------------------------------------------------------------
var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseSpaStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = context =>
    {
        context.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store");
        context.Context.Response.Headers["Pragma"] = "no-cache";
        context.Context.Response.Headers.Append("Expires", "-1");
    }
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "app";
    spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
    {
        OnPrepareResponse = context =>
        {
            // never cache index.html
            if (context.File.Name == "index.html")
            {
                context.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store");
                context.Context.Response.Headers.Append("Expires", "-1");
            }
        }
    };
});
app.MapControllers();
app.Run();
