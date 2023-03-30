using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using static System.Console;
using System.Text.Json;


namespace PV_ssh_221
{
    public class Person
    {
        public string Name { get; set; }


        public int Age { get; set; }

        public int ID;
        [NonSerialized]
        const string Group = "PV221";
        public Person(string n, int a, int id)
        {
            Name = n;
            Age = a;
            ID = id;
        }

        public Person(int n)
        {
            ID = n;
        }
        public override string ToString()
        {
            return $"{Name}  {Age}  {ID}  {Group} ";
        }

        
    }


    class Program
    {
        static void Main(string[] args)
        {
            string file_name = "json_serialize.json";



            Person p1 = new Person("Kim", 22, 10);
            Person p2 = new Person("Mike", 31, 20);
            Person p3 = new Person("Kris", 19, 30);
            Person p4 = new Person("Alla", 45, 40);
            Person p5 = new Person("Maria", 24, 50);

            List<Person> persons = new List<Person> { p1, p2, p3, p4, p5 };

            string p_json = null;

           

            foreach (Person item in persons)
            {
                p_json += JsonSerializer.Serialize(item);
                File.WriteAllText(file_name, item.ToString());
                WriteLine(item);
            }





            string p1_new_str = File.ReadAllText(file_name);
            Person p1_new = JsonSerializer.Deserialize<Person>(p1_new_str);
            WriteLine(p1_new);






        }
    }
}