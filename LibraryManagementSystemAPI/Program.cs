using AutoMapper;
using LibraryManagementSystemAPI.Services;
using LibraryManagementSystemAPI.Shared.AppSettings;
using LibraryManagementSystemAPI.Shared.Logging;
using LibraryManagementSystemAPI.Shared.Mapping;
using LibraryManagementSystemAPI.Shared.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var CORSOpenPolicy = "CORSOpenPolicy";

var appSettings = new AppSettingsConfig();

// Add services to the container.
builder.Configuration.GetSection("ConnectionStrings").Bind(appSettings.ConnectionStrings = new ConnectionStrings());
builder.Configuration.GetSection("StaticVarSettings").Bind(appSettings.StaticVarSettings = new StaticVarSettings());
builder.Services.AddSingleton(appSettings);

//PERSISTENCE
var connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 11));

builder.Services.AddDbContext<DataContext>(options => options.UseMySql(connectionString, serverVersion));

builder.Services.AddTransient<IAppLogger, AppLoggerService>();
builder.Services.AddTransient<IUser, UserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MAPPER
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingService());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(CORSOpenPolicy, builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyOrigin()
               .AllowAnyMethod();
    });

});

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "localhost",
        ValidAudience = "localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.StaticVarSettings.JwtConfigSecret)),
        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(CORSOpenPolicy);

app.Run();
