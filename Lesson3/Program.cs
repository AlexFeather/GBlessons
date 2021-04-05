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

            }

            static void ContactList()
            {

            }

            static void AddContact()
            {

                if(EmptyLineSearch(out int line))
                {
                    Console.WriteLine("Введите имя контакта:");
                    contacts[line, 0] = Console.ReadLine();
                    Console.WriteLine("Введите контактную информацию:");
                    contacts[line, 1] = Console.ReadLine();
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
                    else
                    {

                    }
                }
                line = -1;
                return false;
            }

            static void RemoveContact()
            {

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

            static void FileCheck()
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }
        }
    }
}
