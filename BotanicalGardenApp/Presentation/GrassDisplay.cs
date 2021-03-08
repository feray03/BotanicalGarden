using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanicalGardenApp.Presentation
{
    public class GrassDisplay
    {
        private int closeOperationId = 6;
        private GrassBusiness grassBusiness;

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "GRASS MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all grass");
            Console.WriteLine("2. Add new grass");
            Console.WriteLine("3. Update grass");
            Console.WriteLine("4. Fetch grass by Name");
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
                        ListAllGrasses();
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

        public GrassDisplay()
        {
            grassBusiness = new GrassBusiness();
            Input();
        }

        private void ListAllGrasses()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Grasses" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var grasses = grassBusiness.GetAllGrasses();
            foreach (var grass in grasses)
            {
                var Seasons = grassBusiness.GetSeason(grass.Name);
                Console.WriteLine($"{grass.Id } - {grass.Name}, {grass.Height}, {Seasons.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }

        private void Add()
        {
            Grass grass = new Grass();
            Console.WriteLine("Enter name: ");
            grass.Name = Console.ReadLine();
            Console.WriteLine("Enter height: ");
            grass.Height = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter seasons Id: ");
            grass.SeasonsId = int.Parse(Console.ReadLine());
            grassBusiness.Add(grass);
            Console.WriteLine("The grass was successfully added!");
        }


        private void Update()
        {
            Console.WriteLine("Enter Name to update: ");
            string name = Console.ReadLine();
            Grass grass = grassBusiness.GetGrassByName(name);
            if (grass != null)
            {
                Console.WriteLine("Enter name: ");
                grass.Name = Console.ReadLine();
                Console.WriteLine("Enter height: ");
                grass.Height = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter seasons Id: ");
                grass.SeasonsId = int.Parse(Console.ReadLine());
                grassBusiness.Update(grass);
                Console.WriteLine("The grass was updated successfully!");
            }
            else
            {
                Console.WriteLine("Grass not found!");
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter Name to fetch: ");
            string name = Console.ReadLine();
            var grass = grassBusiness.GetGrassByName(name);
            if (grass != null)
            {
                var GrassSeason = grassBusiness.GetSeason(grass.Name);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + grass.Id);
                Console.WriteLine("Name: " + grass.Name);
                Console.WriteLine("Height: " + grass.Height);
                Console.WriteLine("Seasons: " + GrassSeason.Name);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Grass not found!");
            }
        }
        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            grassBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}



