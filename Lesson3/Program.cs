using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseReading();
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

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(mass1[i, i]);
            }
        }

        static void ReverseReading()
        {
            Console.WriteLine("Введите строку:");
            char[] enteredString = Console.ReadLine().ToCharArray();
            char[] reverseString = new char[enteredString.Length];
            int j = 0;
            for(int i = enteredString.Length - 1; i >= 0; i--)
            {
                reverseString[j] = enteredString[i];
                j++;
            }
            Console.WriteLine(reverseString);
        }

        class PhoneBook
        {
            static string[][] contacts = new string[5][];
            static bool init = false;

            static string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\contactlist.xml"));

            public static void NavMenu()
            {

                Initialization();

                Console.WriteLine(@"
            Выберите действие:
            1. Вывести список контактов.
            2. Создать новый контакт.
            3. Удалить существующий контакт.
            4. Возврат.");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    switch (result)
                    {
                        case 1:
                            ContactList();
                            break;
                        case 2:
                            AddContact();
                            break;
                        case 3:
                            RemoveContact();
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Указанного Вами действия не существует.");
                            NavMenu();
                            break;

                    }

                }

                static void ContactList()
                {
                    foreach(string[] element in contacts)
                    {
                        if(!string.IsNullOrEmpty(element[0]))
                        {
                            Console.WriteLine($"{element[0]} {element[1]}");
                        }
                    }
                    NavMenu();
                }

                static void AddContact()
                {

                    if (EmptyLineSearch(out int line))
                    {
                        Console.WriteLine("Введите имя контакта:");
                        contacts[line][0] = Console.ReadLine();
                        Console.WriteLine("Введите контактную информацию:");
                        contacts[line][1] = Console.ReadLine();
                        SaveList(contacts, path);
                        Console.WriteLine("Контакт создан.");
                        NavMenu();
                    }
                    else
                    {
                        Console.WriteLine("В справочнике не осталось свободных строк!");
                        NavMenu();
                    }
                }

                static bool EmptyLineSearch(out int line)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (string.IsNullOrEmpty(contacts[i][0]))
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
                    if (NameSearch(Console.ReadLine(), out int line))
                    {
                        contacts[line][0] = null;
                        contacts[line][1] = null;
                        SaveList(contacts, path);
                        Console.WriteLine("Контакт удален.");
                        NavMenu();
                    }

                }

                static bool NameSearch(string name, out int line)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (contacts[i][0] == name)
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

                static void SaveList(string[][] list, string path)
                {
                    string[] flat = new string[10];
                    int k = 0;

                    for (int i = 0; i < list.Length; i++)
                    {
                        for(int j = 0; j < 2; j++)
                        {
                            flat[k++] = list[i][j];
                        }
                    }

                    XmlSerializer serializer = new XmlSerializer(typeof(string[]));
                    string xml;
                    using (StringWriter stringWriter = new StringWriter())
                    {
                        serializer.Serialize(stringWriter, flat);
                        xml = stringWriter.ToString();  
                    }
                    File.WriteAllText(path, xml, Encoding.Default);
                }


                static string[][] LoadList(string path)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(string[]));
                    string[] loadedMass;
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        loadedMass = (string[])serializer.Deserialize(streamReader);
                        streamReader.Close();
                    }
                    string[][] inflatedMass = new string[5][];
                    for (int i = 0; i < 5; i++)
                    {
                        inflatedMass[i] = new string[2];
                    }    

                    foreach(string element in loadedMass)
                    {
                        int i = Array.IndexOf(loadedMass, element);
                        if (i % 2 == 0)
                        {
                            inflatedMass[i / 2][0] = element;
                        }
                        else
                        {
                            inflatedMass[i / 2][1] = element;
                        }
                    }

                    return inflatedMass;

                }

                static void Initialization()
                {
                    if (!init)
                    {
                        for (int i = 0; i < contacts.Length; i++)
                        {
                            contacts[i] = new string[2];
                        }
                        if (!File.Exists(path))
                        {
                            File.Create(path);
                        }
                        contacts = LoadList(path);
                        init = true;
                    }
                }
            }
        }
    }
}
