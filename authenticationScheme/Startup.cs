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
        // 1/3 ��������
        // ���MVC����
        public void ConfigureServices(IServiceCollection services)
        {
            //���MVC����
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddScoped<IMyDependency,MyDependency>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 2/3 http����ܵ�������
        // ���http����ܵ�����
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

        //>2.1�İ汾�����еĲ�����Ϊ��ʹ��UseMVC����option => option.EnableEndpointRouting = false
        //�°����ȡ������·�ɷ�ʽendPoint
        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=home}/{action=Index}/{id?}");
        }
    }
}
