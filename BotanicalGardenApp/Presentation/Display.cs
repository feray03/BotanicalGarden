using System;
using System.Collections.Generic;
using System.Text;

namespace BotanicalGardenApp.Presentation
{
    public class Display
    {
        private int closeOperationId = 6;
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MAIN MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Flower Menu");
            Console.WriteLine("2. Tree Menu");
            Console.WriteLine("3. Shrub Menu");
            Console.WriteLine("4. Caktus Menu");
            Console.WriteLine("5. Grass Menu");
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
                        CreateFlowerDisplay();
                        break;
                    
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        public Display()
        {
            Input();
        }
        private void CreateFlowerDisplay()
        {
            FlowerDisplay display = new FlowerDisplay();
        }
    }
}
