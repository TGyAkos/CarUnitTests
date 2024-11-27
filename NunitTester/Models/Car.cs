using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTester.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }

        public string GetCarInfo()
        {
            return $"Model: {Model}, Manufacturer: {Manufacturer}, Year: {Year}, CarId: {CarId}";
        }

        public bool IsNewCar()
        {
            var currentYear = DateTime.Now.Year;
            return Year >= currentYear;
        }

        public int GetCarAge()
        {
            var currentYear = DateTime.Now.Year;
            return currentYear - Year;
        }
    }
}
