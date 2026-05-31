using Microsoft.EntityFrameworkCore;
using MyLibrary.DataAccess.Repositories;
using MyLibrary.DataAccess;
using MyLibrary.Core.Abstractions;
using MyLibrary.Core.Services;
using MyLibrary.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Эта магия останавливает бесконечную вложенность
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        
        // По желанию: сделает JSON более читаемым (с отступами)
        options.JsonSerializerOptions.WriteIndented = true;       
    });
builder.Services.AddHttpLogging();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   

builder.Services.AddScoped<IBooksRepository,BooksRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorsRepository,AuthorsRepository>();
builder.Services.AddScoped<IAuthorService,AuthorService>();

builder.Services.AddScoped<IGenresRepository,GenresRepository>();
builder.Services.AddScoped<IGenreService,GenreService>();

builder.Services.AddDbContext<LibraryDbContext> (
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("LibraryDbContext"));
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpLogging();

// app.Use(async (context, next) =>{
//     Console.WriteLine("вход");
    
//     await next();

//     Console.WriteLine("выход");
// });

// app.Use(async (context, next) =>{
//     Console.WriteLine("вход");
    
//     await next();

//     Console.WriteLine("выход");
// });

app.MapControllers(); 

app.Run();
