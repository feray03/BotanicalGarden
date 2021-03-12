using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanicalGardenApp.Presentation
{ 
    public class TreeDisplay
    {
        private int closeOperationId = 6;
        private TreeBusiness treeBusiness;

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "TREE MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all trees");
            Console.WriteLine("2. Add new tree");
            Console.WriteLine("3. Update tree");
            Console.WriteLine("4. Fetch tree by Name");
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
                        ListAllTrees();
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

        public TreeDisplay()
        {
            treeBusiness = new TreeBusiness();
            Input();
        }

        private void ListAllTrees()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Trees" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var trees = treeBusiness.GetAllTrees();
            foreach (var tree in trees)
            {
                var Seasons = treeBusiness.GetSeason(tree.Name);
                Console.WriteLine($"{tree.Id} - {tree.Name}, {tree.Type}, {tree.Height}, {tree.StemDiameter}, {Seasons.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }

        private void Add()
        {
            Tree tree = new Tree();
            Console.WriteLine("Enter name: ");
            tree.Name = Console.ReadLine();
            Console.WriteLine("Enter type: ");
            tree.Type = Console.ReadLine();
            Console.WriteLine("Enter height: ");
            tree.Height = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter stem diameter: ");
            tree.StemDiameter = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter seasons Id: ");
            tree.SeasonsId = int.Parse(Console.ReadLine());
            treeBusiness.Add(tree);
            Console.WriteLine("The tree was successfully added!");
        }

        private void Update()
        {
            Console.WriteLine("Enter Name to update: ");
            string name = Console.ReadLine();
            Tree tree = treeBusiness.GetTreeByName(name);
            if (tree != null)
            {
                Console.WriteLine("Enter name: ");
                tree.Name = Console.ReadLine();
                Console.WriteLine("Enter type: ");
                tree.Type = Console.ReadLine();
                Console.WriteLine("Enter height: ");
                tree.Height = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter stem diameter: ");
                tree.StemDiameter = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter seasons Id: ");
                tree.SeasonsId = int.Parse(Console.ReadLine());
                treeBusiness.Update(tree);
                Console.WriteLine("The tree was updated successfully!");
            }
            else
            {
                Console.WriteLine("Tree not found!");
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter Name to fetch: ");
            string name = Console.ReadLine();
            var tree = treeBusiness.GetTreeByName(name);
            if (tree != null)
            {
                var TreeSeason = treeBusiness.GetSeason(tree.Name);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + tree.Id);
                Console.WriteLine("Name: " + tree.Name);
                Console.WriteLine("Type: " + tree.Type);
                Console.WriteLine("Height: " + tree.Height);
                Console.WriteLine("Stem Diameter: " + tree.StemDiameter);
                Console.WriteLine("Seasons: " + TreeSeason.Name);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Tree not found!");
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            treeBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
