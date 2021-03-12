using Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanicalGardenApp.Presentation
{ 
    public class SeasonDisplay
    {
        private int closeOperationId = 3;
        private SeasonBusiness seasonBusiness;

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "SEASON MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all seasons");
            Console.WriteLine("2. Fetch season by Name");
            Console.WriteLine("3. Exit");
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
                        ListAllSeasons();
                        break;
                    case 2:
                        Fetch();
                        break;
                    default:
                        break;
                }
            }
            while (operation != closeOperationId);
        }
        public SeasonDisplay()
        {
            seasonBusiness = new SeasonBusiness();
            Input();
        }

        private void ListAllSeasons()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Seasons" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var seasons = seasonBusiness.GetAllSeasons();
            foreach (var season in seasons)
            {
                Console.WriteLine($"{season.Id} - {season.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }

        private void Fetch()
        {
            Console.WriteLine("Enter Name to fetch: ");
            string name = Console.ReadLine();
            var season = seasonBusiness.GetSeasonByName(name);
            if (season != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + season.Id);
                Console.WriteLine("Name: " + season.Name);                
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Season not found!");
            }
        }
    }
}
