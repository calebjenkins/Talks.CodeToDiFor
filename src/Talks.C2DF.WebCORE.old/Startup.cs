using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talks.C2DF.BetterApp;

namespace Talks.C2DF.WebCORE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Take in Lamar's ServiceRegistry instead of IServiceCollection
        // as your argument, but **fear not**, it implements IServiceCollection as well
        //public void ConfigureServices(ServiceRegistry services)
        //  -> Note, there is a bug between Lamar and ASP.NET 2.1, so all registration
        //     is handeled in Program.cs WebHostBuilder for Now

        public void ConfigureServices(IServiceCollection services)
        {
            var registery = new DependencyProfileLamar();
            services.AddLamar(registery);


            services.AddMvc()
                .AddMvcOptions(opt => opt.EnableEndpointRouting = false); //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // services.AddLogging();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                         name: "default",
                         template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
