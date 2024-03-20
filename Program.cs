namespace ToyStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var toyStore = new ToyGame();
            toyStore.LoadFromFile(); //Загружаем файл с игрушками (если не найден, то произойдет создание нового)
            Console.WriteLine("Список доступным команд:");
            Console.WriteLine("/print - показать все игрушки");
            Console.WriteLine("/add - добавить новую");
            Console.WriteLine("/change - изменить вес");
            Console.WriteLine("/start - запустить розыгрыш");
            Console.WriteLine("/exit - выйти");
            Console.WriteLine("Введите команду:");
            string command=Console.ReadLine();
            while (!"/exit".Equals(command))
            {
                if ("/print".Equals(command))
                {
                    toyStore.PrintToys();
                }
                if ("/add".Equals(command))
                {
                    toyStore.AddToyWithConsole();
                }
                if ("/change".Equals(command))
                {
                    toyStore.ChangeWithConsole();
                }
                if ("/start".Equals(command))
                {
                    toyStore.StartGame();
                }
                Console.WriteLine("Введите команду:");
                command = Console.ReadLine();
            }
            toyStore.SaveToFile(); //Записываем файл
        }
    }
}
