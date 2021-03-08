using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanicalGardenApp.Presentation
{
    public class CactusDisplay
    {
        private int closeOperationId = 6;
        private CactusBusiness cactusBusiness;

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "CACTUS MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all cactus");
            Console.WriteLine("2. Add new cactus");
            Console.WriteLine("3. Update cactus");
            Console.WriteLine("4. Fetch cactus by Name");
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
                        ListAllCactuses();
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
                    default:
                        break;
                }
            }
            while (operation != closeOperationId);
        }

        public CactusDisplay()
        {
            cactusBusiness = new CactusBusiness();
            Input();
        }

        private void ListAllCactuses()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Cactus" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var cactuses = cactusBusiness.GetAllCactuses();
            foreach (var cactus in cactuses)
            {
                var Seasons = cactusBusiness.GetSeason(cactus.Name);
                Console.WriteLine($"{cactus.Id} - {cactus.Name}, {cactus.Height}, {cactus.Thorns}, {Seasons.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }

        private void Add()
        {
            Cactus cactus = new Cactus();
            Console.WriteLine("Enter name: ");
            cactus.Name = Console.ReadLine();
            Console.WriteLine("Enter height: ");
            cactus.Height = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter thorns: ");
            cactus.Thorns = Console.ReadLine();
            Console.WriteLine("Enter seasons Id: ");
            cactus.SeasonsId = int.Parse(Console.ReadLine());
            cactusBusiness.Add(cactus);
            Console.WriteLine("The cactus was successfully added!");
        }

        private void Update()
        {
            Console.WriteLine("Enter Name to update: ");
            string name = Console.ReadLine();
            Cactus cactus = cactusBusiness.GetCactusByName(name);
            if (cactus != null)
            {
                Console.WriteLine("Enter name: ");
                cactus.Name = Console.ReadLine();
                Console.WriteLine("Enter height: ");
                cactus.Height = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter thorns: ");
                cactus.Thorns = Console.ReadLine();
                Console.WriteLine("Enter seasons Id: ");
                cactus.SeasonsId = int.Parse(Console.ReadLine());
                cactusBusiness.Update(cactus);
                Console.WriteLine("The cactus was updated successfully!");
            }
            else
            {
                Console.WriteLine("Cactus not found!");
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter Name to fetch: ");
            string name = Console.ReadLine();
            var cactus = cactusBusiness.GetCactusByName(name);
            if (cactus != null)
            {
                var CactusSeason = cactusBusiness.GetSeason(cactus.Name);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + cactus.Id);
                Console.WriteLine("Name: " + cactus.Name);
                Console.WriteLine("Height: " + cactus.Height);
                Console.WriteLine("Thorns: " + cactus.Thorns);
                Console.WriteLine("Seasons: " + CactusSeason.Name);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Cactus not found!");
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            cactusBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}


