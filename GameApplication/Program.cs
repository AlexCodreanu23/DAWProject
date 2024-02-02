using Microsoft.EntityFrameworkCore;
using GameApplication.Data;
using GameApplication.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureMyServices();

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



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


using (var scope = app.Services.CreateScope())
{
var roleManager =
    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

var roles = new[] { "Admin", "User" };
foreach (var role in roles)
{
if (!await roleManager.RoleExistsAsync(role))
{
await roleManager.CreateAsync(new IdentityRole(role));
IdentityResult identityResult1 = await roleManager.CreateAsync(new IdentityRole(role));
}
}

}

using (var scope = app.Services.CreateScope())
{
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();


    string email = "admin@admin.com";
    string password = "Test1234,";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.Email = email;
        user.UserName = email;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");

    }

    string email2 = "user@user.com";
    string password2 = "Test456,";
    if (await userManager.FindByEmailAsync(email2) == null)
    {
        var user2 = new IdentityUser();
        user2.Email = email2;
        user2.UserName = email2;

        await userManager.CreateAsync(user2, password2);

        await userManager.AddToRoleAsync(user2, "User");

    }

}
    app.Run();
