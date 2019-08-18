using IGTI.PA.Database;
using IGTI.PA.Database.Impl;
using IGTI.PA.Queue;
using IGTI.PA.Queue.Impl;
using IGTI.PA.UseCases;
using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Adapters.Queue;
using IGTI.PA.UseCases.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IGTI.PA.Init
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<DatabaseContextOptions>(Configuration);
            services.Configure<QueueContextOptions>(Configuration);

            services.AddSingleton<DatabaseContext>();
            services.AddSingleton<QueueContext>();

            services.AddScoped<Producer, ProducerImpl>();
            services.AddScoped<ProspectRepository, ProspectRepositoryImpl>();

            services.AddScoped<Register, RegisterImpl>();
            services.AddScoped<Login, LoginImpl>();
            services.AddScoped<Validate, ValidateImpl>();
            services.AddScoped<AccountType, AccountTypeImpl>();
            services.AddScoped<Address, AddressImpl>();
            services.AddScoped<Financial, FinancialImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
