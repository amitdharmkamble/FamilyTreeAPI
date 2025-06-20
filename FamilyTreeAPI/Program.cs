using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Middlewares;
using FamilyTreeAPI.Repositories;
using FamilyTreeAPI.Repositories.Interfaces;
using FamilyTreeAPI.Services;
using FamilyTreeAPI.Services.Interfaces;
using FamilyTreeAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace FamilyTreeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder);

            var app = builder.Build();

            app.MapOpenApi();

            app.UseHttpsRedirection();

            app.UseCors("AllowPort4200");

            app.UseAuthorization();

            app.UseMiddleware<ExceptionLoggingMiddleware>();

            app.MapGet("/", () => "Hello, World!");

            var creatorItems = app.MapGroup("/api");

            creatorItems.MapPost("/createcreator", async (CreateCreatorRequest request, ICreatorService service) =>
            {
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

            creatorItems.MapPost("/createFamilyTree", async (CreateFamilyTreeRequest request, ICreatorTreeService service) =>
            {
                var familyTree = await service.CreateFamilyTree(request.CreatorId, 
                    request.FamilyTreeName ?? "", 
                    request.FamilyTreeDescription ?? ""
                    );
                return familyTree;
            });

            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
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

            builder.Services.AddDbContext<CreatorContext>( options =>
                options.UseSqlServer(GetConnectionString(builder))
            );
            builder.Services.AddDbContext<FamilyTreeContext>(options =>
                options.UseSqlServer(GetConnectionString(builder))
            );
            builder.Services.AddDbContext<CreatorTreeContext>(options =>
                options.UseSqlServer(GetConnectionString(builder))
            );
            builder.Services.AddDbContext<FamilyMemberContext>(options =>
                options.UseSqlServer(GetConnectionString(builder))
            );
            builder.Services.AddDbContext<CommonContext>(options =>
                options.UseSqlServer(GetConnectionString(builder))
            );
            
            builder.Services.AddScoped<ICreatorRepo, CreatorRepo>();
            builder.Services.AddScoped<ICreatorTreeRepo, CreatorTreeRepo>();
            builder.Services.AddScoped<ICreatorService, CreatorService>();
            builder.Services.AddScoped<ICreatorTreeService, FamilyTreeService>();

            builder.Services.AddAuthorization();
        }

        private static string? GetConnectionString(WebApplicationBuilder builder)
        {
            return builder.Configuration.GetConnectionString("localDbConnection");
        }
    }
}
