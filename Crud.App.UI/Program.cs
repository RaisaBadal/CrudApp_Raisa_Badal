using Crud.App.Core.DbContexti;
using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.Core.Services;
using Crud.App.Infrastructure.Repositories;
using Crud.App.Presentation.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
#region SwaggenGen

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Crud App", Version = "v1" });
   

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Please enter Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    };

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        }, new List<string>() }
    });
});
#endregion

builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<IUserRepos, UserServicesRepos>();
builder.Services.AddScoped<IError, ErrorServices>();
builder.Services.AddScoped<IErrorRepos,ErrorServiceRepos>();
builder.Services.AddScoped<ILog, LogServices>();
builder.Services.AddScoped<ILogRepos, LogServiceRepos>();
builder.Services.AddScoped<IToDo, ToDoServices>();
builder.Services.AddScoped<IToDoRepos, ToDoServiceRepos>();
builder.Services.AddScoped<IPostAndComment, PostAndCommentServices>();
builder.Services.AddScoped<IPostAndCommentRepos, PostAndCommentServiceRepos>();
builder.Services.AddScoped<IAlbumAndPhoto, AlbumAndPhotoServices>();
builder.Services.AddScoped<IAlbumAndPhotoRepos, AlbumAndPhotoServiceRepos>();
builder.Services.AddScoped<IRegAndSignIn, RegAndSignInServices>();
builder.Services.AddScoped<IRegAndSignInRepos, RegAndSignInRepos>();


builder.Services.AddDbContext<DbRaisa>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaisasString"));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIdentity<User, Roles>(io =>
{
    io.Password.RequiredLength = 7;
}).AddEntityFrameworkStores<DbRaisa>().AddDefaultTokenProviders();

#region Authentification
builder.Services.AddAuthentication(ops =>
{
    ops.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    ops.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(ops =>
{
    ops.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("JWT:ISSUER").Value,
        ValidAudience = builder.Configuration.GetSection("JWT:AUDIENCE").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:KEY").Value)),
    };
});


builder.Services.AddAuthorization(ops =>
{
    ops.AddPolicy("ManagerOnly", policy => policy.RequireRole("MANAGER"));
});
#endregion

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

app.Run();
