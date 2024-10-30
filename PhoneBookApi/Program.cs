using FluentValidation;
using PhoneBookApi.Business.Abstract;
using PhoneBookApi.Business.Concrete;
using PhoneBookApi.Core.ValidationRules;
using PhoneBookApi.DataAccess.EFCoreBase;
using PhoneBookApi.DataAccess.EFCoreBase.Abstract;
using PhoneBookApi.DataAccess.EFCoreBase.Concrete;
using PhoneBookApi.Models.DTO;

var builder = WebApplication.CreateBuilder(args);


/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:44360") // UI projesinin URL'si
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});*/


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPersonService, PersonManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IValidator<PersonDTO>, PersonValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
