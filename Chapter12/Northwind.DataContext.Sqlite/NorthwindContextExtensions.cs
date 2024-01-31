using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Northwind.EntityModels;

public static class NorthwindContextExtentions
{
    public static IServiceCollection AddNorthwindContext( this IServiceCollection services, string relativePath = "..", string databaseName = "Northwind.db")
    {
        string path = Path.Combine(relativePath,databaseName);
        path = Path.GetFullPath(path);
        NorthwindContextLogger.WriteLine($"Database path: {path}");
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
            message: $"{path} not found.", fileName: path);
        }

        services.AddDbContext<NorthwindContext>(options => {
            options.UseSqlite($"Data Source={path}");
            options.LogTo(NorthwindContextLogger.WriteLine,
                new[] { Microsoft.EntityFrameworkCore
                    .Diagnostics.RelationalEventId.CommandExecuting });
        },contextLifetime: ServiceLifetime.Transient,
        optionsLifetime: ServiceLifetime.Transient);

        return services;
    }
}