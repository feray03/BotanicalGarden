using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanicalGardenApp.Presentation
{
    public class FlowerDisplay
    {
        private int closeOperationId = 6;
        private FlowerBusiness flowerBusiness;

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "FLOWER MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all flowes");
            Console.WriteLine("2. Add new flower");
            Console.WriteLine("3. Update flower");
            Console.WriteLine("5. Delete entry by Id");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAllFlowers();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    default:
                        break;
                }
            } 
            while (operation != closeOperationId);
        }

        public FlowerDisplay()
        {
            flowerBusiness = new FlowerBusiness();
            Input();
        }

        private void ListAllFlowers()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Flowers" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var flowers = flowerBusiness.GetAllFlowers();
            foreach (var flower in flowers)
            {
                var Seasons = flowerBusiness.GetSeason(flower.Name);
                Console.WriteLine($"{flower.Name} {flower.Color} {flower.LifeExpectancy} {Seasons.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }

        private void Add()
        {
            Flower flower = new Flower();
            Console.WriteLine("Enter name: ");
            flower.Name = Console.ReadLine();
            Console.WriteLine("Enter color: ");
            flower.Color = Console.ReadLine();
            Console.Write("Enter life expectancy: ");
            flower.LifeExpectancy = Console.ReadLine();
            Console.Write("Enter seasons Id: ");
            flower.SeasonsId = int.Parse(Console.ReadLine());
            flowerBusiness.Add(flower);
            Console.WriteLine("The product was successfully added!");
        }

        private void Update()
        {
            Console.WriteLine("Enter name to update: ");
            string name = Console.ReadLine();
            Flower flower = flowerBusiness.GetSeason(name);
            if (flower != null)
            {
                Console.WriteLine("Enter name: ");
                flower.Name = Console.ReadLine();
                Console.WriteLine("Enter color: ");
                flower.Color = Console.ReadLine();
                Console.Write("Enter life expectancy: ");
                flower.LifeExpectancy = Console.ReadLine();
                Console.Write("Enter seasons Id: ");
                flower.SeasonsId = int.Parse(Console.ReadLine());
                flowerBusiness.Update(flower);
            }
            else
            {
                Console.WriteLine("Flower not found!");
            }
        }
    }
}
