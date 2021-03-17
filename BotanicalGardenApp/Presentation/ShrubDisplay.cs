using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanicalGardenApp.Presentation
{
    public class ShrubDisplay
    {
        private int closeOperationId = 7;
        private ShrubBusiness shrubBusiness;

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "SHRUB MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all shrubs");
            Console.WriteLine("2. Add new shrub");
            Console.WriteLine("3. Update shrub");
            Console.WriteLine("4. Fetch shrub by Name");
            Console.WriteLine("5. Delete entry by Id");
            Console.WriteLine("6. Search shrub by season");
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
                        ListAllShrubs();
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
                        SearchShrubBySeason();
                        break;
                    default:
                        break;
                }
            }
            while (operation != closeOperationId);
        }

        public ShrubDisplay()
        {
            shrubBusiness = new ShrubBusiness();
            Input();
        }

        private void ListAllShrubs()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Shrubs" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var shrubs = shrubBusiness.GetAllShrubs();
            foreach (var shrub in shrubs)
            {
                var Seasons = shrubBusiness.GetSeason(shrub.Name);
                Console.WriteLine($"{shrub.Id} - {shrub.Name}, {shrub.Type}, {shrub.Height}, {shrub.LifeExpectancy}, {Seasons.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }

        private void Add()
        {
            Shrub shrub = new Shrub();
            Console.WriteLine("Enter name: ");
            shrub.Name = Console.ReadLine();
            Console.WriteLine("Enter type: ");
            shrub.Type = Console.ReadLine();
            Console.WriteLine("Enter height: ");
            shrub.Height = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter life expectancy: ");
            shrub.LifeExpectancy = Console.ReadLine();
            Console.WriteLine("Enter seasons Id: ");
            shrub.SeasonsId = int.Parse(Console.ReadLine());
            shrubBusiness.Add(shrub);
            Console.WriteLine("The shrub was successfully added!");
        }

        private void Update()
        {
            Console.WriteLine("Enter Name to update: ");
            string name = Console.ReadLine();
            Shrub shrub = shrubBusiness.GetShrubByName(name);
            if (shrub != null)
            {
                Console.WriteLine("Enter name: ");
                shrub.Name = Console.ReadLine();
                Console.WriteLine("Enter type: ");
                shrub.Type = Console.ReadLine();
                Console.WriteLine("Enter height: ");
                shrub.Height = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter life expectancy: ");
                shrub.LifeExpectancy = Console.ReadLine();
                Console.WriteLine("Enter seasons Id: ");
                shrub.SeasonsId = int.Parse(Console.ReadLine());
                shrubBusiness.Update(shrub);
                Console.WriteLine("The shrub was updated successfully!");
            }
            else
            {
                Console.WriteLine("Shrub not found!");
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter Name to fetch: ");
            string name = Console.ReadLine();
            var shrub = shrubBusiness.GetShrubByName(name);
            if (shrub != null)
            {
                var ShrubSeason = shrubBusiness.GetSeason(shrub.Name);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + shrub.Id);
                Console.WriteLine("Name: " + shrub.Name);
                Console.WriteLine("Type: " + shrub.Type);
                Console.WriteLine("Height: " + shrub.Height);
                Console.WriteLine("Life Expectancy: " + shrub.LifeExpectancy);
                Console.WriteLine("Seasons: " + ShrubSeason.Name);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Shrub not found!");
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            shrubBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void SearchShrubBySeason()
        {
            Console.WriteLine("Enter season id: ");
            Console.WriteLine("(1-spring, 2-summer, 3-autumn, 4-winter)");
            int seasonId = int.Parse(Console.ReadLine());
            List<Shrub> shrubs = shrubBusiness.SearchBySeason(seasonId);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Shrubs" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            foreach (var shrub in shrubs)
            {
                Console.WriteLine($"{shrub.Id} - {shrub.Name}");
            }
        }
    }
}
