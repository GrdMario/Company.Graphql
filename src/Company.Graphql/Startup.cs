namespace Company.Graphql
{
    using Company.Graphql.Application;
    using Company.Graphql.Blocks.Common.Mapping.Configuration;
    using Company.Graphql.Blocks.Common.Serilog.Configuration;
    using Company.Graphql.Blocks.Presentation.Api.Configuration;
    using Company.Graphql.Infrastructure.Db.Mssql;
    using Company.Graphql.Presentation.Grapql;

    public sealed class Startup
    {
        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public MssqlAdapterSettings MssqlAdapterSettings =>
            Configuration
                .GetSection(MssqlAdapterSettings.Key)
                .Get<MssqlAdapterSettings>();

        public PostgresAdapterSettings PostgresAdapterSettings =>
           Configuration
               .GetSection(PostgresAdapterSettings.Key)
               .Get<PostgresAdapterSettings>();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddHealthChecks();
            services.AddMssqlDatabaseLayer(MssqlAdapterSettings);
            services.AddPostgresDatabaseLayer(PostgresAdapterSettings);
            services.AddApplicationLayer();
            services.AddPresentationLayer();
            services.AddAutoMapperConfiguration(AppDomain.CurrentDomain);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (!Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSerilogConfiguration();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapDefaultHealthCheckRoute();
            });

            app.UseGraphQLVoyager();
        }
    }
}
