using System.Web.Mvc;
using WebApplicationRomanov.Models;


namespace WebApplicationRomanov.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // Задаем ожидаемое значение для проверки в представлении
            ViewBag.ExpectedResult = 100m;
            return View(new CalculatorModel());
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel model, string buttonAction)
        {
            ViewBag.ExpectedResult = 100m;

            // Если нажата вторая кнопка (Очистить)
            if (buttonAction == "Очистить")
            {
                ModelState.Clear();
                return View(new CalculatorModel());
            }

            // Если нажата кнопка "Вычислить" и модель валидна
            if (ModelState.IsValid)
            {
                switch (model.Operation)
                {
                    case "+": model.Result = model.Operand1 + model.Operand2; break;
                    case "-": model.Result = model.Operand1 - model.Operand2; break;
                    case "*": model.Result = model.Operand1 * model.Operand2; break;
                    case "/":
                        if (model.Operand2 != 0)
                            model.Result = (decimal)model.Operand1 / (decimal)model.Operand2;
                        break;
                    default:
                        model.Result = 0; break;
                }

                // Формируем строку и сохраняем в Session (Вариант 3)
                Session["LastOperation"] = $"{model.Operand1}{model.Operation}{model.Operand2}={model.Result}";
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ResultPage()
        {
            string lastOp = Session["LastOperation"] as string;

            if (!string.IsNullOrEmpty(lastOp))
            {
                // Дополнительная обработка: заменяем знак равенства на словесный аналог
                // Используем Replace и PadRight (Вариант V)
                lastOp = lastOp.Replace("=", " равно ").PadRight(40, '.');
                ViewBag.ProcessedString = lastOp;
            }
            else
            {
                ViewBag.ProcessedString = "Нет данных об операциях.";
            }

            return View();
        }
    }
}