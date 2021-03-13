using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanicalGardenApp.Presentation
{
    public class FlowerDisplay
    {
        private int closeOperationId = 7;
        private FlowerBusiness flowerBusiness;

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "FLOWER MENU" + new string(' ', 11));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all flowes");
            Console.WriteLine("2. Add new flower");
            Console.WriteLine("3. Update flower");
            Console.WriteLine("4. Fetch flower by Name");
            Console.WriteLine("5. Delete entry by Id");
            Console.WriteLine("6. Search flower by season");
            Console.WriteLine("7. Back");
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
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        SearchFlowerBySeason();
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
                Console.WriteLine($"{flower.Id} - {flower.Name}, {flower.Color}, {flower.LifeExpectancy}, {Seasons.Name}");
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
            Console.WriteLine("Enter life expectancy: ");
            flower.LifeExpectancy = Console.ReadLine();
            Console.WriteLine("Enter seasons Id: ");
            flower.SeasonsId = int.Parse(Console.ReadLine());
            flowerBusiness.Add(flower);
            Console.WriteLine("The flower was successfully added!");
        }

        private void Update()
        {
            Console.WriteLine("Enter Name to update: ");
            string name = Console.ReadLine();
            Flower flower = flowerBusiness.GetFlowerByName(name);
            if (flower != null)
            {
                Console.WriteLine("Enter name: ");
                flower.Name = Console.ReadLine();
                Console.WriteLine("Enter color: ");
                flower.Color = Console.ReadLine();
                Console.WriteLine("Enter life expectancy: ");
                flower.LifeExpectancy = Console.ReadLine();
                Console.WriteLine("Enter seasons Id: ");
                flower.SeasonsId = int.Parse(Console.ReadLine());
                flowerBusiness.Update(flower);
                Console.WriteLine("The flower was updated successfully!");
            }
            else
            {
                Console.WriteLine("Flower not found!");
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter Name to fetch: ");
            string name = Console.ReadLine();
            var flower = flowerBusiness.GetFlowerByName(name);
            if (flower != null)
            {
                var FlowerSeason = flowerBusiness.GetSeason(flower.Name);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + flower.Id);
                Console.WriteLine("Name: " + flower.Name);
                Console.WriteLine("Color: " + flower.Color);
                Console.WriteLine("Life Expectancy: " + flower.LifeExpectancy);
                Console.WriteLine("Seasons: " + FlowerSeason.Name);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Flower not found!");
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            flowerBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void SearchFlowerBySeason()
        {
            Console.WriteLine("Enter season id: ");
            int seasonId = int.Parse(Console.ReadLine());
            List<Flower> flowers = flowerBusiness.SearchBySeason(seasonId);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Flowers" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            foreach (var flower in flowers)
            {
                Console.WriteLine($"{flower.Id} - {flower.Name}");
            }
        }
    }
}
