using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mike.Models.Common;
using Mike.Application.Services;
using Mike.Application.Share.Interface;
using NLog;
using System.IO;

namespace Mike
{
    public class Startup
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "\\nlog.config"));
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            LoadGlobalConfig();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mike", Version = "v1" }); });
            services.AddDbContext<MikeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));

            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<INewService, NewService>();
            services.AddScoped<IImageGalleryService, ImageGalleryService>();
            services.AddScoped<IVideoGalleryService, VideoGalleryService>();
            services.AddScoped<IQuickLinkService, QuickLinkService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IHowService, HowService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IDocumentCategoryService, DocumentCategoryService>();

            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mike v1"));
            }

            app.UseCors("AllowOrigin");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseStaticFiles();

        }

        public void LoadGlobalConfig()
        {
            GlobalConfig.CurrentHost = "http://localhost:5000";

            #region Upload

            GlobalConfig.AppPhysPath = _hostingEnvironment.WebRootPath;
            GlobalConfig.UploadPath = GlobalConfig.CurrentHost + "/Uploads";

            #endregion

            #region FileUrl

            GlobalConfig.DefaultImageUrl = GlobalConfig.CurrentHost + "Image/DefaultImage";

            GlobalConfig.ImageFolderUrl = GlobalConfig.CurrentHost + "/Images";

            #endregion
        }
    }
}
