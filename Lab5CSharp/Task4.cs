using System;
using System.Collections.Generic;

namespace DocumentHierarchy
{
    // Варіант 1: Використання структур
    public struct InformationStruct
    {
        public string Medium; // Носій
        public int Size;      // Обсяг
        public string Title;  // Назва
        public string Author; // Автор

        public override string ToString()
        {
            return $"Назва: {Title}, Автор: {Author}, Носій: {Medium}, Обсяг: {Size} Мб";
        }
    }

    // Варіант 2: Використання кортежів
    // Кортеж: (Носій, Обсяг, Назва, Автор)

    // Варіант 3: Використання записів
    public record InformationRecord(
        string Medium,  // Носій
        int Size,       // Обсяг
        string Title,   // Назва
        string Author   // Автор
    )
    {
        public override string ToString()
        {
            return $"Назва: {Title}, Автор: {Author}, Носій: {Medium}, Обсяг: {Size} Мб";
        }
    }

    // Статичний клас для роботи зі структурами
    public static class StructProcessor
    {
        public static void RunStructExample()
        {
            List<InformationStruct> infoList = new List<InformationStruct>
            {
                new InformationStruct { Medium = "HDD", Size = 500, Title = "Звіт за 2023 рік", Author = "Петренко О.В." },
                new InformationStruct { Medium = "DVD", Size = 700, Title = "Презентація проекту", Author = "Іваненко І.І." },
                new InformationStruct { Medium = "SSD", Size = 250, Title = "База даних клієнтів", Author = "Коваленко К.К." },
                new InformationStruct { Medium = "USB", Size = 500, Title = "Фотоархів", Author = "Сидоренко С.С." }
            };

            Console.WriteLine("=== Робота зі структурами ===\n");
            Console.WriteLine("Початковий масив інформації:");
            PrintInformation(infoList);

            // Видалення першого елемента із заданим обсягом
            int sizeToRemove = 500;
            RemoveFirstBySize(infoList, sizeToRemove);
            Console.WriteLine($"\nМасив після видалення першого елемента з обсягом {sizeToRemove} Мб:");
            PrintInformation(infoList);

            // Додавання елемента перед елементом із зазначеним номером
            int indexToInsertBefore = 1;
            InformationStruct newInfo = new InformationStruct
            {
                Medium = "Cloud",
                Size = 1000,
                Title = "Резервна копія системи",
                Author = "Адміністратор"
            };

            InsertBeforeIndex(infoList, indexToInsertBefore, newInfo);
            Console.WriteLine($"\nМасив після додавання елемента перед індексом {indexToInsertBefore}:");
            PrintInformation(infoList);
        }

        static void PrintInformation(List<InformationStruct> infoList)
        {
            for (int i = 0; i < infoList.Count; i++)
            {
                Console.WriteLine($"{i}. {infoList[i]}");
            }
        }

        static void RemoveFirstBySize(List<InformationStruct> infoList, int size)
        {
            for (int i = 0; i < infoList.Count; i++)
            {
                if (infoList[i].Size == size)
                {
                    infoList.RemoveAt(i);
                    break;
                }
            }
        }

        static void InsertBeforeIndex(List<InformationStruct> infoList, int index, InformationStruct newInfo)
        {
            if (index >= 0 && index < infoList.Count)
            {
                infoList.Insert(index, newInfo);
            }
            else
            {
                Console.WriteLine("Некоректний індекс для вставки!");
            }
        }
    }

    // Статичний клас для роботи з кортежами
    public static class TupleProcessor
    {
        public static void RunTupleExample()
        {
            // Кортеж: (Носій, Обсяг, Назва, Автор)
            List<(string Medium, int Size, string Title, string Author)> infoList = new List<(string, int, string, string)>
            {
                ("HDD", 500, "Звіт за 2023 рік", "Петренко О.В."),
                ("DVD", 700, "Презентація проекту", "Іваненко І.І."),
                ("SSD", 250, "База даних клієнтів", "Коваленко К.К."),
                ("USB", 500, "Фотоархів", "Сидоренко С.С.")
            };

            Console.WriteLine("=== Робота з кортежами ===\n");
            Console.WriteLine("Початковий масив інформації:");
            PrintInformation(infoList);

            // Видалення першого елемента із заданим обсягом
            int sizeToRemove = 500;
            RemoveFirstBySize(infoList, sizeToRemove);
            Console.WriteLine($"\nМасив після видалення першого елемента з обсягом {sizeToRemove} Мб:");
            PrintInformation(infoList);

            // Додавання елемента перед елементом із зазначеним номером
            int indexToInsertBefore = 1;
            var newInfo = ("Cloud", 1000, "Резервна копія системи", "Адміністратор");

            InsertBeforeIndex(infoList, indexToInsertBefore, newInfo);
            Console.WriteLine($"\nМасив після додавання елемента перед індексом {indexToInsertBefore}:");
            PrintInformation(infoList);
        }

        static void PrintInformation(List<(string Medium, int Size, string Title, string Author)> infoList)
        {
            for (int i = 0; i < infoList.Count; i++)
            {
                var info = infoList[i];
                Console.WriteLine($"{i}. Назва: {info.Title}, Автор: {info.Author}, Носій: {info.Medium}, Обсяг: {info.Size} Мб");
            }
        }

        static void RemoveFirstBySize(List<(string Medium, int Size, string Title, string Author)> infoList, int size)
        {
            for (int i = 0; i < infoList.Count; i++)
            {
                if (infoList[i].Size == size)
                {
                    infoList.RemoveAt(i);
                    break;
                }
            }
        }

        static void InsertBeforeIndex(List<(string Medium, int Size, string Title, string Author)> infoList,
                                     int index,
                                     (string Medium, int Size, string Title, string Author) newInfo)
        {
            if (index >= 0 && index < infoList.Count)
            {
                infoList.Insert(index, newInfo);
            }
            else
            {
                Console.WriteLine("Некоректний індекс для вставки!");
            }
        }
    }

    // Статичний клас для роботи з записами
    public static class RecordProcessor
    {
        public static void RunRecordExample()
        {
            List<InformationRecord> infoList = new List<InformationRecord>
            {
                new InformationRecord("HDD", 500, "Звіт за 2023 рік", "Петренко О.В."),
                new InformationRecord("DVD", 700, "Презентація проекту", "Іваненко І.І."),
                new InformationRecord("SSD", 250, "База даних клієнтів", "Коваленко К.К."),
                new InformationRecord("USB", 500, "Фотоархів", "Сидоренко С.С.")
            };

            Console.WriteLine("=== Робота з записами ===\n");
            Console.WriteLine("Початковий масив інформації:");
            PrintInformation(infoList);

            // Видалення першого елемента із заданим обсягом
            int sizeToRemove = 500;
            RemoveFirstBySize(infoList, sizeToRemove);
            Console.WriteLine($"\nМасив після видалення першого елемента з обсягом {sizeToRemove} Мб:");
            PrintInformation(infoList);

            // Додавання елемента перед елементом із зазначеним номером
            int indexToInsertBefore = 1;
            InformationRecord newInfo = new InformationRecord(
                "Cloud",
                1000,
                "Резервна копія системи",
                "Адміністратор"
            );

            InsertBeforeIndex(infoList, indexToInsertBefore, newInfo);
            Console.WriteLine($"\nМасив після додавання елемента перед індексом {indexToInsertBefore}:");
            PrintInformation(infoList);
        }

        static void PrintInformation(List<InformationRecord> infoList)
        {
            for (int i = 0; i < infoList.Count; i++)
            {
                Console.WriteLine($"{i}. {infoList[i]}");
            }
        }

        static void RemoveFirstBySize(List<InformationRecord> infoList, int size)
        {
            for (int i = 0; i < infoList.Count; i++)
            {
                if (infoList[i].Size == size)
                {
                    infoList.RemoveAt(i);
                    break;
                }
            }
        }

        static void InsertBeforeIndex(List<InformationRecord> infoList, int index, InformationRecord newInfo)
        {
            if (index >= 0 && index < infoList.Count)
            {
                infoList.Insert(index, newInfo);
            }
            else
            {
                Console.WriteLine("Некоректний індекс для вставки!");
            }
        }
    }

    // Статичний клас для демонстрації завдання 4
    public static class Task4
    {
        public static void DemonstrateTask4()
        {
            Console.Clear();
            Console.WriteLine("=== Завдання 4: Обробка масиву структур, кортежів та записів ===\n");

            Console.WriteLine("Виберіть варіант реалізації:");
            Console.WriteLine("1 - Використання структур");
            Console.WriteLine("2 - Використання кортежів");
            Console.WriteLine("3 - Використання записів");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StructProcessor.RunStructExample();
                    break;
                case "2":
                    TupleProcessor.RunTupleExample();
                    break;
                case "3":
                    RecordProcessor.RunRecordExample();
                    break;
                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }
        }
    }
}