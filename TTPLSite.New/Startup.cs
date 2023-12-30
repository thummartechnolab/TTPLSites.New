using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Mvc;
using TTPLSite.New.Models.Email;
using TTPLSite.New.Models;

namespace TTPLSite.New
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
            services.AddRazorPages();
            //services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMvc();//.SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.Configure<ReCaptcha>(Configuration.GetSection("ReCaptcha"));

            services.AddReCaptcha(Configuration.GetSection("ReCaptcha"));

            services.AddTransient<IMailService, MailService>();
            services.AddSingleton<IExceptionLogging, ExceptionLogging>();
            services.AddTransient<IReCaptchaSetting, ReCaptchaSetting>();

            services.AddCors(options => {
                options.AddPolicy("Policy1", builder => {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                });
                //options.AddPolicy("Policy2", builder => {
                //    builder.WithOrigins("http://www.test.com").AllowAnyHeader().AllowAnyMethod();
                //});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseDefaultFiles();//allow static html file
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
