using System.Xml.Serialization;
using System;

namespace Practice04
{
    public class Person
    {
        public string Name { get; set; } = "Undefined";
        public int Age { get; set; } = 1;

        public Person() { }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class class1
    {
        static void Main(string[] args)
        {
            Person person = new Person("Tom", 37);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            string filepath = "C:\\Users\\svtko\\OneDrive\\Робочий стіл\\Person.txt";
            // отримуємо потік, куди записуватимемо серіалізований об'єкт
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, person);
                Console.WriteLine("Object has been serialized");
            }

            // десеріалізуємо об'єкт
            using (FileStream fs = new FileStream("filepath", FileMode.OpenOrCreate))
            {
                Person? dperson = xmlSerializer.Deserialize(fs) as Person;
                Console.WriteLine($"Name: {dperson?.Name}  Age: {dperson?.Age}");
            }
        }
    }
}