using System;

namespace lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex2Sum.Linebraker();
        }
    }

    class Ex1Names
    {

        protected class Name
        {
            protected string firstName { get; private set; }
            protected string lastName { get; private set; }
            protected string patronymic { get; private set; }

            public Name(string last, string first, string patro)
            {
                firstName = first;
                lastName = last;
                patronymic = patro;
            }

            public void ViewName()
            {
                Console.WriteLine($"{lastName} {firstName} {patronymic}");
            }
        }

        static string[] names = { "Александр", "Михаил", "Станислав", "Орест", "Святослав", "Алексей", "Иван", "Юрий", "Андрей", "Артем" };
        static string[] patronymics = { "Александрович", "Михаилович", "Станиславович", "Орестович", "Святославович", "Алексеевич", "Иванович", "Юрьевич", "Андреевич", "Артемович" };
        static string[] lastNames = { "Романов", "Пушной", "Станиславский", "Стругацкий", "Кац", "Туполев", "Токарев", "Калашников", "Айзимов", "Зеленко" };

        public static void GetName()
        {
            Random rnd = new Random();
            Name name = new Name(lastNames[rnd.Next(0, lastNames.Length - 1)], names[rnd.Next(0, names.Length - 1)], patronymics[rnd.Next(0, patronymics.Length - 1)]);
            name.ViewName();
        }
    }

    class Ex2Sum
    {
        public static void Linebraker()
        {
            string line = Console.ReadLine();
            string[] splitLine = line.Split(' ');
            int result = 0;
            for(int i = 0; i < splitLine.Length; i++)
            {
                if(int.TryParse(splitLine[i], out int number))
                {
                    result += number;
                }
            }
            Console.WriteLine(result);
        }
    }
}
