using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore
{
    public class Toy
    {
        public Toy(int id, string name, int count, int weight)
        {
            _id = id;
            _name = name;
            _count = count;
            _weight = weight;
        }

        public override string ToString()
        {
            return $"ID: {_id} Название: {_name} Вес: {_weight} Количество: {_count}";
        }
        int _id;
       
        string _name ="";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null)
                    _name = value;
                else _name = "";
            }
        }
        int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (value < 0)
                {
                    _count = 0;
                }
                else
                {
                    _count = value;
                }
            }
        }

        public int Id { get => _id; set => _id = value; }
        public int Weight { get => _weight; set => _weight = value; }

        int _weight;

    }
}
