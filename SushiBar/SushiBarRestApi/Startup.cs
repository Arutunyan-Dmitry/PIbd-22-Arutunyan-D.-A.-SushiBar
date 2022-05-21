using SushiBarBusinessLogic.BusinessLogic;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.StoragesContracts;
using SushiBarDatabaseImplement.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M6T.Core.TupleModelBinder;
using SushiBarBusinessLogic.MailWorker;
using SushiBarContracts.BindingModels;

namespace SushiBarRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IIngredientStorage, IngredientStorage>();
            services.AddTransient<IDishStorage, DishStorage>();
            services.AddTransient<IStorageFacilityStorage, StorageFacilityStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();

            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IIngredientLogic, IngredientLogic>();
            services.AddTransient<IDishLogic, DishLogic>();
            services.AddTransient<IStorageFacilityLogic, StorageFacilityLogic>();
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();

            services.AddSingleton<AbstractMailWorker, MailKitWorker>();

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SushiBarRestApi", Version = "v1" });
            });
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new TupleModelBinderProvider());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SushiBarRestApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var mailSender = app.ApplicationServices.GetService<AbstractMailWorker>();
            mailSender.MailConfig(new MailConfigBindingModel
            {
                MailLogin = Configuration?.GetSection("MailLogin")?.Value.ToString(),
                MailPassword = Configuration?.GetSection("MailPassword")?.Value.ToString(),
                SmtpClientHost = Configuration?.GetSection("SmtpClientHost")?.Value.ToString(),
                SmtpClientPort = Convert.ToInt32(Configuration?.GetSection("SmtpClientPort")?.Value.ToString()),
                PopHost = Configuration?.GetSection("PopHost")?.Value.ToString(),
                PopPort = Convert.ToInt32(Configuration?.GetSection("PopPort")?.Value.ToString())
            });
        }
    }
}
