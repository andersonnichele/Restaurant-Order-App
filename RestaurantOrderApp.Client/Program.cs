using Microsoft.Extensions.DependencyInjection;
using RestaurantOrderApp.Client.Service;
using RestaurantOrderApp.Client.Service.Interfaces;
using System;

namespace RestaurantOrderApp.Client
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .AddSingleton<IRestaurantOrderService, RestaurantOrderService>()
                .BuildServiceProvider();

            Console.WriteLine("------------------------");
            Console.WriteLine("Welcome to Restaurant Order App");
            Console.WriteLine("------------------------");
            Console.WriteLine("Chosse an option");
            Console.WriteLine("------------------------");
            Console.WriteLine("1 - Show menu");
            Console.WriteLine("2 - Order");
            Console.WriteLine("3 - Exit");

            var opcao = Console.ReadKey();

            switch (opcao.KeyChar)
            {
                case '1':
                    ShowMenu();
                    break;

                case '2':
                    Console.Clear();

                    Console.WriteLine("Type your order:");

                    var inputOrder = Console.ReadLine();

                    Console.WriteLine("Your order: {0}", inputOrder);

                    var restaurantOrderService = serviceProvider.GetService<IRestaurantOrderService>();

                    Console.WriteLine("Order result: {0}", restaurantOrderService.GetOrder(inputOrder).Result);

                    break;

                case '3':
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            Console.WriteLine("Type any key to continue");
            Console.ReadKey();

            Console.Clear();
            Main();
        }

        private static void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------- Restaurant Order App - Menu -------");
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("");

            Console.WriteLine(String.Format("|{0,20}|{1,20}|{2,20}|", "Dish Type", "morning", "night"));
            Console.WriteLine(String.Format("|{0,20}|{1,20}|{2,20}|", "1 (entrée)", "eggs", "steak"));
            Console.WriteLine(String.Format("|{0,20}|{1,20}|{2,20}|", "2 (side)", "toast", "potato"));
            Console.WriteLine(String.Format("|{0,20}|{1,20}|{2,20}|", "3 (drink)", "coffee", "wine"));
            Console.WriteLine(String.Format("|{0,20}|{1,20}|{2,20}|", "4 (dessert)", "Not Applicable", "cake"));
        }
    }
}