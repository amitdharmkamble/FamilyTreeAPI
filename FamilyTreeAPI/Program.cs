
using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Repositories;
using FamilyTreeAPI.Repositories.Interfaces;
using FamilyTreeAPI.Services;
using FamilyTreeAPI.Services.Interfaces;
using FamilyTreeAPI.ViewModels;
using Microsoft.OpenApi;

namespace FamilyTreeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowPort4200", policy =>
                {
                    policy.WithOrigins("https://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            builder.Services.AddOpenApi(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;
            });

            builder.Services.AddScoped<ICreatorRepo, CreatorRepo>();
            builder.Services.AddScoped<ICreatorService, CreatorService>();

            var app = builder.Build();

            app.MapOpenApi();

            app.UseHttpsRedirection();

            app.UseCors("AllowPort4200");

            app.UseAuthorization();

            app.MapGet("/", () => "Hello, World!");

            var todoItems = app.MapGroup("/api");

            todoItems.MapPost("/createcreator", CreateCreator);


            app.Run();
        }

        private static Task<IResult> CreateCreator(CreateCreatorRequest request, CreateCreatorRequest response)
        {
            throw new NotImplementedException();
        }
    }
}
