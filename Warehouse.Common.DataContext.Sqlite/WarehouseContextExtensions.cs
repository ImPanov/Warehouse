using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pckt.Shared;

public static class WarehouseContextExtensions
{
    /// <summary>
    /// Adds WarehouseContext to the specified IServiceCollection, Uses the Sqlite database providers
    /// </summary>
    /// <param name="services"></param>
    /// <param name="relativePath"></param> Set override the default of ".."></param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddWarehouseContext(
        this IServiceCollection services, string relativePath = "../Warehouse.Common.DataContext.Sqlite/"
        )
    {
        string databasePath = Path.Combine(relativePath, "Warehouse.db");

        services.AddDbContext<WarehouseContext>(options =>
        {
            options.UseSqlite(databasePath);

            options.LogTo(
                WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting }
                );
        });
        return services;
    }
}
