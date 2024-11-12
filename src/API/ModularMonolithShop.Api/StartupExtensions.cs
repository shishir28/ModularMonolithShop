using ModularMonolithShop.Basket;
using ModularMonolithShop.Catalog;
using ModularMonolithShop.Ordering;

namespace ModularMonolithShop.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            var environmentName = builder.Environment?.EnvironmentName;

            // if(environmentName != "Test")
            //     builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddHealthChecks();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            builder.Services.AddBasketModule(builder.Configuration)
                .AddCatalogModule(builder.Configuration)
                .AddOrderingModule(builder.Configuration);

            AddSwagger(builder.Services);
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Modular Monolith.API v1"));
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            //app.UseRouting();
            app.UseAuthentication();
            // app.UseCustomExceptionHandler();
            app
            .UseBasketModule()
            .UseCatalogModule()
            .UseOrderingModule();

            app.MapHealthChecks("/healthz");
            app.MapControllers();
            return app;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "ModularMonolithShopAPI", Version = "v1" });
            });
        }
    }
}