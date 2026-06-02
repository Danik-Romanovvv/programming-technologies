using System.ComponentModel.DataAnnotations;

namespace WebApplicationRomanov.Models
{
    public class CalculatorModel
    {
        // Операнд 1 с обязательным полем
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public long? Operand1 { get; set; }

        // Операнд 2 с проверкой на совпадение с Операндом 1 (по варианту Compare)
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Compare("Operand1", ErrorMessage = "Операнды должны совпадать (по заданию)")]
        public long? Operand2 { get; set; }

        public string Operation { get; set; }

        public decimal? Result { get; set; }
    }
}