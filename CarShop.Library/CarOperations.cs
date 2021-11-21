using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        public List<Car> CarList = new();
        private ICarStorage storage;
        public void AddCarToTheList(Car car)
        {
            CarList.Add(car);
            SaveList();
        }
        private void SaveList()
        {
            if (storage != null)
            {
                storage.SaveCarList(CarList);
            }
        }
        public void SetStorage(ICarStorage storage)
        {
            this.storage = storage;
            CarList = this.storage.ReadCarList();
        }

        public void FindAvailableCarsCount()
        {
            var count = CarList.Count(x => x != null && x.IsAvailable && !x.Sold);
            UserOutput.ShowAvailableCarMessage(count);
        }
        public Car[] FindCarByYear(int year)
        {
            return CarList.Where(x => x != null && x.Year == year).ToArray();
        }
        public void GetCarByYear(int year)
        {
            var CarList = FindCarByYear(year);

            foreach (var car in CarList)
            {
                UserOutput.ShowCarListMessage(car.Id, car.Model, car.Price);
            }
        }
        public void ShowListOfAllCars()
        {
            int i = 0;

            foreach (var car in CarList)
            {
                if (car != null)
                {
                    UserOutput.ShowCarListMessage(car.Id, car.Model, car.Price);
                }
                i++;
            }
        }
        public void BuyCar(int id)
        {
            var selectedCar = CarList.FirstOrDefault(x => x.Id == id);
            if (selectedCar != null)
            {
                selectedCar.Sold = true;
                UserOutput.ShowCongratulationsMessage();
                SaveList();
            }
            else
            {
                UserOutput.ShowCarNotFoundMessagge();
            }
        }
        public void ShowListOfAllSoldCars()
        {
            int i = 0;

            foreach (var car in CarList)
            {
                if (car != null && car.Sold)
                {
                    UserOutput.ShowSoldCarListMessage(car.Id, car.Model);
                }
                i++;
            }
        }
        public string GetReceipt(int id)
        {
            var boughtCar = CarList.FirstOrDefault(x => x.Id == id);
            var recipientId = Guid.NewGuid().ToString();
            if (boughtCar != null)
            {
                UserOutput.GetReceiptMessage();
                return @$"
            Receipt number:     {recipientId}                           
                 Car model:     {boughtCar.Model} 
                 Car color:     {boughtCar.Color}
                  Car year:     {boughtCar.Year}
               Price (EUR):     {boughtCar.Price}
                            
";
            }
            return null;
        }


    }
}
