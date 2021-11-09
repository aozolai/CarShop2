using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        public Car[] CarArray = new Car[100];
        public void AddCarToTheList(Car car)
        {
            var index = CarArray.Count(x => x != null);
            CarArray[index] = car;
        }
        public int FindAvailableCarsCount()
        {
            return CarArray.Count(x => x != null && x.IsAvailable && !x.Sold);
        }
        public Car[] FindCarByYear(int year)
        {
            return CarArray.Where(x => x != null && x.Year == year).ToArray();
        }
        public void BuyCar(int id)
        {
            var selectedCar = CarArray.FirstOrDefault(x => x.Id == id);
            if (selectedCar != null)
            {
                selectedCar.Sold = true;
            }
            else
            {
                Console.WriteLine("Car not found");
            }
        }
        public string GetReceipt(int id)
        { 
            var boughtCar = CarArray.FirstOrDefault(x => x.Id == id);
            if (boughtCar != null)
            {
                Console.WriteLine();
                Console.WriteLine("RECEIPT:");
                return $"Your bought car is -  {boughtCar.Model} , color - {boughtCar.Color}";
            }
            return null;
        }
    }
}
