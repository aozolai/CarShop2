using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarCsvFileStorage : ICarStorage
    {
        string FilePath { get; set; } = @"C:\SchoolFiles\CarCsvFileStorage.txt";
        string Separator { get; set; } = ",";
        public List<Car> ReadCarList()
        {
            var cars = new List<Car>(); // empty collection where we will store our cars

            if (File.Exists(FilePath))
            {
                var carListLines = File.ReadAllLines(FilePath); //define from where we will read

                foreach (var line in carListLines)
                {
                    var parts = line.Split(Separator);
                    var car = new Car()
                    {
                        Id = int.Parse(parts[0]),
                        Model = parts[1],
                        Year = int.Parse(parts[2]),
                        Color = parts[3],
                        Price = int.Parse(parts[4]),
                        Sold = bool.Parse(parts[5])
                    };
                    cars.Add(car); //adding car which has been read upper
                }
            }
            return cars;
        }
        public void SaveCarList(List<Car> carList)
        {
            using (TextWriter writer = new StreamWriter(FilePath))
            {
                foreach (var car in carList)
                {
                    writer.WriteLine($"{car.Id}{Separator}{car.Model}{Separator}{car.Year}{Separator}{car.Color}{Separator}{car.Price}{Separator}{car.Sold}");
                }
            }
        }
    }
}
