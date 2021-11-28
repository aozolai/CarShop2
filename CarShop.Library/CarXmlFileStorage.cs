using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace CarShop.Library
{

    public class CarXmlFileStorage : ICarStorage
    {
        string FilePath { get; set; } = @"C:\SchoolFiles\CarListStorage.txt";

        public List<Car> ReadCarList()
        {
            if (File.Exists(FilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
                using (FileStream fs = new FileStream(FilePath, FileMode.Open))
                {
                    return (List<Car>)serializer.Deserialize(fs);
                }
            }
            return new List<Car>();
        }

        public void SaveCarList(List<Car> carList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
            using (TextWriter writer = new StreamWriter(FilePath))
            {
                serializer.Serialize(writer, carList);
            }
        }
    }
}
