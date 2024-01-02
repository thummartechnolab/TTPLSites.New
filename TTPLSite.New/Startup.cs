using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Mvc;
using TTPLSite.New.Models.Email;
using TTPLSite.New.Models;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

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

            //Compression
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.SmallestSize;
            });

            //Cache
            services.AddResponseCaching();
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Default30",
                    new CacheProfile()
                    {
                        Duration = 31536000
                    });
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

            // UseCors must be called before UseResponseCaching
            app.UseCors();


            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
