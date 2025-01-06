using Microsoft.AspNetCore.Mvc;

namespace WebApplicationWithAuth.Controllers;

public class CalculatorController : Controller
{
    [HttpGet]
    public IActionResult Calculate()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Calculate(double number1, double number2, char action)
    {
        double result = 0;

        switch (action)
        {
            case '+':
                result = number1 + number2;
                break;
            case '-':
                result = number1 - number2;
                break;
            case '/':
                result = number1 / number2;
                break;
            case '*':
                result = number1 * number2;
                break;
        }

        return View(result);
    }

    [HttpGet]
    public IActionResult PrintNumbers()
    {
        return View();
    }

    [HttpPost]
    public IActionResult PrintNumbers(int number)
    {
        return View(number);
    }
}
