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
                /* переменная endpoints через которую мы получаем доступ к объекту, который реализует интерфейс IEndpointRouteBuilder
                 этот интерфейс описывает методы, которые позволяют привязывать определенные URL к коду(в данном случае метод MapGet)
                Метод MapGet получает два параметра: 1- строка в которой содержится URL
                 2- метод, который будет получать ув качестве параметра контекст отображения страницы(типа HtttpContext),
                в которой можно писать текстдля отображения на странице  */
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
