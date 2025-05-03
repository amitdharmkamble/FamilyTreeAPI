
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
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();

            builder.Services.AddOpenApi(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;
            });

            var app = builder.Build();

            app.MapOpenApi();

            app.UseHttpsRedirection();

            app.UseCors("AllowPort4200");

            app.UseAuthorization();

            app.MapGet("/", () => "Hello, World!");

            app.MapPost("/createfamilytree", (string name) =>
            {
                Console.WriteLine(name);
                return Results.Ok($"Family tree '{name}' created.");
            });

            app.MapControllers();

            app.Run();
        }
    }
}
