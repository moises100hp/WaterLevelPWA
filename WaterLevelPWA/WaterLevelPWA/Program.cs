using WaterLevelPWA.Components;
using WaterLevelPWA.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<IWaterLevelService, WaterLevelService>();

var baseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:5001/";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    // Adicione o assembly do projeto Client explicitamente
    .AddAdditionalAssemblies(typeof(WaterLevelPWA.Client._Imports).Assembly);

app.Run();
