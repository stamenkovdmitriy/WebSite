using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite
{
    public class Startup
    {
        // ����������� ���������� � �������� ��������� ��������� IServiceCollection, ����� ������� �� ����� �������� � �������������
        // ����� �� ����� ��������������� ��������� �������, ������� ����� ���������� �����
        public void ConfigureServices(IServiceCollection services)
        {
            // ���������� MVC
            services.AddControllersWithViews();
        }

        // ����� � ������� ����������� ��� ������ �����
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ���������� ��� �������� � ������ ����������
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ���������������� ��������, ��������(Routing) ���� ��� ����������� ��������� ��� � ��������� URL
            app.UseRouting();

            /* ����������� �����, ������� ����� ����������� � ����� �� ����� �������� ������,
             ����������� ����� ����� ��� ���������� */
            app.UseEndpoints(endpoints =>
            {
                /* � ������� ������ MapControllerRoute �������� ������������� �� �����������
                    ����� ������ ����� �������� ��� ������� ��� ���������: ��� � ������
                 {controller=Home} ��� ������ �����������, 
                 {action=Index} ���� �������� ��������� �������,
                    ����� ����� ������ ����������� ����� ������� ��� ��������� ������� 
                    {id?} �������� �� �� ������������ ������� ����� ���� �������*/
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
