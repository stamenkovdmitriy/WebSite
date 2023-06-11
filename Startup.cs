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
        // конструктор получающий в качестве параметра интерфейс IServiceCollection, через который мы можем работать с конфигурацией
        // здесь мы можем конфигурировать различные сервисы, которые будут необходимы сайту
        public void ConfigureServices(IServiceCollection services)
        {
            // подключаем MVC
            services.AddControllersWithViews();
        }

        // метод в котором реализуется вся логика сайта
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // убеждаемся что работаем в режиме разработки
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // инициализируются маршруты, маршруты(Routing) дают нам возможность привязать код к различным URL
            app.UseRouting();

            /* запускается метод, который будет выполняться в ответ на любой входящий запрос,
             настраиваем точки входа для приложения */
            app.UseEndpoints(endpoints =>
            {
                /* с помощью метода MapControllerRoute включаем маршрутизацию на контроллеры
                    этому методу нужно передать как минимум два параметра: имя и шаблон
                 {controller=Home} имя класса контроллера, 
                 {action=Index} этот параметр позволяет указать,
                    какой метод класса конторллера нужно вызвать для обработки запроса 
                    {id?} параметр он не обязательный поэтому стоит знак вопроса*/
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
