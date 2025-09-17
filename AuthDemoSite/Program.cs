using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


////////////////////////////////////////
// Authentication/authorization
builder.Services
    .AddAuthorization(options =>
    {
        options.AddPolicy("RequirePawnRole", policy =>
            policy.RequireRole("User.Pawn"));

        options.AddPolicy("RequireBishopRole", policy =>
            policy.RequireRole("User.Bishop"));
    })
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddMicrosoftIdentityWebApp(builder.Configuration, "AzureAd");

builder.Services.Configure<CookieAuthenticationOptions>(
    CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.AccessDeniedPath = "/NoMatchingRole";
    });
////////////////////////////////////////


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();


////////////////////////////////////////
// Authentication/authorization
app
    .UseAuthentication()
    .UseAuthorization();
////////////////////////////////////////


app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
