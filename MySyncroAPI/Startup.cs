using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySyncroAPI.Persistence;
using MediatR;
using MySyncroAPI.Business.Queries;
using MediatR.Pipeline;
using MySyncroAPI.Business.Infrastructure;
using System;

namespace MySyncroAPI
{
    public class Startup
    {
        private bool _isDev = false;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*", "http://localhost:4200","http://127.0.0.1");
                                  });
            });

            services.AddAuthorization(o=>{
                o.AddPolicy("default", policy => {
                    policy.RequireClaim("http://schemas.microsoft.com/identity/claims/scope", "user_impersonation");
                });
            });

            //services.AddAuthentication(o=>{
            //    o.DefaultScheme = JwtBearerDefaults.
            //});



            //Add DB Context
            if (this.Configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT").StartsWith("Development"))
            {
                services.AddDbContext<MySyncroAPIDatabaseContext>(options =>
                {
                    options.UseSqlite(@"Data Source = Data\MySyncroDatabase.db");
                });
            }
            else
            {
                services.AddDbContext<MySyncroAPIDatabaseContext>(options =>
                {
                    options.UseSqlite(@"Data Source = /home/site/wwwroot/Data/MySyncroDatabase.db");
                });
            }

            //Inject MediatR queries
            services.AddMediatR(typeof(GetAllContactsQuery).GetTypeInfo().Assembly);
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddSingleton(typeof(IRequestPreProcessor<>), typeof(RequestLogger<>));

            services.AddControllers();
           
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _isDev = true;
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyContactsApi");
            });

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Contacts}/{action=GetAllContacts}/{param}"
                //    );
            });
        }
    }
}
