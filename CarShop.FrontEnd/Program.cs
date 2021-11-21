using System;
using System.Collections.Generic;
using System.Linq;
using CarShop.Library;
using System.Text;
using System.IO;

namespace CarShop.Frontend
{
    class Program
    {
        static readonly CarOperations CarOperator = new CarOperations();
        static void Main(string[] args)
        {
            CarOperator.SetStorage(new CarCsvFileStorage());

            try
            {
                MainMethod();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception message: {exception.Message}");
            }
            finally
            {
                MainMethod();
            }
        }

        public static void MainMethod()
        {
            var exit = "continue";

            while (exit == "continue")
            {
                UserOutput.ShowMenu();

                var option = Console.ReadLine();

                if (option.Equals("exit"))
                {
                    exit = option;
                }

                switch (option)
                {
                    case "1":
                        // 1.Add car to the shop"
                        AddCarToTheList();
                        break;

                    case "2":
                        //Find a car by is available
                        CarOperator.FindAvailableCarsCount();
                        break;

                    case "3":
                        //Get cars by year
                        UserOutput.FindCarByYearMesage();
                        var year = Convert.ToInt32(Console.ReadLine());
                        CarOperator.GetCarByYear(year);
                        break;

                    case "4":
                        //Show list of all presented cars
                        CarOperator.ShowListOfAllCars();
                        break;

                    case "5":
                        // Buy car - mark it sold
                        UserOutput.ShowAvailableCarsMessage();
                        CarOperator.ShowListOfAllCars();

                        UserOutput.ChooseCarToBuyMessage();
                        var inputId = Convert.ToInt32(Console.ReadLine());

                        CarOperator.BuyCar(inputId);
                        GetReceipient(inputId);
                        break;

                    case "6":
                        // Get receipt
                        UserOutput.ShowSoldCarsMessage();
                        CarOperator.ShowListOfAllSoldCars();

                        UserOutput.ChooseSoldCarsIdMessage();
                        var inputSoldCar = Convert.ToInt32(Console.ReadLine());

                        GetReceipient(inputSoldCar);
                        break;

                }
            }
        }
        public static Car CreateCarObject()
        {
            var car = new Car();

            UserOutput.CreateCarModelMessage();
            car.Model = Console.ReadLine();

            UserOutput.CreateCarColorMessage();
            car.Color = Console.ReadLine();

            UserOutput.CreateCarYearMessage();
            car.Year = Convert.ToInt32(Console.ReadLine());

            UserOutput.AddCarsPrice();
            car.Price = Convert.ToInt32(Console.ReadLine());

            UserOutput.CreateCarIdMessage();
            car.Id = Convert.ToInt32(Console.ReadLine());

            return car;

        }
        public static void AddCarToTheList()
        {
            var continues = true;

            while (continues)
            {
                var car = CreateCarObject();
                CarOperator.AddCarToTheList(car);

                UserOutput.ShowCreateMoreCarsMessage();

                var yesNo = Console.ReadLine();
                if (yesNo == "Yes") continue;

                continues = false;
            }
        }
        public static void GetReceipient(int inputSoldCar)
        {
            var recipient = new Recipient();
            UserOutput.GetBuyersNameMessage();
            recipient.Name = Console.ReadLine();
            UserOutput.GetBuyersSurnameMessage();
            recipient.Surname = Console.ReadLine();

            var receipt = CarOperator.GetReceipt(inputSoldCar);

            UserOutput.GetReceiptPrintOutMessage(receipt, recipient.Name, recipient.Surname, recipient.PurchaseDate);

        }
    }
}
