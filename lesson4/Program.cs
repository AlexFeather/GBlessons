using System;

namespace lesson4
{
    class Program
    {
        static void Main(string[] args)
        {

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
            Name name = new Name(lastNames[rnd.Next(0, 9)], names[rnd.Next(0, 9)], patronymics[rnd.Next(0, 9)]);
            name.ViewName();
        }
    }
}
