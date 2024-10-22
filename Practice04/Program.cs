using System;
using System.IO;
using System.Xml.Serialization;

namespace Example
{
    public class Boxer
    {
        public string fb; //Прізвище боксера
        public int w; //К-ть перемог
        public string ft; //Празвище тренера
        public Boxer() { }
        public Boxer(string boxer, int win, string trener)
        {
            this.fb = boxer;
            this.w = win;
            this.ft = trener;
        }
        public void Input()
        {
            Console.Write("Введіть прізвище боксера: ");
            fb = Console.ReadLine();

            Console.Write("Введіть кількість перемог: ");
            w = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть прізвище тренера: ");
            ft = Console.ReadLine();
        }
        public string Vivod()
        {
            string s = $"{fb}\t{Convert.ToString(w)}\t{ft}";
            return s;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Boxer> boxers = new List<Boxer>();


            for (int i = 0; i < 3; i++)
            {
                Boxer box = new Boxer();
                box.Input();
                boxers.Add(box);
            }

            XmlSerializer xmlS = new XmlSerializer(typeof(List<Boxer>));

            using (FileStream fs = new FileStream("C:\\Users\\svtko\\OneDrive\\Робочий стіл\\Person.txt", FileMode.OpenOrCreate))
            {
                xmlS.Serialize(fs, boxers);
                Console.WriteLine("Object has been serialized");
            }

            using (FileStream fs = new FileStream("C:\\Users\\svtko\\OneDrive\\Робочий стіл\\Person.txt", FileMode.OpenOrCreate))
            {
                List<Boxer>? dboxers = xmlS.Deserialize(fs) as List<Boxer>;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(boxers[i].Vivod());
                }
            }

        }
    }
}
