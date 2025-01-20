
using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Configuration;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebAPI.Data_Access;
using WebAPI.Data_Access.Database;
using WebAPI.Services;
using WebAPI.Swagger;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            InitLogging(builder);

            InitCors(builder);

            InitAutoMapper(builder);

            InitDatabase(builder);

            InitIdentity(builder);

            InitApiVersioning(builder);

            InitServices(builder);

            builder.Services.AddControllers();
            

            var app = builder.Build();

            UseSwagger(app);

            UseCors(app);

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();

            app.MapIdentityApi<Models.AppUser>();
            app.MapControllers();
            app.MapRazorPages();
            app.Run();
        }

        private static void InitLogging(WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, services, configuration) =>
            {
                configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                ;
            });
        }

        private static void InitCors(WebApplicationBuilder builder)
        {
            var CORSDebugPolicy = "_CORSDebugPolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CORSDebugPolicy,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost",
                                                         "https://localhost");
                                  });
            });

            var CORSReleasePolicy = "_CORSReleasePolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CORSReleasePolicy,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://mydomain.com",
                                                         "https://mydomain.com");
                                  });
            });
        }

        private static void UseCors(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("_CORSDebugPolicy");
            }
            else
            {
                app.UseCors("_CORSReleasePolicy");
            }
        }

        private static void InitAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
        }

        private static void InitDatabase(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("sqlite") ?? "Data Source=test.db";
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlite(connectionString)
            );
        }

        private static void InitIdentity(WebApplicationBuilder builder)
        {
            builder.Services.AddDefaultIdentity<Models.AppUser>(options =>
                options.SignIn.RequireConfirmedAccount = true
            )
            .AddRoles<Models.AppRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            ;

            builder.Services.AddAuthorization();
        }

        private static void InitApiVersioning(WebApplicationBuilder builder)
        {
            var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ReportApiVersions = true;
                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));
            });
            apiVersioningBuilder.AddApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            builder.Services.AddSwaggerGen(options =>
            {
                // Add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();
            });
        }

        private static void UseSwagger(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var descriptions = app.DescribeApiVersions();

                    // Build a swagger endpoint for each discovered API version
                    foreach (var description in descriptions)
                    {
                        var url = $"/swagger/{description.GroupName}/swagger.json";
                        var name = description.GroupName.ToUpperInvariant();
                        options.SwaggerEndpoint(url, name);
                    }
                });
            }
        }

        private static void InitServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
