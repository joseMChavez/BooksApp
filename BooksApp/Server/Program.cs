
using BooksApp.Services;
using BooksApp.Shared.Helpers;

var builder = WebApplication.CreateBuilder(args);
HttpClient client = new();
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Agregamos nuestro servicion mediante Inyecion de dependencias 
builder.Services.AddTransient<IApiService>(x => new  ApiServices(client,Settings.URL));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
