using FluentValidation;
using PhoneBookApi.Business.Abstract;
using PhoneBookApi.Business.Concrete;
using PhoneBookApi.Core.ValidationRules;
using PhoneBookApi.DataAccess.EFCoreBase;
using PhoneBookApi.DataAccess.EFCoreBase.Abstract;
using PhoneBookApi.DataAccess.EFCoreBase.Concrete;
using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;
using PhoneBookUI.ApiServices;

var builder = WebApplication.CreateBuilder(args);


// Service configuration
builder.Services.AddHttpClient<PersonApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44342/"); // API Base URL
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPersonService, PersonManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IValidator<PersonDTO>, PersonValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
