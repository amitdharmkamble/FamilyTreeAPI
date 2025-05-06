using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Repositories;
using FamilyTreeAPI.Repositories.Interfaces;
using FamilyTreeAPI.Services;
using FamilyTreeAPI.Services.Interfaces;
using FamilyTreeAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace FamilyTreeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowPort4200", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();    
                });
            });


            builder.Services.AddOpenApi(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;
            });

            builder.Services.AddDbContext<CreatorContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("localDbConnection")));

            builder.Services.AddScoped<ICreatorRepo, CreatorRepo>();
            builder.Services.AddScoped<ICreatorService, CreatorService>();

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.MapOpenApi();

            app.UseHttpsRedirection();

            app.UseCors("AllowPort4200");

            app.UseAuthorization();

            app.MapGet("/", () => "Hello, World!");

            var creatorItems = app.MapGroup("/api");

            creatorItems.MapPost("/createcreator", async (string firstName, string lastName, ICreatorService service) =>
            {
                CreateCreatorRequest request = new CreateCreatorRequest();
                request.FirstName = firstName;
                request.LastName = lastName;
                Guid result = await service.AddCreatorAsync(request);
                return result != Guid.Empty
                    ? Results.Ok(new { Message = "Creator created successfully.", CreatedCreatorId = result })
                    : Results.BadRequest(new { Message = "Creation failed." });
            });

            creatorItems.MapGet("/getcreator/{id}", async (Guid id, ICreatorService service) =>
            {
                var creator = await service.GetCreatorByIdAsync(id);
                return creator.Id != Guid.Empty
                    ? Results.Ok(creator)
                    : Results.NotFound(new { Message = "Creator not found." });
            });


            app.Run();
        }

    }
}
