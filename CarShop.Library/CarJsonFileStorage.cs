using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarJsonFileStorage : ICarStorage
    {

        string FilePath { get; set; } = @"C:\SchoolFiles\CarJsonListStorage.txt";

        public List<Car> ReadCarList()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);

                return JsonSerializer.Deserialize<List<Car>>(json);
            }
            return new List<Car>();
        }

        public void SaveCarList(List<Car> carList)
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            var json = JsonSerializer.Serialize(carList, options);
            File.WriteAllText(FilePath, json);
            

        }
    }
}

