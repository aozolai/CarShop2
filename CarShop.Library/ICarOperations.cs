using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public interface ICarOperations
    {
        public void AddCarToTheList(Car car);
        public Car[] FindCarByYear(int year);
        public void FindAvailableCarsCount();
        public string GetReceipt(int id);
        public void BuyCar(int id);
        public void SetStorage(ICarStorage storage);
    }
}
