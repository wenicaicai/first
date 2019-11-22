using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace authenticationScheme
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // 1/3 服务配置
        // 添加MVC服务
        public void ConfigureServices(IServiceCollection services)
        {
            //添加MVC服务
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddScoped<IMyDependency,MyDependency>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 2/3 http请求管道的配置
        // 添加http请求管道处理
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllerRoute
        //        (name: "default",
        //        pattern: "{controller=home}/{action=Index}/{id?}");
        //    });

        //    //app.UseEndpoints(endpoints =>
        //    //{
        //    //    endpoints.MapGet("/", async context =>
        //    //    {
        //    //        await context.Response.WriteAsync("Hello World!");
        //    //    });
        //    //});

        //}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(ConfigureRoute);

        }

        //>2.1的版本所进行的操作，为了使用UseMVC还让option => option.EnableEndpointRouting = false
        //新版则采取上述的路由方式endPoint
        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=home}/{action=Index}/{id?}");
        }
    }
}
