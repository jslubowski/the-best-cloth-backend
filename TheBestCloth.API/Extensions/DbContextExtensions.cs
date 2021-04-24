using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheBestCloth.DAL.Data;

namespace TheBestCloth.API.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddPostgresContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostgresContext>(options =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                string connStr;

                if (env == "Development")
                {
                    connStr = configuration.GetConnectionString("PostgreSQLConnection");
                }
                else
                {
                    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                    connUrl = connUrl.Replace("postgres://", string.Empty);
                    var pgUserPass = connUrl.Split("@")[0];
                    var pgHostPortDb = connUrl.Split("@")[1];
                    var pgHostPort = pgHostPortDb.Split("/")[0];
                    var pgDb = pgHostPortDb.Split("/")[1];
                    var pgUser = pgUserPass.Split(":")[0];
                    var pgPass = pgUserPass.Split(":")[1];
                    var pgHost = pgHostPort.Split(":")[0];
                    var pgPort = pgHostPort.Split(":")[1];

                    connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};SSL Mode=Require;TrustServerCertificate=True";
                }

                options.UseNpgsql(connStr);
            });

            return services;
        }
    }
}
