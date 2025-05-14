using System;
using System.Collections.Generic;

namespace DocumentHierarchy
{
    // Абстрактний базовий клас "Програмне забезпечення"
    public abstract class Software
    {
        // Захищені поля
        protected string name;
        protected string developer;

        // Конструктор з параметрами
        public Software(string name, string developer)
        {
            this.name = name;
            this.developer = developer;
        }

        // Властивості
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Developer
        {
            get { return developer; }
            set { developer = value; }
        }

        // Абстрактні методи
        public abstract void DisplayInfo();
        public abstract bool CanUse();
    }

    // Похідний клас - Вільне ПЗ
    public class FreeSoftware : Software
    {
        // Конструктор
        public FreeSoftware(string name, string developer)
            : base(name, developer)
        {
        }

        // Реалізація абстрактних методів
        public override void DisplayInfo()
        {
            Console.WriteLine("--- Вільне програмне забезпечення ---");
            Console.WriteLine($"Назва: {name}");
            Console.WriteLine($"Розробник: {developer}");
            Console.WriteLine("Тип ліцензії: Вільна");
            Console.WriteLine("Можливість використання: Необмежена");
        }

        public override bool CanUse()
        {
            // Вільне ПЗ завжди можна використовувати
            return true;
        }
    }

    // Похідний клас - Умовно-безкоштовне ПЗ
    public class SharewareSoftware : Software
    {
        // Додаткові поля
        private DateTime installDate;
        private int trialPeriodDays;

        // Конструктор
        public SharewareSoftware(string name, string developer, DateTime installDate, int trialPeriodDays)
            : base(name, developer)
        {
            this.installDate = installDate;
            this.trialPeriodDays = trialPeriodDays;
        }

        // Властивості
        public DateTime InstallDate
        {
            get { return installDate; }
            set { installDate = value; }
        }

        public int TrialPeriodDays
        {
            get { return trialPeriodDays; }
            set { trialPeriodDays = value; }
        }

        // Методи
        public DateTime ExpirationDate
        {
            get { return installDate.AddDays(trialPeriodDays); }
        }

        // Реалізація абстрактних методів
        public override void DisplayInfo()
        {
            Console.WriteLine("--- Умовно-безкоштовне програмне забезпечення ---");
            Console.WriteLine($"Назва: {name}");
            Console.WriteLine($"Розробник: {developer}");
            Console.WriteLine($"Дата встановлення: {installDate.ToShortDateString()}");
            Console.WriteLine($"Тривалість пробного періоду: {trialPeriodDays} днів");
            Console.WriteLine($"Дата закінчення пробного періоду: {ExpirationDate.ToShortDateString()}");
            Console.WriteLine($"Можливість використання: {(CanUse() ? "Так" : "Ні - термін пробного періоду закінчився")}");
        }

        public override bool CanUse()
        {
            // Перевірка, чи не закінчився пробний період
            return DateTime.Now <= ExpirationDate;
        }
    }

    // Похідний клас - Комерційне ПЗ
    public class CommercialSoftware : Software
    {
        // Додаткові поля
        private decimal price;
        private DateTime installDate;
        private int licenseValidityDays;

        // Конструктор
        public CommercialSoftware(string name, string developer, decimal price, DateTime installDate, int licenseValidityDays)
            : base(name, developer)
        {
            this.price = price;
            this.installDate = installDate;
            this.licenseValidityDays = licenseValidityDays;
        }

        // Властивості
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public DateTime InstallDate
        {
            get { return installDate; }
            set { installDate = value; }
        }

        public int LicenseValidityDays
        {
            get { return licenseValidityDays; }
            set { licenseValidityDays = value; }
        }

        // Методи
        public DateTime ExpirationDate
        {
            get { return installDate.AddDays(licenseValidityDays); }
        }

        // Реалізація абстрактних методів
        public override void DisplayInfo()
        {
            Console.WriteLine("--- Комерційне програмне забезпечення ---");
            Console.WriteLine($"Назва: {name}");
            Console.WriteLine($"Розробник: {developer}");
            Console.WriteLine($"Ціна: {price:C}");
            Console.WriteLine($"Дата встановлення: {installDate.ToShortDateString()}");
            Console.WriteLine($"Термін дії ліцензії: {licenseValidityDays} днів");
            Console.WriteLine($"Дата закінчення ліцензії: {ExpirationDate.ToShortDateString()}");
            Console.WriteLine($"Можливість використання: {(CanUse() ? "Так" : "Ні - термін ліцензії закінчився")}");
        }

        public override bool CanUse()
        {
            // Перевірка, чи не закінчився термін ліцензії
            return DateTime.Now <= ExpirationDate;
        }
    }

    // Статичний клас для демонстрації завдання 3
    public static class Task3
    {
        public static void DemonstrateTask3()
        {
            Console.Clear();
            Console.WriteLine("=== Завдання 3: База програмного забезпечення ===\n");

            // Створення бази (масиву) програмного забезпечення
            List<Software> softwareDatabase = new List<Software>();

            // Додавання вільного ПЗ
            softwareDatabase.Add(new FreeSoftware("Linux Ubuntu", "Canonical Ltd."));
            softwareDatabase.Add(new FreeSoftware("Mozilla Firefox", "Mozilla Foundation"));
            softwareDatabase.Add(new FreeSoftware("LibreOffice", "The Document Foundation"));

            // Додавання умовно-безкоштовного ПЗ
            // Деякі з цих програм мають термін, що вже минув, для демонстрації
            softwareDatabase.Add(new SharewareSoftware("WinRAR", "win.rar GmbH", DateTime.Now.AddDays(-50), 40));
            softwareDatabase.Add(new SharewareSoftware("AVG Antivirus", "AVG Technologies", DateTime.Now.AddDays(-20), 30));
            softwareDatabase.Add(new SharewareSoftware("CCleaner", "Piriform", DateTime.Now.AddDays(-5), 14));

            // Додавання комерційного ПЗ
            softwareDatabase.Add(new CommercialSoftware("Microsoft Office", "Microsoft", 149.99m, DateTime.Now.AddDays(-100), 365));
            softwareDatabase.Add(new CommercialSoftware("Adobe Photoshop", "Adobe Inc.", 239.99m, DateTime.Now.AddDays(-200), 180));
            softwareDatabase.Add(new CommercialSoftware("Windows 11", "Microsoft", 199.99m, DateTime.Now.AddDays(-30), 3650));

            // Виведення повної інформації про все ПЗ
            Console.WriteLine("=== Повна інформація про програмне забезпечення ===\n");

            for (int i = 0; i < softwareDatabase.Count; i++)
            {
                Console.WriteLine($"ПЗ #{i + 1}");
                softwareDatabase[i].DisplayInfo();
                Console.WriteLine();
            }

            // Пошук ПЗ, яке можна використовувати на поточну дату
            Console.WriteLine("=== Програмне забезпечення, доступне для використання на поточну дату ===\n");

            bool foundUsableSoftware = false;

            for (int i = 0; i < softwareDatabase.Count; i++)
            {
                if (softwareDatabase[i].CanUse())
                {
                    Console.WriteLine($"ПЗ #{i + 1}: {softwareDatabase[i].Name} ({softwareDatabase[i].GetType().Name})");
                    foundUsableSoftware = true;
                }
            }

            if (!foundUsableSoftware)
            {
                Console.WriteLine("Не знайдено програмного забезпечення, доступного для використання на поточну дату.");
            }
        }
    }
}