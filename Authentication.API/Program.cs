using Authentication.API.Extension;
using Authentication.Services;
using DigiToll.DataStorage.EntityConfigurations.AccountManagement;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomControllers();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCustomIdentity();
builder.Services.AddDatabaseContexts(builder.Configuration);
builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    //await IdentitySeeder.CreateDefaultUsers(userManager, roleManager, builder.Configuration);
}

app.Run();