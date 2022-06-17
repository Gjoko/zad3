using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace zad3.Pages
{
    public class calculatorModel : PageModel
    {
        [FromQuery(Name = "operand1")]
        public string operand1 { get; set; }
        [FromQuery(Name = "operand2")]
        public string operand2 { get; set; }
        [FromQuery(Name = "operation")]
        public string operation { get; set; }
        public int result { get; set; }
        public bool isValid { get; set; }
        public void OnGet()
        {
            isValid = false;
            int operand1Value = 0;
            int operand2Value = 0;
            if(isOperandValid(operand1, operand1Value) && isOperandValid(operand2, operand2Value) && isOperationValid(operation))
            {
                operand1Value = int.Parse(operand1);
                operand2Value = int.Parse(operand2);
                isValid = true;
                switch (operation) {
                    case "plus":
                        result = int.Parse(operand1) + operand2Value;
                        break;
                    case "minus":
                        result = operand1Value - operand2Value;
                        break;
                    case "multiply-by":
                        Console.WriteLine(operand1Value);
                        Console.WriteLine(operand2Value);
                        result = operand1Value * operand2Value;
                        Console.WriteLine(result);
                        break;
                    case "divide-by":
                        result = operand1Value / operand2Value;
                        break;
                    default:
                        break;
                }
            }
        }

        public bool isOperandValid(string operand, int value)
        {
            return !string.IsNullOrEmpty(operand1) &&
                int.TryParse(operand,out value) ;
        }

        public bool isOperationValid(string operation)
        {
            string[] operationArray = { "plus", "minus", "multiply-by", "divide-by" };
            return !string.IsNullOrEmpty(operation) &&
                operationArray.Contains(operation);
        }
    }
}
