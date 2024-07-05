using HikerWeb.API.Data;
using HikerWeb.API.Hubs;
using HikerWeb.API.Repositories;
using HikerWeb.API.Repositories.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

 builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    

//Added
builder.Services.AddDbContextPool<HikerWebDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HikerWebConnection"))
);

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IClubReposirtory, ClubRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
builder.Services.AddScoped<IUserActivityRepository, UserActivityRepository>();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
{
options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" }); 
        
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie();
//


var app = builder.Build();
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseCors(policy => 
    policy.WithOrigins("https://localhost:7287", "https://localhost:7287")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    //.WithHeaders(HeaderNames.ContentType)
                    .AllowCredentials()

    );
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.MapHub<ChatHub>("/chathub");

app.Run();
        
   