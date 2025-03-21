using CrudOperationsRazor.Application;
using CrudOperationsRazor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddApplicationServices(builder.Configuration); 
builder.Services.AddInfrastructureServices(connectionString,builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapGet("/", context =>
{
    context.Response.Redirect("/Products");
    return Task.CompletedTask;
});

app.Run();
