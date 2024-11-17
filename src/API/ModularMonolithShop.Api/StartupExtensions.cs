using ModularMonolithShop.Basket;
using ModularMonolithShop.Catalog;
using ModularMonolithShop.Ordering;
using ModularMonolithShop.Shared.Kernel.Extensions;
using Shared.Kernel.Exceptions.Handler;

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

            builder.Services.AddMediatRWithAssemblies([
                typeof(BasketModule).Assembly,
                typeof(CatalogModule).Assembly,
                typeof(OrderingModule).Assembly
            ]);

            builder.Services.AddBasketModule(builder.Configuration)
                .AddCatalogModule(builder.Configuration)
                .AddOrderingModule(builder.Configuration);

            builder.Services.AddExceptionHandler<CustomExceptionHandler>();
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
            }
            app.UseStaticFiles();
            // app.UseHttpsRedirection();
            //app.UseRouting();
            app.UseAuthentication();
            app.UseExceptionHandler(_ => { });

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
