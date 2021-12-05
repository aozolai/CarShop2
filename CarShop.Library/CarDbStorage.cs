using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarDbStorage : ICarStorage
    {
        string connectionString =
                @"Data Source=AIJA-MACIBAS-PC\SQLEXPRESS;Initial Catalog=CarShopDB;Integrated Security=true";
        public void SaveCarList(List<Car> carList)
        {
            string queryInsert = "insert into Cars (Id, Model, Year, Color, Price, Sold) " +
                                "Values (@Id, @Model, @Year, @Color, @Price, @Sold)";

            string queryUpdate = "update Cars " +
                                 "Set Model = @Model, Year = @Year, Color = @Color, Price = @Price, Sold = @Sold " +
                                 "where Id = @Id";

            string querySelect = "select * from Cars " +
                                 "where Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var car in carList)
                {
                    using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                    using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                    using (SqlCommand commandSelect = new SqlCommand(querySelect, connection))
                    {
                        commandSelect.Parameters.AddWithValue("@Id", car.Id);
                        using (var reader = commandSelect.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                reader.Close();
                                commandUpdate.Parameters.AddWithValue("@Id", car.Id);
                                commandUpdate.Parameters.AddWithValue("@Model", car.Model);
                                commandUpdate.Parameters.AddWithValue("@Year", car.Year);
                                commandUpdate.Parameters.AddWithValue("@Color", car.Color);
                                commandUpdate.Parameters.AddWithValue("@Price", car.Price);
                                commandUpdate.Parameters.AddWithValue("@Sold", car.Sold);
                                commandUpdate.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();
                                commandInsert.Parameters.AddWithValue("@Id", car.Id);
                                commandInsert.Parameters.AddWithValue("@Model", car.Model);
                                commandInsert.Parameters.AddWithValue("@Year", car.Year);
                                commandInsert.Parameters.AddWithValue("@Color", car.Color);
                                commandInsert.Parameters.AddWithValue("@Price", car.Price);
                                commandInsert.Parameters.AddWithValue("@Sold", car.Sold);
                                commandInsert.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
        public List<Car> ReadCarList()
        {
            var cars = new List<Car>();

            string queryString = "select * from Cars ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var car = new Car()
                        {
                            Id = (int)reader[0],
                            Model = (string)reader[1],
                            Year = (int)reader[2],
                            Color = (string)reader[3],
                            Price = (int)reader[4],
                            Sold = (bool)reader[5],
                        };
                        cars.Add(car);
                    }
                }
            }
            return cars;
        }
    }
}
