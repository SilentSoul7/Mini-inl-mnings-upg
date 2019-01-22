using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    public class Person
    {
        private string name;
        private int dayBorn;
        private int monthBorn;
        private int yearBorn;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int DayBorn
        {
            get { return dayBorn; }
            set
            {
                if ((value >= 1) && (value <= 31))
                {
                    dayBorn = value;
                }

            }
        }
        public int MonthBorn
        {
            get { return monthBorn; }
            set
            {
                if ((value >= 1) && (value <= 12))
                {
                    monthBorn = value;
                }

            }
        }
        public int YearBorn
        {
            get { return yearBorn; }
            set
            {
                if ((value >= 1900) && (value <= 2018))
                {
                    yearBorn = value;
                }

            }
        }

        public Person(string name, int dayBorn, int monthBorn, int yearBorn)
        {
            Name = name;
            DayBorn = dayBorn;
            MonthBorn = monthBorn;
            YearBorn = yearBorn;
        }

        private static List<Person> personList = new List<Person>();

        public static void Main()
        {
            int svar;
            Console.WriteLine("För att hitta en person tryck 1. För att lägga till en person tryck 2.");
            svar = Convert.ToInt32(Console.ReadLine());
            if (svar == 1)
            {
                GetPerson();

            }
            if (svar == 2)
            {
                Person persn = new Person("test", 1, 2, 3);

                persn.AddPerson();
            }
            else
            {
                Console.WriteLine("Var god och skriv in ett giltigt alternativ");
            }

        }
        public void ReadFile()
        {
            BinaryReader br = new BinaryReader(new FileStream("Person.tim", FileMode.OpenOrCreate, FileAccess.Read));
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                name = br.ReadString();
                dayBorn = br.ReadInt32();
                monthBorn = br.ReadInt32();
                yearBorn = br.ReadInt32();
            }
            br.Close();
        }

        public void WriteFile()
        {
            BinaryWriter bw = new BinaryWriter(new FileStream("Person.tim", FileMode.OpenOrCreate, FileAccess.Write));
            bw.Write(name);
            bw.Write(dayBorn);
            bw.Write(monthBorn);
            bw.Write(yearBorn);
            bw.Close();
        }

        public void AddPerson()
        {
            Console.WriteLine("Skriv personens namn och födelsedatum, dag, månad, år i den ordningen");
            personList.Add(new Person(name, dayBorn, monthBorn, yearBorn));
            name = Console.ReadLine();
            dayBorn = Convert.ToInt32(Console.ReadLine());
            monthBorn = Convert.ToInt32(Console.ReadLine());
            yearBorn = Convert.ToInt32(Console.ReadLine());

            WriteFile();


        }

        public static void GetPerson()
        {
            Console.WriteLine("Skriv namnet på personen du söker");
            List<Person> results;
            string searchInput = Console.ReadLine();
            results = personList.FindAll(person => person.name == searchInput);
            {

            }
            if (results.Count == 0)
            {
                Console.WriteLine("Det finns inga personer med detta namnet");
            }
            else
            {
                foreach (Person p in results)
                {
                    Console.WriteLine(p.Name, p.DayBorn, p.MonthBorn, p.YearBorn);
                }
            }

            Console.Read();
        }

    }
}
