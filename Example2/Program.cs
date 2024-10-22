using System.Xml.Serialization;

namespace Example2
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

    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person("Tom", 37),
                new Person("Bob", 41)
            };
            string filepath = "C:\\Users\\svtko\\OneDrive\\Робочий стіл\\Person2.txt";

            XmlSerializer formatter = new XmlSerializer(typeof(Person[]));
            // збереження масиву у файл
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }
            // відновлення масиву із файлу
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                Person[]? newpeople = formatter.Deserialize(fs) as Person[];

                if (newpeople != null)
                {
                    foreach (Person person in newpeople)
                    {
                        Console.WriteLine($"Name: {person.Name} --- Age: {person.Age}");
                    }
                }
            }
        }
    }
}
