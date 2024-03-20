using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToyStore
{
    public class ToyGame
    {
        int _idCounter;
        readonly List<Toy> _toys = new();
        public List<Toy> Toys
        {
            get
            {
                return _toys;
            }
        }
        public void PrintToys()
        {
            foreach (var toy in _toys)
            {
                Console.WriteLine(toy);
            }
        }
        public Toy AddToy(string name, int weight, int count) 
        { 
            var toy = new Toy(_idCounter,name,weight, count);
            _toys.Add(toy);
            Console.WriteLine("Была добавлена игрушка:");
            Console.WriteLine(toy);
            _idCounter++;
            return toy;
        }
        public void AddToyWithConsole()
        {
            Console.WriteLine("Введите название игушки: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Название не может быть пустым, повторите ввод:");
                name = Console.ReadLine();
            }
            Console.WriteLine("Введите вероятность выпадания игрушки (число от 1 до 100): ");
            string weidthStr = Console.ReadLine();
            int weidth;
            while (!int.TryParse(weidthStr, out weidth))
            {
                Console.WriteLine("Введите целое число");
                weidthStr = Console.ReadLine();
            }
            Console.WriteLine("Введите количество игрушек: ");
            string countStr = Console.ReadLine();
            int count;
           
            while (!int.TryParse(countStr, out count))
            {
                Console.WriteLine("Введите целое число");
                countStr = Console.ReadLine();
            }
            AddToy(name, weidth, count);
        }
        public void ChangeWithConsole()
        {
            Console.WriteLine("Введите идентификатор игушки: ");
            string idStr = Console.ReadLine();
            int id;
            while (!int.TryParse(idStr, out id))
            {
                Console.WriteLine("Введите целое число");
                idStr = Console.ReadLine();
            }
            if (_toys.Count(x=>x.Id == id)==0)
            {
                Console.WriteLine("Игрушки с таким ID не сущестует");
            }

            Console.WriteLine("Введите новое название игушки: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Название не может быть пустым, повторите ввод:");
                name = Console.ReadLine();
            }
            Console.WriteLine("Введите новую вероятность выпадания игрушки (число от 1 до 100): ");
            string weidthStr = Console.ReadLine();
            int weidth;
            while (!int.TryParse(weidthStr, out weidth))
            {
                Console.WriteLine("Введите целое число");
                weidthStr = Console.ReadLine();
            }
            Console.WriteLine("Введите новое количество игрушек: ");
            string countStr = Console.ReadLine();
            int count;

            while (!int.TryParse(countStr, out count))
            {
                Console.WriteLine("Введите целое число");
                countStr = Console.ReadLine();
            }
            ChangeToy(id, name, weidth, count);

        }

        private void ChangeToy(int id, string name, int weidth, int count)
        {
            var toy=_toys.First(x=>x.Id == id);
            toy.Name = name;
            toy.Weight= weidth;
            toy.Count= count;
            Console.WriteLine("Игрушка изменена");
        }

        string _fileName = "Toys.json";
        public void SaveToFile()
        {
            var jsonString = JsonSerializer.Serialize(_toys);
            File.WriteAllText(_fileName, jsonString);
            Console.WriteLine("Игрушки записаны в файл:" + _fileName);
        }
        public void LoadFromFile()
        {
            try
            {

                var jsonString = File.ReadAllText(_fileName);
                var toys = JsonSerializer.Deserialize<List<Toy>>(jsonString);
                _toys.Clear();
                _toys.AddRange(toys);
            } catch 
            {
                Console.WriteLine("Файл не найден. Создаю новый файл с игрушками");
                GenerateData();
            }
            foreach (var toy in _toys)
            {
                if (toy.Id > _idCounter)
                {
                    _idCounter = toy.Id;
                }
            }
            _idCounter++;
        }
        public void GenerateData()
        {
            AddToy("Чебурашка", 20, 3);
            AddToy("Ракета", 20, 6);
            AddToy("Машинка", 60, 2);
            SaveToFile();
        }

        public void StartGame()
        {
            if (_toys.Count(x=>x.Count>0) == 0) 
            {
                Console.WriteLine("Игрушки закончились");
            }
        }
    }
}
