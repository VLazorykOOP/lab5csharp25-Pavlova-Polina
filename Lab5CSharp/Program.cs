using System;

namespace DocumentHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Лабораторна робота №5 ===");
                Console.WriteLine("1. Завдання 1+2: Ієрархія класів документів з конструкторами");
                Console.WriteLine("2. Завдання 3: База програмного забезпечення");
                Console.WriteLine("3. Завдання 4: Обробка масиву структур, кортежів та записів");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВиберіть опцію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DemonstrateTask1and2();
                        break;
                    case "2":
                        Task3.DemonstrateTask3();
                        break;
                    case "3":
                        Task4.DemonstrateTask4();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
                    Console.ReadKey();
                }
            }
        }

        static void DemonstrateTask1and2()
        {
            Console.Clear();
            Console.WriteLine("=== Завдання 1+2: Ієрархія класів документів з конструкторами ===\n");

            // Демонстрація конструкторів
            Console.WriteLine("=== Демонстрація конструкторів ===\n");

            Console.WriteLine("--- Створення об'єктів за допомогою конструкторів за замовчуванням ---");
            Receipt receipt1 = new Receipt();
            Invoice invoice1 = new Invoice();
            Bill bill1 = new Bill();

            Console.WriteLine("\n--- Створення об'єктів за допомогою конструкторів з параметрами ---");
            Receipt receipt2 = new Receipt("КВ-001", DateTime.Now, "Оплата комунальних послуг", "Іванов І.І.", 1250.50m);
            Invoice invoice2 = new Invoice("НК-001", DateTime.Now, "Доставка товарів", "ТОВ Постачальник", "ТОВ Замовник");
            Bill bill2 = new Bill("РХ-001", DateTime.Now, "Оплата послуг", "Петров П.П.", "Консультаційні послуги", 12000.00m, 20.0m);

            Console.WriteLine("\n--- Створення об'єктів за допомогою конструкторів копіювання ---");
            Receipt receipt3 = new Receipt(receipt2);
            Invoice invoice3 = new Invoice(invoice2);
            Bill bill3 = new Bill(bill2);

            // Додавання товарів до накладної
            invoice2.AddItem("Комп'ютер", 25000.00m, 2);
            invoice2.AddItem("Монітор", 5000.00m, 3);

            // Відображення інформації про документи
            Console.WriteLine("\n=== Демонстрація властивостей та методів класів ===\n");

            Console.WriteLine("Інформація про квитанцію:");
            receipt2.Show();
            Console.WriteLine($"Сума до сплати: {receipt2.CalculateTotal():C}\n");

            Console.WriteLine("Інформація про накладну:");
            invoice2.Show();
            Console.WriteLine($"Загальна сума: {invoice2.CalculateTotal():C}\n");

            Console.WriteLine("Інформація про рахунок:");
            bill2.Show();
            Console.WriteLine($"Загальна сума: {bill2.CalculateTotal():C}\n");

            // Демонстрація поліморфізму
            Console.WriteLine("=== Демонстрація поліморфізму ===\n");
            Document[] documents = new Document[] { receipt2, invoice2, bill2 };

            foreach (Document doc in documents)
            {
                Console.WriteLine($"Документ типу: {doc.GetType().Name}");
                doc.Show();
                Console.WriteLine($"Сума: {doc.CalculateTotal():C}\n");
            }

            // Демонстрація перевантаження операторів
            Console.WriteLine("=== Демонстрація перевантаження операторів ===\n");
            Bill bill4 = new Bill("РХ-002", DateTime.Now, "Оплата інтернет послуг",
                                "Петров П.П.", "Інтернет", 500.00m, 20.0m);

            Console.WriteLine("Рахунок 1:");
            bill2.Show();
            Console.WriteLine($"Сума: {bill2.CalculateTotal():C}\n");

            Console.WriteLine("Рахунок 2:");
            bill4.Show();
            Console.WriteLine($"Сума: {bill4.CalculateTotal():C}\n");

            Console.WriteLine("Об'єднаний рахунок (Рахунок 1 + Рахунок 2):");
            Bill combinedBill = bill2 + bill4;
            combinedBill.Show();
            Console.WriteLine($"Сума: {combinedBill.CalculateTotal():C}\n");

            // Демонстрація виклику деструкторів
            Console.WriteLine("\n=== Демонстрація виклику деструкторів ===\n");
            Console.WriteLine("Для демонстрації виклику деструкторів створимо об'єкти у локальному блоці:");

            {
                Receipt localReceipt = new Receipt("ЛК-001", DateTime.Now, "Локальна квитанція", "Тестовий користувач", 100m);
                Invoice localInvoice = new Invoice("ЛН-001", DateTime.Now, "Локальна накладна", "Тест постачальник", "Тест отримувач");
                Bill localBill = new Bill("ЛР-001", DateTime.Now, "Локальний рахунок", "Тест клієнт", "Тестова послуга", 500m, 15m);

                Console.WriteLine("Локальні об'єкти створені. Виходимо з локального блоку...");
            }

            Console.WriteLine("\nВикликаємо збирач сміття для демонстрації деструкторів:");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}