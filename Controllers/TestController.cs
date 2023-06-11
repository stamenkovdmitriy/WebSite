using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebSite.Controllers
{
    // создаем маршрутизацию через атрибуты

    // указываем, что все методы класса будут вызываться только тогда,
    // когда URL начинается с my/test
    [Route("my/test")]
    public class TestController : Controller
    {
        // указываем оставшуюся часть URL
        [Route("show")]
        public string Index()
        {
            return "Index Test method";
        }

        // {id} - фигурные скобки указывают,
        // что значение в этом месте будет передано самому методу в качестве параметра id
        [Route("details/{id}")]
        public string Details(string id)
        {
            return "ID Value = " + id;
        }
        // методы доступа:
        // GET метод для получения данных с сервера
        [HttpGet]
        public string Login()
        {
            return "Форма для входа";
        }
        // POST метод отправки данных на сервер
        [HttpPost]
        public string Login(LoginModel model)
        {
            return "Форма для входа";
        }
    }

    public class LoginModel
    {
    }
}
