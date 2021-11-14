using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public static class UserOutput
    {
        public static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose car operation:");
            Console.WriteLine("1. Add car to the shop");
            Console.WriteLine("2. Find available cars");
            Console.WriteLine("3. Find car by year");
            Console.WriteLine("4. Show list of all presented cars");
            Console.WriteLine("5. Buy a car");
            Console.WriteLine("6. Get receipt");
            Console.WriteLine();
        }
        public static void ShowAvailableCarMessage(int count)
        {
            Console.WriteLine($"Available car count is: {count}");
        }
        public static void ShowCarNotFoundMessagge()
        {
            Console.WriteLine("Car not found");
        }
        public static void CreateCarModelMessage()
        {
            Console.WriteLine("Please add car model:");
        }
        public static void CreateCarColorMessage()
        {
            Console.WriteLine("Add car color:");
        }
        public static void CreateCarYearMessage()
        {
            Console.WriteLine("Add car year:");
        }
        public static void CreateCarIdMessage()
        {
            Console.WriteLine("Add ID number for the car:");
        }
        public static void AddCarsPrice()
        {
            Console.WriteLine("Add car price in Euros:");
        }
        public static void ShowCreateMoreCarsMessage()
        {
            Console.WriteLine("Do you want to create mores cars? (Yes/No)");
        }
        public static void ShowAvailableCarsMessage()
        {
            Console.WriteLine("In CarShop available cars are:");
        }
        public static void FindCarByYearMesage()
        {
            Console.WriteLine("Please provide year:");
        }
        public static void ShowCarListMessage(int id, string model, int price)
        {
            Console.WriteLine(@$"
                                * Car ID: {id} || Model: {model} || Price is: {price} EUR");
        }
        public static void ChooseCarToBuyMessage()
        {
            Console.WriteLine("Choose which car you want to buy and insert cars ID number here:");
        }
        public static void ShowCongratulationsMessage()
        {
            Console.WriteLine("Congratulations, you bought a car!");
        }
        public static void ShowSoldCarsMessage()
        {
            Console.WriteLine("These cars are sold:");
        }
        public static void ShowSoldCarListMessage(int id, string model)
        {
            Console.WriteLine(@$"
                                 * Car ID: {id} || Model: {model} is sold");
        }
        public static void ChooseSoldCarsIdMessage()
        {
            Console.WriteLine("Enter cars ID number, to receive receipt");
        }
        public static void GetBuyersNameMessage()
        {
            Console.WriteLine("Enter your name:");
        }
        public static void GetBuyersSurnameMessage()
        {
            Console.WriteLine("Enter your surname");
        }
        public static void GetReceiptMessage()
        {
            Console.WriteLine();
            Console.WriteLine("RECEIPT:");
        }
        public static void GetReceiptPrintOutMessage(string receipt, string name, string surname, DateTime purchaseDate)
        {
            Console.WriteLine($"{receipt}");
            Console.WriteLine($"Buyer: {name} {surname}");
            Console.WriteLine($"Purchase happened on: {purchaseDate}");
        }
    }
}
