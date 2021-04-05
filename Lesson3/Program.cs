using System;
using System.IO;
using System.Xml.Serialization;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void Menu()
        {

        }

        static void DiagonalRead()
        {
            int[,] mass1 = {
                { 4, 8, 5},
                { 15, 6, 1},
                { 9, 14, 18}
            };

            for (int i = 0; i < 3; i++ )
            {
                Console.WriteLine(mass1[i,i]);
            }
        }

        class PhoneBook
        {
            static string[,] contacts = new string[5, 2];

            static string path = @"\contactlist.xml";

            static void NavMenu()
            {
                Console.WriteLine(@"
            Выберите дейсвтие:
            1. Вывести список контактов.
            2. Создать новый контакт.
            3. Удалить существующий контакт.
            4. Возврат.");
            }

            static void ContactList()
            {
                Console.WriteLine(contacts);
            }

            static void AddContact()
            {

                if(EmptyLineSearch(out int line))
                {
                    Console.WriteLine("Введите имя контакта:");
                    contacts[line, 0] = Console.ReadLine();
                    Console.WriteLine("Введите контактную информацию:");
                    contacts[line, 1] = Console.ReadLine();
                    SaveList(contacts, path);
                    Console.WriteLine("Контакт создан.");
                }
                else 
                {
                    Console.WriteLine("В справочнике не осталось свободных строк!");
                    Menu();
                }
            }

            static bool EmptyLineSearch(out int line)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (string.IsNullOrEmpty(contacts[i, 0]))
                    {
                        line = i;
                        return true;
                    }
                }
                line = -1;
                return false;
            }

            static void RemoveContact()
            {
                Console.WriteLine("Введите точное имя контакта для его удаления:");
                if(NameSearch(Console.ReadLine(), out int line))
                {
                    contacts[line, 0] = null;
                    contacts[line, 1] = null;
                    SaveList(contacts, path);
                    Console.WriteLine("Контакт удален.");
                }

            }

            static bool NameSearch(string name, out int line)
            {
                for (int i = 0; i < 5; i++)
                {
                    if(contacts[i,0] == name)
                    {
                        Console.WriteLine($"Контакт с именем {name} найден.");
                        line = i;
                        return true;
                    }
                }
                line = -1;
                Console.WriteLine($"Контакта с именем {name} не найдено.");
                return false;
            }

            static void SaveList(string[,] list, string path)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(string[,]));
                string xml;
                using (StringWriter stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, list);
                    xml = stringWriter.ToString();
                }

            }
            static string[,] LoadList(string path)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(string[,]));
                string[,] loadedMass;
                using (StreamReader streamReader = new StreamReader(path))
                {
                    loadedMass = (string[,])serializer.Deserialize(streamReader);
                }
                return loadedMass;
            }

            static void Initialization()
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                LoadList(path);
            }
        }
    }
}
