using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationRomanov2.Models
{
    // Предметная область "Лодочная станция"
    [DisplayName("Плавсредство")]
    public class Boat
    {
        [DisplayName("Учетный номер")]
        public int Id { get; set; }

        [DisplayName("Название лодки/катамарана")]
        public string BoatName { get; set; }

        [DisplayName("Стоимость аренды (руб/час)")]
        public double RentalPrice { get; set; }

        [DisplayName("Дата последнего ТО")]
        public DateTime LastMaintenanceDate { get; set; }

        [DisplayName("Доступна для проката")]
        public bool IsAvailable { get; set; }

        [DisplayName("Описание состояния и комплектации")]
        [DataType(DataType.MultilineText)] // Вариант 3 для DataType
        public string Description { get; set; }
    }
}